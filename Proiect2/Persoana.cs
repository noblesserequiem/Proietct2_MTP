using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Proiect2
{
    class Persoana
    {
        private int index;
        private string nume;
        private DateTime dataNasterii;
        private string telefon;
        private string adresa;
        private Categorie categorie;

        public Persoana(int index, string nume, DateTime data, string tel, string adr, Categorie categorie)
        {
            this.index = index;
            this.nume = nume;
            this.dataNasterii = data;
            this.telefon = tel;
            this.adresa = adr;
            this.categorie = categorie;
        }
        [Description("Index"), Browsable(false)]
        public int Index { get { return index; } }
        [Description("Numele Complet"), Category("Date Personale")]
        public string Nume { get { return nume; } }
        [Description("Data Nastere"), Category("Date Personale")]
        public DateTime Data { get { return dataNasterii; } }
        [Description("Numar Telefon"), Category("Date Contact")]
        public string Telefon { get { return telefon; } set { this.telefon = value; } }
        [Description("Adresa"), Category("Date Contact")]
        public string Adresa { get { return adresa; } set { this.adresa = value; } }
        [Description("Incadrare"), Category("Date Personale")]
        public Categorie Categorie { get { return categorie; } set { this.categorie = value; } }

    }

    enum Categorie : int
    {
        Prieteni = 0,
        Colegi = 1,
        Rude = 2,
        Diversi = 3
    }

    
}
