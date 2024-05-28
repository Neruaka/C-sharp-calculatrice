using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Définition de l'espace de noms pour notre application de calculatrice.
namespace CalculatorApp
{
    // Classe principale du formulaire, dérivée de la classe Form de Windows Forms.
    public partial class Form1 : Form
    {
        // Déclaration de variables pour stocker le résultat des opérations et pour le suivi.
        double resultValue = 0; // Valeur du résultat accumulé.
        string operationPerformed = ""; // Opération actuelle effectuée (+, -, *, /).
        bool isOperationPerformed = false; // Flag pour vérifier si une opération a été effectuée.

        // Constructeur du formulaire.
        public Form1()
        {
            InitializeComponent(); // Méthode pour initialiser les composants du formulaire.
        }

        // Gestionnaire d'événements pour les clics sur les boutons numériques.
        private void button_click(object sender, EventArgs e)
        {
            // Effacer l'affichage si le texte est "0" ou si une opération a été effectuée.
            if (tbDisplayResult.Text == "0" || (isOperationPerformed))
                tbDisplayResult.Clear();

            isOperationPerformed = false; // Réinitialisation du flag après une opération.

            Button button = (Button)sender; // Récupération du bouton qui a été cliqué.

            // Validation pour ne pas ajouter plus d'un point décimal.
            if (button.Text == ".")
            {
                if (!tbDisplayResult.Text.Contains("."))
                    tbDisplayResult.Text += button.Text; // Ajouter un point décimal s'il n'y en a pas.
            }
            else
            {
                tbDisplayResult.Text += button.Text; // Ajouter le chiffre ou le point au texte affiché.
            }
        }

        // Gestionnaire d'événements pour les clics sur les boutons des opérateurs.
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // Récupération du bouton qui a été cliqué.

            operationPerformed = button.Text; // Stockage de l'opérateur choisi.
            resultValue = Double.Parse(tbDisplayResult.Text); // Conversion et stockage du nombre affiché.
            lbCurrentOp.Text = resultValue + " " + operationPerformed; // Affichage de l'opération en cours.
            isOperationPerformed = true; // Marquer qu'une opération a été effectuée.
        }

        // Gestionnaire d'événements pour le bouton de réinitialisation (C).
        private void button17_Click(object sender, EventArgs e)
        {
            tbDisplayResult.Text = "0"; // Réinitialiser l'affichage.
            resultValue = 0; // Réinitialiser la valeur résultat.
        }

        // Gestionnaire d'événements pour le bouton de remise à zéro (CE).
        private void button18_Click(object sender, EventArgs e)
        {
            tbDisplayResult.Text = "0"; // Réinitialiser l'affichage à zéro.
        }

        // Gestionnaire d'événements pour le bouton égal (=).
        private void button19_Click(object sender, EventArgs e)
        {
            // Effectuer le calcul selon l'opérateur stocké.
            switch (operationPerformed)
            {
                case "+":
                    tbDisplayResult.Text = (resultValue + double.Parse(tbDisplayResult.Text)).ToString();
                    break;
                case "-":
                    tbDisplayResult.Text = (resultValue - double.Parse(tbDisplayResult.Text)).ToString();
                    break;
                case "X":
                    tbDisplayResult.Text = (resultValue * double.Parse(tbDisplayResult.Text)).ToString();
                    break;
                default:
                    tbDisplayResult.Text = (resultValue / double.Parse(tbDisplayResult.Text)).ToString();
                    break;
            }
        }

        // Gestionnaire d'événements pour le bouton de suppression de caractère (backspace).
        private void button16_Click(object sender, EventArgs e)
        {
            // Supprimer le dernier caractère de l'affichage, si possible.
            if (tbDisplayResult.Text.Length > 0)
                tbDisplayResult.Text = tbDisplayResult.Text.Remove(tbDisplayResult.Text.Length - 1, 1);

            // Si l'affichage est vide après suppression, mettre "0".
            if (tbDisplayResult.Text == "")
                tbDisplayResult.Text = "0";
        }
    }
}
