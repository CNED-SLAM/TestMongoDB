using MongoDB.Bson;

namespace TestMongoDB
{
    /// <summary>
    /// Classe métier correspondant à la collection Produits
    /// </summary>
    public class Produit
    {
        public ObjectId Id { get; set; }
        public string id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public string packaging { get; set; }
        public string urlimg { get; set; }
        public string gamme { get; set; }
        public int stock { get; set; }

        /// <summary>
        /// Constructeur : valorise les propriétés excepté l'Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="description"></param>
        /// <param name="packaging"></param>
        /// <param name="urlimg"></param>
        /// <param name="gamme"></param>
        /// <param name="stock"></param>
        public Produit(string id, string nom, string description, string packaging, string urlimg, string gamme, int stock)
        {
            this.id = id;
            this.nom = nom;
            this.description = description;
            this.packaging = packaging;
            this.urlimg = urlimg;
            this.gamme = gamme;
            this.stock = stock;
        }

        /// <summary>
        /// Formatage de l'affichage
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.nom + " (" + this.packaging + ") " + this.gamme;
        }
    }
}
