namespace YuGiOhAPI
{
    public class Yugioh
    {
        public int id { get; set; }
        public string name { get; set; } = String.Empty;
        public string type { get; set; } = String.Empty;
        public string desc { get; set; } = String.Empty;
        public string race { get; set; } = String.Empty;
        public string archetype { get; set; } = String.Empty;
        public string atribute { get; set; } = String.Empty;
        public CardSets set { get; set; }
        public CardImages image { get; set; }
        public CardPrice price { get; set; }

    }
}
