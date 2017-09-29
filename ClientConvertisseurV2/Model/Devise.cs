namespace ClientConvertisseurV2.Models
{
    /// <summary>
    /// Classe métier représentant une entité devise
    /// <para> 
    /// Maxence Royer
    /// </para>
    /// </summary>
    public class Devise
    {
        // Attribut Id, identifiant de l'objet
        public int Id { get; set; }

        // Attribut Nom
        public string Nom { get; set; }

        // Attribut Taux
        public double Taux { get; set; }
    }
}
