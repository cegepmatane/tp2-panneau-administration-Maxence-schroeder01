using System;
using System.Windows;
using tp2_MaxenceSchroeder.accesDonnees;

namespace tp2_MaxenceSchroeder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            if (String.IsNullOrEmpty(Searchbox.Text))
            {
                string error = "Vous n'avez pas rentrer de numero d'utilisateur";
                number.Text = error;
            }
            int search = Int32.Parse(Searchbox.Text);
            var utilisateur = _uttilisateurDAO.Obtenir(search);
            try
            {
                number.Text = utilisateur.noUtil.ToString();
                department.Text = utilisateur.noDEP.ToString();
                type.Text = utilisateur.noTYPEUTIL.ToString();
                name.Text = utilisateur.nomUtil.ToString();
                Fname.Text = utilisateur.prenomUtil.ToString();
                email.Text = utilisateur.courieUTIL.ToString();
                password.Text = utilisateur.motdepasseUTIL.ToString();
                notdisplay.Text = utilisateur.nePlusAfficher.ToString();
                deletedate.Text = utilisateur.dateSuppression.ToString();
                deleteby.Text = utilisateur.supprimePar.ToString();
            }
            catch
            {
                if (String.IsNullOrEmpty(Searchbox.Text))
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
            if (String.IsNullOrEmpty(Searchbox.Text))
            {
                string error = "Vous n'avez pas rentrer de numero d'utilisateur";
                number.Text = error;
            }
            else
            {
                Searchbox.Text = String.Empty;
                number.Text = String.Empty;
                department.Text = String.Empty;
                type.Text = String.Empty;
                name.Text = String.Empty;
                Fname.Text = String.Empty;
                email.Text = String.Empty;
                password.Text = String.Empty;
                notdisplay.Text = String.Empty;
                deletedate.Text = String.Empty;
                deleteby.Text = String.Empty;
            }

        }
        private void BtndeleteUtlisateur_Click(object sender, RoutedEventArgs q)
        {
            if (String.IsNullOrEmpty(Searchbox.Text))
            {
                string error = "Vous n'avez pas rentrer de numero d'utilisateur";
                number.Text = error;
            }
            bool isCreate = _uttilisateurDAO.Iscreate();
            int search = Int32.Parse(Searchbox.Text);
            var utilisateur = _uttilisateurDAO.Supprimer(search);
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
            if (String.IsNullOrEmpty(Searchbox.Text))
            {
                bool isCreate = _uttilisateurDAO.Iscreate();
                utilisateurC.nomUtil = number.Text;
                utilisateurC.noDEP = Int32.Parse(department.Text);
                utilisateurC.noTYPEUTIL = Int32.Parse(type.Text);
                utilisateurC.nomUtil = name.Text;
                utilisateurC.prenomUtil = Fname.Text;
                utilisateurC.courieUTIL = email.Text;
                utilisateurC.motdepasseUTIL = char.Parse(password.Text);
                utilisateurC.nePlusAfficher = Int32.Parse(notdisplay.Text);
                utilisateurC.dateSuppression = DateTime.Parse(deletedate.Text);
                utilisateurC.supprimePar = Int32.Parse(deleteby.Text);

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
                int search = Int32.Parse(Searchbox.Text);
                var utilisateur = _uttilisateurDAO.Obtenir(search);
                Utilisateur utilisateurE = new Utilisateur();
                utilisateurE = _uttilisateurDAO.Obtenir(search);
                bool isCreate = _uttilisateurDAO.Iscreate();
                utilisateurE.nomUtil = number.Text;
                utilisateurE.noDEP = Int32.Parse(department.Text);
                utilisateurE.noTYPEUTIL = Int32.Parse(type.Text);
                utilisateurE.nomUtil = name.Text;
                utilisateurE.prenomUtil = Fname.Text;
                utilisateurE.courieUTIL = email.Text;
                utilisateurE.motdepasseUTIL = char.Parse(password.Text);
                utilisateurE.nePlusAfficher = Int32.Parse(notdisplay.Text);
                utilisateurE.dateSuppression = DateTime.Parse(deletedate.Text);
                utilisateurE.supprimePar = Int32.Parse(deleteby.Text);

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
