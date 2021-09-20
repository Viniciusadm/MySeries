namespace MySeries.Classes {
    public abstract class Base {
        public int ID { get; set; }

        public Base(int id) {
            this.ID = id;
        }
    }
}