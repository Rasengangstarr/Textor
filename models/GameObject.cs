namespace textor.models{
    public abstract class GameObject {
        public GameObject(GameObjectId id, string name, string description, string article) {
            Id = id;
            Article = article;
            Name = name;
            Description = description;
        }
        public GameObjectId Id {get; set;}
        public string Article {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
    }

    public enum GameObjectId {
        revan,
        short_sword,
        long_sword,
        endarspire_quarters_footlocker,
        clothing,
    }
}