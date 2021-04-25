namespace textor.models{
    public abstract class GameObject {

        public GameObjectId Id {get; set;}
        public string Article {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
    }

    public enum GameObjectId {
        short_sword,
        long_sword

    }
}