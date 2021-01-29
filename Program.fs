open Common
open Nav

let player = { Location = RoomIdentifier.EndarSpireDorm }

let world = { 
        Player = player
        Rooms = [
                endarSpireDorm;
                endarSpireDormCorridor;
        ]
}

[<EntryPoint>]
let main argv =
        world
        |> enterRoom
        |> openExit "DOOR" 
        |> goThroughExitWithName "DOOR"
        |> enterRoom
       
        0 // return an integer exit code
