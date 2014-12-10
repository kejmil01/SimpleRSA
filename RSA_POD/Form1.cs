using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarlJohansen;

namespace RSA_POD
{
    public partial class Form1 : Form
    {
        private static int minPrimeValue = 1000;
        private static int maxPrimeValue = 9999;

        public Form1()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            enableButtons(false);

            try
            {
                if (validateRawData() && validatePublicKey())
                {
                    String encryptedString = encryptMethod(rawTextBox.Text);
                    encryptedTextBox.Text = encryptedString;
                }
            }
            catch (Exception ex)
            {
                String message = "Wystapil błąd:" + Environment.NewLine + ex.Message;
                MessageBox.Show(message);
            }

            enableButtons(true);
        }

        private String encryptMethod(String data)
        {
            Key publicKey = generatePublicKey();
            List<BigInt> arr = Encryptor.encrypt(publicKey, data);

            String s = "";

            if (arr.Count > 0)
            {
                s += arr[0].ToString();
                for (int i = 1; i < arr.Count; i++)
                {
                    s += Environment.NewLine;
                    s += arr[i].ToString();
                }
            }
            return s;
        }

        private Key generatePublicKey()
        {
            Key k = new Key();
            k.key = Int32.Parse(eTextBox.Text);
            k.n = Int32.Parse(nTextBox.Text);
            return k;
        }

        private bool validateRawData()
        {
            String rawData = rawTextBox.Text;
            if (rawData.Length == 0)
            {
                MessageBox.Show("Pole danych wejsciowych nie może być puste.");
                return false;
            }
            return true;
        }

        private bool validatePublicKey()
        {
            if (validateParameter(nTextBox.Text, "n"))
                return validateParameter(eTextBox.Text, "q");
            return false;
        }

        private void enableButtons(bool state)
        {
            encryptButton.Enabled = state;
            decryptButton.Enabled = state;
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            enableButtons(false);

            try
            {
                if (validateEncryptedData() && validatePrivateKey())
                {
                    Key privateKey = generatePrivateKey();
                    List<BigInt> ints = parseBigIntegers();
                    String decrypted = Decryptor.decrypt(ints, privateKey);
                    decryptedTextBox.Text = decrypted;
                }
            }
            catch (Exception ex)
            {
                String message = "Wystąpił błąd:" + Environment.NewLine + ex.Message;
                MessageBox.Show(message);
            }

            enableButtons(true);
        }

        private Key generatePrivateKey()
        {
            Key k = new Key();
            k.key = Int32.Parse(dTextBox.Text);
            k.n = Int32.Parse(privateNTextBox.Text);
            return k;
        }

        private bool validateEncryptedData()
        {
            String rawData = encryptedTextBox.Text;
            if (rawData.Length == 0)
            {
                MessageBox.Show("Pole danych zaszyfrowanych nie może być puste.");
                return false;
            }
            return true;
        }

        private bool validatePrivateKey()
        {
            if (validateParameter(privateNTextBox.Text, "n"))
                return validateParameter(dTextBox.Text, "d");
            return false;
        }

        private List<BigInt> parseBigIntegers()
        {
            List<BigInt> ints = new List<BigInt>();
            string[] separators = { Environment.NewLine };
            string[] strings = encryptedTextBox.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in strings)
            {
                try
                {
                    BigInt result = s;
                    ints.Add(result);
                }
                catch (Exception ex)
                {
                    throw new Exception("Błąd przy parsowaniu danych: " + ex.Message);
                }
            }
            return ints;
        }

        private void pqButton_Click(object sender, EventArgs e)
        {
            generatePrimes();
        }

        private void keysButton_Click(object sender, EventArgs e)
        {
            if(validatePQ())
            {
                generateKeys();
            }
        }

        private bool validatePQ()
        {
            if (validateParameter(pTextBox.Text, "p"))
                return validateParameter(qTextBox.Text, "q");
            return false;
        }

        private bool validateParameter(String data, String parameterName)
        {
            if (data.Length == 0)
            {
                MessageBox.Show("Pole '" + parameterName + "' nie może być puste.");
                return false;
            }
            else
            {
                int parameter;
                bool result = Int32.TryParse(data, out parameter);
                if (!result)
                {
                    MessageBox.Show("Pole '" + parameterName + "' może zawierać tylko cyfry.");
                    return false;
                }
            }
            return true;
        }

        private void generateKeys()
        {
            int p = Int32.Parse(pTextBox.Text);
            int q = Int32.Parse(qTextBox.Text);
            PrivatePublicKey keys = KeyGenerator.generate(p, q);

            nTextBox.Text = keys.PrivateKey.n.ToString();
            privateNTextBox.Text = nTextBox.Text;
            eTextBox.Text = keys.PublicKey.key.ToString();
            dTextBox.Text = keys.PrivateKey.key.ToString();
        }

        private void generatePrimes()
        {
            Random random = new Random();
            int p, q;
            p = RandomPrimeGenerator.generate(minPrimeValue, maxPrimeValue, random);
            do
            {
                q = RandomPrimeGenerator.generate(minPrimeValue, maxPrimeValue, random);
            } while (p == q);


            pTextBox.Text = p.ToString();
            qTextBox.Text = q.ToString();
        }
    }
}
