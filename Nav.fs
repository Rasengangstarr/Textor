module Nav

        open Common
        
        type RoomIdentifier =
                | EndarSpireDorm = 0
                | EndarSpireDormCorridor = 1

        type Door =
                {
                        LockLevel : int
                }

        type ExitKind =
                | Open of string * RoomIdentifier
                | Closed of string * Door * RoomIdentifier

        and Room =
                {
                        Identifier : RoomIdentifier
                        Details : Details
                        OnFirstEnteredScript : string
                        Exits : ExitKind list
                        HasBeenEntered: bool
                }

        type Player =
                {
                        Location : RoomIdentifier
                }
        

        type World =
                {
                        Player : Player
                        Rooms : Room list
                }


        let findRoom ri w =
                (w.Rooms
                |> List.filter (fun x -> x.Identifier = ri )).Head

        let currentRoom w =
                w
                |> findRoom w.Player.Location

        let openClosedExit rk =
                match rk with
                | Closed(x,y,z) -> Open(x,z)
                | Open(x,z) -> Open(x,z)

        let markRoomAsEntered ri rooms =
                List.map (fun x -> if x.Identifier = ri then {x with HasBeenEntered = true} else x) rooms 
        
        let getExitWithName r n =
                List.find (fun x -> match x with | Open(x,_) -> x = n | Closed (x,_,_) -> x = n ) r 

        let openExit n w =
                let r = currentRoom w;
                { w with Rooms = List.map (fun x -> if x = r then {
                        r with Exits = List.map (fun y -> if y = getExitWithName r.Exits n then openClosedExit y else y ) r.Exits } else x ) w.Rooms }

        let moveToRoom ri w =
                { w with Player = { w.Player with Location = ri }; Rooms = markRoomAsEntered ri w.Rooms } 

        let getOpenExitWithName w n =
               ((currentRoom w).Exits
                |> List.choose (fun e ->
                        match e with
                        | Open (x,y) -> Some (x,y)
                        | Closed _ -> None)
                |> List.filter (fun (x,_) -> x = n )).Head

        let goThroughExitWithName n w =
                w
                |> moveToRoom (snd (getOpenExitWithName w n))

                
        let enterRoom w =
                let r = currentRoom w
                match r.HasBeenEntered with
                | false -> printf "\n\n%s\n\n" r.OnFirstEnteredScript
                | _    -> printf ""
                describe r.Details 
                w

        
        let endarSpireDormCorridor =
                {
                        Identifier = RoomIdentifier.EndarSpireDormCorridor
                        OnFirstEnteredScript = "";
                        Details = { Name = "The Dormatory Corridor"; Description = "";}
                        Exits = [];
                        HasBeenEntered = false;
                }

        let endarSpireDorm =
                {
                        Identifier = RoomIdentifier.EndarSpireDorm
                        Details = { Name = "Endar Spire Dorm"; Description = "Your Dormatory on the Endar Spire. On the eastern side of the room are a set of plastisteel couches, and on the west is a your's and Trask's bunks. To the north is FOOTLOCKER, behind which is a window through which you can see the ocassional sith fighter or plasma bolt streaming against the blackness of space. To the south is a DOOR."; };
                        OnFirstEnteredScript = "You awake on your bunk to the sound of an explosion. The whole room shakes as another explosion, this time closer to you, rips through the ship. You jump up out of your bed and stand up. The door to your south opens and a sharp faced man with white crew cut hair and an orange and yellow Republic Soldier's uniform runs into the room, the door shutting behind him.";
                        Exits = [Closed("DOOR", {LockLevel = 0 }, RoomIdentifier.EndarSpireDormCorridor )];
                        HasBeenEntered = false;
                }


