using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestMongoDB
{
    /// <summary>
    /// Exemple de lien entre l'application C# et MongoDB
    /// Affichage des produits, ajout, modification et suppression "en dur"
    /// </summary>
    public partial class FrmChocolatein : Form
    {
        private MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
        private IMongoDatabase db;
        private IMongoCollection<Produit> collection;
        private List<Produit> lesProduits = new List<Produit>();

        public FrmChocolatein()
        {
            InitializeComponent();
        }

        /// <summary>
        /// accès à la BDD et demande de remplissage de la liste des produits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmChocolatein_Load(object sender, EventArgs e)
        {
            db = client.GetDatabase("chocolatein");
            collection = db.GetCollection<Produit>("produits");
            RemplirListe();
        }

        /// <summary>
        /// Récupération de la liste des produits 
        /// pour remplir la listbox
        /// </summary>
        private void RemplirListe()
        {
            lesProduits = collection.AsQueryable().ToList<Produit>();
            lstProduits.Items.Clear();
            foreach (Produit produit in lesProduits)
            {
                lstProduits.Items.Add(produit.ToString());
            }
        }

        /// <summary>
        /// Ajout d'un prodiut 'en dur'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Produit produit = new Produit("rocher_gourmand", "Rocher gourmand", "Rocher en chocolat avec éclats de caramel", "boite de 4", "", "chocolats", 0);
            collection.InsertOne(produit);
            RemplirListe();
        }

        /// <summary>
        /// Modification 'en dur' d'une gamme de produits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            UpdateDefinition<Produit> update = Builders<Produit>.Update.Set(p => p.gamme, "produits_de_saison");
            collection.UpdateMany(p => p.gamme == "produits_rares", update);
            RemplirListe();
        }

        /// <summary>
        /// Suppression 'en dur' du produit ajouté
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            collection.DeleteMany(p => p.id == "rocher_gourmand");
            RemplirListe();
        }
    }
}
