using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign5RegEx
{
    public partial class RegExForm : Form
    {
        public RegExForm()
        {
            InitializeComponent();
        }

        private void SocSecbutton_Click(object sender, EventArgs e)
        {
            String text = SocSecText.Text;
            if (socSecurity(text))
            {
                MessageBox.Show("This is a proper Social Security number");
            }
            else
            {
                MessageBox.Show("This is NOT a proper Social Security number");
            }
        }

        private bool socSecurity(String text)
        {
            //Looks for soc sec in form of XXXXXXXXX
            Regex rg1 = new Regex(@"^[0-9]{9}$");
            //Looks for soc sec in form of XXX-XX-XXXX or XXX XX XXXX
            Regex rg2 = new Regex(@"^[0-9]{3}(-|\s)[0-9]{2}(-|\s)[0-9]{4}$");
            Match match = rg1.Match(text);
            if (match.Success)
            {
                return true;
            }
            match = rg2.Match(text);
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private void Phonebutton_Click(object sender, EventArgs e)
        {
            String text = PhonetextBox.Text;
            if (phoneCheck(text))
            {
                MessageBox.Show("This is a proper phone number");
            }
            else
            {
                MessageBox.Show("This is NOT a proper phone number");
            }
        }

        private bool phoneCheck(String text)
        {
            //Check for phone number with area code in the form XXXXXXXXXX
            Regex rg1 = new Regex(@"^[0-9]{10}$");
            //Check for phone number with area code in the form (XXX)XXXXXXX
            Regex rg2 = new Regex(@"^[(][0-9]{3}[)][0-9]{7}$");
            //Check for phone number with area code in the form XXX-XXX-XXXX
            Regex rg3 = new Regex(@"^[0-9]{3}[-][0-9]{3}[-][0-9]{4}$");
            //Check for phone number with area code in the form (XXX)-XXX-XXXX
            Regex rg4 = new Regex(@"^[(][0-9]{3}[)][-][0-9]{3}[-][0-9]{4}$");

            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }

            match = rg2.Match(text);
            if(match.Success)
            {
                return true;
            }

            match = rg3.Match(text);
            if (match.Success)
            {
                return true;
            }

            match = rg4.Match(text);
            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            String text = emailTextBox.Text;
            if (emailCheck(text))
            {
                MessageBox.Show("This is a proper Email");
            }
            else
            {
                MessageBox.Show("This is NOT a proper Email");
            }
        }

        private bool emailCheck(String text)
        {
            //Check for email in the form XXXXXXX@XXXXX.XXX
            Regex rg1 = new Regex(@"^[a-zA-Z0-9._%$#]+(?!.*[\.]{2,}.*)@[a-zA-Z.]+\.[a-zA-Z]{2,6}$");

            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private void nameButton_Click(object sender, EventArgs e)
        {
            String text = nameTextBox.Text;
            if (nameCheck(text))
            {
                MessageBox.Show("This is a proper name");
            }
            else
            {
                MessageBox.Show("This is NOT a proper name");
            }
        }

        private bool nameCheck(String text)
        {
            //Check for name Last first MI can be seperated by a comma, white space or both
            Regex rg1 = new Regex(@"[-a-zA-Z]{1,30}((,|\s)|,\s)[a-zA-Z]{1,19}((,|\s)|,\s)[a-zA-Z]{1,4}");
            Match match = rg1.Match(text);

            if(match.Success)
            {
                return true;
            }

            return false;
        }

        private void dateButton_Click(object sender, EventArgs e)
        {
            String text = dateTextBox.Text;
            if (dateCheck(text))
            {
                MessageBox.Show("This is a proper date");
            }
            else
            {
                MessageBox.Show("This is NOT a proper date");
            }
        }
        private bool dateCheck(String text)
        {
            //leap year if divisable by 4 
            //Check for date in the form MM-DD-YYYY or MM DD YYYY or MM/DD/YYYY
            Regex rg1 = new Regex(@"^(0[1-9]|1[0-2]?)(-|\s|/)(0[1-9]|[1-2][0-9]|3[0-1]?)(-|\s|/)[0-9]{4}");
            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private void addressButton_Click(object sender, EventArgs e)
        {
            String text = addressTextBox.Text;
            if (addressCheck(text))
            {
                MessageBox.Show("This is a proper address");
            }
            else
            {
                MessageBox.Show("This is NOT a proper address");
            }
        }

        private bool addressCheck(String text)
        {
            //Check for address house number street name
            Regex rg1 = new Regex(@"^[0-9]+\s[nsewNSEW]{1}\.\s([0-9]{1,}(th|rd|nd)?|[a-zA-Z]+\s([rR]oad|[sS]treet|[bB]oulevard|[aA]venue|[aA]ve|[bB]lvd|[sS]t|[rR]d)?(\.)?)$");
            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private void cityButton_Click(object sender, EventArgs e)
        {
            String text = cityTextBox.Text;
            if (cityCheck(text))
            {
                MessageBox.Show("This is a proper address");
            }
            else
            {
                MessageBox.Show("This is NOT a proper address");
            }
        }
        private bool cityCheck(String text)
        {
            //Check for City State Zip (the regex for the state abbreviation was copied from regexlib.com author Brendan Hunt.
            Regex rg1 = new Regex(@"^[A-Z]{1}[a-z]{1,}\s(?:(A[KLRZ]|C[AOT]|D[CE]|FL|GA|HI|I[ADLN]|K[SY]|LA|M[ADEINOST]|N[CDEHJMVY]|O[HKR]|P[AR]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY]))\s([0-9]{5}|[0-9]{5}-[0-9]{4})");
            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private void militaryButton_Click(object sender, EventArgs e)
       {
            String text = militaryTextBox.Text;
            if (militaryCheck(text))
            {
                MessageBox.Show("This is a proper military time");
            }
            else
            {
                MessageBox.Show("This is NOT a proper military time");
            }
        }

        private bool militaryCheck(String text)
        {
            //Checks for military time in the form HHMMSS HHMM:SS HH:MMSS HH:MM:SS HH MM SS
            Regex rg1 = new Regex(@"^(0[0-9]|1[0-9]|2[0-4])(:|(\s?))([0-5][0-9]|[6][0])(:|(\s?))([0-5][0-9]|[6][0])");
            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }
            return false;
        }


        private void currencyButton_Click(object sender, EventArgs e)
        {
            String text = currencyTextBox.Text;
            if (currencyCheck(text))
            {
                MessageBox.Show("This is a proper US currency");
            }
            else
            {
                MessageBox.Show("This is NOT a proper US currency");
            }
        }

        private bool currencyCheck(String text)
        {
            Regex rg1 = new Regex(@"^[\$][0-9,]*(.[0-9]{2}$)");
            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private void urlButton_Click(object sender, EventArgs e)
        {
            String text = urlTextBox.Text;
            if (urlCheck(text))
            {
                MessageBox.Show("This is a proper url");
            }
            else
            {
                MessageBox.Show("This is NOT a proper url");
            }
        }

        private bool urlCheck(String text)
        {
            Regex rg1 = new Regex(@"^((http(s)?:\/\/)|(www\.))+[a-zA-Z0-9-\.]{2,256}\.[a-z\.]{2,6}([a-zA-Z0-9\.\/\\+&amp\$=#~_%])*$");
            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private void passwordButton_Click(object sender, EventArgs e)
        {
            String text = passwordTextBox.Text;
            if (passwordCheck(text))
            {
                MessageBox.Show("This is a proper password");
            }
            else 
            {
                MessageBox.Show("This is NOT a proper password");
            }
        }

        private bool passwordCheck(String text)
        {
            Regex rg1 = new Regex(@"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[\?\!@#\$%^&*.,:;])(?!.*[a-z]{4,}.*){10,}");
            Match match = rg1.Match(text);

            if (match.Success)
            {
                return true;
            }
            return false;
        }

        private void oddButton_Click(object sender, EventArgs e)
        {
            String text = oddTextBox.Text;
            if (oddCheck(text))
            {
                MessageBox.Show("This is a proper odd word ending in ion");
            }
            else
            {
                MessageBox.Show("This is NOT a proper odd word ending in ion");
            }
        }

        private bool oddCheck(String text)
        {
            //Checks if string is odd
            if (text.Length % 2 == 1)
            {
                //checks to see if the string ends in ion
                Regex rg1 = new Regex(@"^[a-zA-Z]{0,}(ion)");
                Match match = rg1.Match(text);

                if (match.Success)
                {
                    return true;
                }
            }
            return false;
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            String fh = fileTextBox.Text;
            String choice;
            String line;
            bool result = false;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fh);
                while ((choice = file.ReadLine()) != null)
                {
                    line = file.ReadLine();
                    switch (choice)
                    {
                       
                        case "a":
                            result = socSecurity(line);
                            break;
                        case "b":
                            result = phoneCheck(line);
                            break;
                        case "c":
                            result = emailCheck(line);
                            break;
                        case "d":
                            result = nameCheck(line);
                            break;
                        case "e":
                            result = dateCheck(line);
                            break;
                        case "f":
                            result = addressCheck(line);
                            break;
                        case "g":
                            result = cityCheck(line);
                            break;
                        case "h":
                            result = militaryCheck(line);
                            break;
                        case "i":
                            result = currencyCheck(line);
                            break;
                        case "j":
                            result = urlCheck(line);
                            break;
                        case "k":
                            result = passwordCheck(line);
                            break;
                        case "l":
                            result = oddCheck(line);
                            break;
                        case "q":
                            break;
                        
                    }
                    if(choice != "q")
                        resultTextBox.AppendText(line + " Result: " + result.ToString() + "\n");
                }

                file.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
