namespace Travela.WebUI.Dtos
{
    public class CreateDestinationDto
    {
        public string city { get; set; }
        public string country { get; set; }
        public string imageUrl { get; set; }
        public int countDay { get; set; }
        public string subTitle { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public DateTime date { get; set; }
    }
}
