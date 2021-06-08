namespace MoqProtectedSourceGenerator
{
    public class Finding
    {
        public string Key { get; set; }
        public string Found { get; set; }
        public bool Converted { get; set; }
        public object Value { get; set; }
        public bool FoundAndConverted => Found != null && Converted;
    }


}
