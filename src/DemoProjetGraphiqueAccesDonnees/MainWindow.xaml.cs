using DemoProjetGraphiqueAccesDonnees.AccesDonnees;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Windows;
using System;
using System.Data.SqlClient;

namespace DemoProjetGraphiqueAccesDonnees
{
    public partial class MainWindow : Window
    {
        private readonly IUtilisateurDAO _uttilisateurDAO;

        public MainWindow(IUtilisateurDAO utilisateurDAO)
        {
            InitializeComponent();

            _uttilisateurDAO = utilisateurDAO;
        }
        private void BtnChargUtilisateur_Click(object sender, RoutedEventArgs q)
        {
            int search = int.Parse(Searchbox.Text);
            var utilisateur = _uttilisateurDAO.Obtenir(search);
            try
            {
                number.Text = utilisateur.noUTIL.ToString();
                department.Text = utilisateur.noDEP.ToString();
                type.Text = utilisateur.noTYPEUTIL.ToString();
                name.Text = utilisateur.nomUTIL.ToString();
                Fname.Text = utilisateur.prenomUTIL.ToString();
                email.Text = utilisateur.courrielUTIL;
                password.Text = utilisateur.motpasseUTIL;
                notdisplay.Text = utilisateur.nePlusAfficher.ToString();
                deletedate.Text = utilisateur.dateSuppression.ToString();
                deleteby.Text = utilisateur.supprimePar.ToString();
            }
            catch
            {
                if (string.IsNullOrEmpty(Searchbox.Text))
                {
                    string error = "Vous n'avez pas rentrer de numero d'utilisateur";
                    number.Text = error;
                }
                else
                {
                    MessageBox.Show("le numero d'utilisateur que vous chercher n'existe pas");
                }
            }

        }

        private void BtnClearUtlisateur_Click(object sender, RoutedEventArgs q)
        {
            if (string.IsNullOrEmpty(Searchbox.Text))
            {
                string error = "Vous n'avez pas rentrer de numero d'utilisateur";
                number.Text = error;
            }
            else
            {
                Searchbox.Text = string.Empty;
                number.Text = string.Empty;
                department.Text = string.Empty;
                type.Text = string.Empty;
                name.Text = string.Empty;
                Fname.Text = string.Empty;
                email.Text = string.Empty;
                password.Text = string.Empty;
                notdisplay.Text = string.Empty;
                deletedate.Text = string.Empty;
                deleteby.Text = string.Empty;
            }

        }
        private void BtndeleteUtlisateur_Click(object sender, RoutedEventArgs q)
        {
            if (string.IsNullOrEmpty(Searchbox.Text))
            {
                string error = "Vous n'avez pas rentrer de numero d'utilisateur";
                number.Text = error;
            }
            bool isCreate = _uttilisateurDAO.Iscreate();
            int search = int.Parse(Searchbox.Text);
            _uttilisateurDAO.Supprimer(search);
            if (isCreate == true)
            {
                MessageBox.Show("L'utilisateur a etee supprimer");
            }
            else
            {
                MessageBox.Show("L'utilisateur na pas pus etre supprimer");
            }

        }
        private void BtndeleteLogicUtlisateur_Click(object sender, RoutedEventArgs q)
        {
            if (string.IsNullOrEmpty(Searchbox.Text))
            {
                string error = "Vous n'avez pas rentrer de numero d'utilisateur";
                number.Text = error;
            }
            bool isCreate = _uttilisateurDAO.Iscreate();
            int search = int.Parse(Searchbox.Text);
            _uttilisateurDAO.Supprimerlogique(search);
            if (isCreate == true)
            {
                MessageBox.Show("L'utilisateur a etee supprimer");
            }
            else
            {
                MessageBox.Show("L'utilisateur na pas pus etre supprimer");
            }

        }

        private void BtnaddoreditUtlisateur_Click(object sender, RoutedEventArgs q)
        {
            Utilisateur utilisateurC = new Utilisateur();
            if (string.IsNullOrEmpty(Searchbox.Text))
            {
                bool isCreate = _uttilisateurDAO.Iscreate();
                utilisateurC.noUTIL = int.Parse(number.Text);
                utilisateurC.noDEP = int.Parse(department.Text);
                utilisateurC.noTYPEUTIL = int.Parse(type.Text);
                utilisateurC.nomUTIL = name.Text;
                utilisateurC.prenomUTIL = Fname.Text;
                utilisateurC.courrielUTIL = email.Text;
                utilisateurC.motpasseUTIL = password.Text;
                utilisateurC.nePlusAfficher = int.Parse(notdisplay.Text);
                utilisateurC.dateSuppression = DateTime.Now;
                utilisateurC.supprimePar = int.Parse(deleteby.Text);

                if (string.IsNullOrEmpty(Searchbox.Text))
                {
                    string error = "Vous n'avez pas rentrer de numero d'utilisateur";
                    Searchbox.Text = error;
                }

                _uttilisateurDAO.Creer(utilisateurC);
                if (isCreate == true)
                {
                    MessageBox.Show("L'utilisateur a etee creer");
                }
                else
                {
                    MessageBox.Show("L'utilisateur na pas pus etre creer");
                }
            }
            else
            {
                int search = int.Parse(Searchbox.Text);
                _uttilisateurDAO.Obtenir(search);
                _ = new Utilisateur();
                Utilisateur utilisateurE = _uttilisateurDAO.Obtenir(search);
                bool isCreate = _uttilisateurDAO.Iscreate();
                utilisateurE.nomUTIL = number.Text;
                utilisateurE.noDEP = int.Parse(department.Text);
                utilisateurE.noTYPEUTIL = int.Parse(type.Text);
                utilisateurE.nomUTIL = name.Text;
                utilisateurE.prenomUTIL = Fname.Text;
                utilisateurE.courrielUTIL = email.Text;
                utilisateurE.motpasseUTIL = password.Text;
                utilisateurE.nePlusAfficher = int.Parse(notdisplay.Text);
                utilisateurE.dateSuppression = DateTime.Parse(deletedate.Text);
                utilisateurE.supprimePar = int.Parse(deleteby.Text);

                _uttilisateurDAO.MettreAJour(utilisateurE);
                if (isCreate == true)
                {
                    MessageBox.Show("L'utilisateur a etee modifier");
                }
                else
                {
                    MessageBox.Show("L'utilisateur na pas pus etre modifier");
                }
            }
        }
    }
}
