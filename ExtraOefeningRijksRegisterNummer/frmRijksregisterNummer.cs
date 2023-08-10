using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraOefeningRijksRegisterNummer
{
    public partial class frmRijksregisterNummer : Form
    {
        public frmRijksregisterNummer()
        {
            InitializeComponent();
        }

        private void txtRijksregisternummer_Validating(object sender, CancelEventArgs e)
        {
            ////clear current/old error first
            //epRijksregisternummer.Clear();

            ////define Checklist
            //CheckList clChecks = new CheckList();

            ////run through all checks until one fails & show the errormessage on the errorpanel
            //foreach (ICheck check in clChecks.ListOfChecks)
            //{
            //    if (!check.Check())
            //    {
            //        epRijksregisternummer.SetError(txtRijksregisternummer, check.ErrorMessage());
            //        break;
            //    }

            //}

        }

        private void txtRijksregisternummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only certain characters (#/del/backspace) can be entered in the textbox
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                // If the key is not a digit, Backspace, or Delete, prevent the character from being entered.
                e.Handled = true;
            }

            //the textbox can only contain a certain amount of characters
            if(txtRijksregisternummer.Text.Length >= 15)
            {
                e.Handled = true;
            }

        }

        private void txtRijksregisternummer_TextChanged(object sender, EventArgs e)
        {
            //disable the TextChanged temporary
            txtRijksregisternummer.TextChanged -= txtRijksregisternummer_TextChanged;
            //check all characters on being valid (we need to do this again in case of copy/paste)
            OnlyAddValidCharacters();
            //Add extra characters where needed
            AddExtraCharacterAtDesignatedLocation();
            // Set the cursor position to the end of the textbox
            txtRijksregisternummer.SelectionStart = txtRijksregisternummer.Text.Length;
            //reactivate the TextChanged
            txtRijksregisternummer.TextChanged += txtRijksregisternummer_TextChanged;

        }

        //method to check all characters being #/del/backspace
        private void OnlyAddValidCharacters()
        {
            // Get the text from the textbox
            string strBoxText = txtRijksregisternummer.Text;

            // Create a StringBuilder to store the filtered characters
            StringBuilder filteredText = new StringBuilder();

            // Loop through each character in the textbox text
            foreach (char c in strBoxText)
            {
                // Check if the character is a digit, backspace, delete
                if (char.IsDigit(c) || c == '\b' || c == '\u007F')
                { 

                    if (filteredText.Length < 11)
                    {
                        // If it's an allowed character, add it to the filteredText
                        filteredText.Append(c);
                    }

                }
                else
                {
                    epRijksregisternummer.SetError(txtRijksregisternummer, "Faulty input has been filtered out");
                }

            }

            // Update the textbox text with the filtered text
            txtRijksregisternummer.Text = filteredText.ToString();

        }

        //method to add extra characters at designated locations
        private void AddExtraCharacterAtDesignatedLocation()
        {
            string strInput = txtRijksregisternummer.Text;
            int intInputLength = strInput.Length;

            if (intInputLength > 0)
            {
                if (intInputLength >= 2)
                    strInput = strInput.Insert(2, ".");
                if (intInputLength >= 4)
                    strInput = strInput.Insert(5, ".");
                if (intInputLength >= 6)
                    strInput = strInput.Insert(8, "-");
                if (intInputLength >= 9)
                    strInput = strInput.Insert(12, ".");
            }

            txtRijksregisternummer.Text = strInput;
        }

    }

}
