namespace Silas.Models.Offers
{//MODELO PARA INSERTAR UNA OFERTA NUEVA EN BD
    public class OfferInsert
    {
    
        public string title { get; set; }
        public string description { get; set; }
        public int id_course { get; set; }
        public DateTime? date { get; set; } = DateTime.Today;
        public string location { get; set; }
        public int id_company { get; set; }

    }
}
