﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace Notatnik
{
    public partial class Form1 : Form
    {
        public string filePath = Path.GetTempPath() + "null.txt";
        private string[] lines;
        private int printedLines;

        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Font = Properties.Settings.Default.Czcionka;
            richTextBox1.BackColor = Properties.Settings.Default.Tlo;
            richTextBox1.ForeColor = Properties.Settings.Default.KolorCzcionki;
            richTextBox1.WordWrap = Properties.Settings.Default.ZawijanieWierszy;
            zawijanieWierszyToolStripMenuItem.Checked = Properties.Settings.Default.ZawijanieWierszy;
            this.Size = Properties.Settings.Default.FormSize;
            wytnijToolStripMenuItem.Enabled = false;
            kopiujToolStripMenuItem.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            
            if(NetworkInterface.GetIsNetworkAvailable())
                checkUpdate();
        }

        public void openFile_FromExplorer(String[] file) { 
            filePath = file[0];
            openFile(true);
        }

        #region Zmiany kolorów przycisków
        private void button1_MouseEnter(object sender, EventArgs e) { button1.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button1_MouseLeave(object sender, EventArgs e) { button1.ForeColor = Color.White; }
        private void button2_MouseEnter(object sender, EventArgs e) { button2.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button2_MouseLeave(object sender, EventArgs e) { button2.ForeColor = Color.White; }
        private void button3_MouseEnter(object sender, EventArgs e) { button3.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button3_MouseLeave(object sender, EventArgs e) { button3.ForeColor = Color.White; }
        private void button4_MouseEnter(object sender, EventArgs e) { button4.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button4_MouseLeave(object sender, EventArgs e) { button4.ForeColor = Color.White; }
        private void button5_MouseEnter(object sender, EventArgs e) { button5.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button5_MouseLeave(object sender, EventArgs e) { button5.ForeColor = Color.White; }
        private void button6_MouseEnter(object sender, EventArgs e) { button6.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button6_MouseLeave(object sender, EventArgs e) { button6.ForeColor = Color.White; }
        private void button7_MouseEnter(object sender, EventArgs e) { button7.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button7_MouseLeave(object sender, EventArgs e) { button7.ForeColor = Color.White; }
        private void button8_MouseEnter(object sender, EventArgs e) { button8.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button8_MouseLeave(object sender, EventArgs e) { button8.ForeColor = Color.White; }
        private void button9_MouseEnter(object sender, EventArgs e) { button9.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button9_MouseLeave(object sender, EventArgs e) { button9.ForeColor = Color.White; }
        private void button10_MouseEnter(object sender, EventArgs e) { button10.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button10_MouseLeave(object sender, EventArgs e) { button10.ForeColor = Color.White; }
        private void button11_MouseEnter(object sender, EventArgs e) { button11.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button11_MouseLeave(object sender, EventArgs e) { button11.ForeColor = Color.White; }
        private void button12_MouseEnter(object sender, EventArgs e) { button12.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button12_MouseLeave(object sender, EventArgs e) { button12.ForeColor = Color.White; }
        private void button13_MouseEnter(object sender, EventArgs e) { button13.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button13_MouseLeave(object sender, EventArgs e) { button13.ForeColor = Color.White; }
        private void button14_MouseEnter(object sender, EventArgs e) { button14.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button14_MouseLeave(object sender, EventArgs e) { button14.ForeColor = Color.White; }
        private void button15_MouseEnter(object sender, EventArgs e) { button15.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button15_MouseLeave(object sender, EventArgs e) { button15.ForeColor = Color.White; }
        private void button16_MouseEnter(object sender, EventArgs e) { button16.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button16_MouseLeave(object sender, EventArgs e) { button16.ForeColor = Color.White; }
        private void button17_MouseEnter(object sender, EventArgs e) { button17.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button17_MouseLeave(object sender, EventArgs e) { button17.ForeColor = Color.White; }
        private void button18_MouseEnter(object sender, EventArgs e) { button18.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button18_MouseLeave(object sender, EventArgs e) { button18.ForeColor = Color.White; }
        private void button19_MouseEnter(object sender, EventArgs e) { button19.ForeColor = Color.FromArgb(40, 167, 69); }
        private void button19_MouseLeave(object sender, EventArgs e) { button19.ForeColor = Color.White; }
        #endregion
        #region Drukowanie
        private void printIt(object sender, EventArgs e)
        {
            if(richTextBox1.ForeColor != Color.Black)
            {
                MessageBox.Show("UWAGA! Czcionka w drukowanym dokumencie będzie miała kolor głównej czcionki, a tło dalej pozostaje białe. Dla najlepszej jakości wydruku zmień kolor czcionki na czarny, jeżeli dokument będzie drukowany na białej kartce.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (printDialog1.ShowDialog() == DialogResult.OK)
                        printDocument1.Print();
            } else
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
            }
        }

        private void beginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            char[] param = { '\n' };
            char[] trimParam = { '\r' };
            int i = 0;

            if (printDialog1.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.Selection)
                lines = richTextBox1.SelectedText.Split(param);
            else
                lines = richTextBox1.Text.Split(param);

            foreach (string s in lines)
                lines[i++] = s.TrimEnd(trimParam);
        }

        private void printPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(richTextBox1.ForeColor);

            while (printedLines < lines.Length)
            {
                e.Graphics.DrawString(lines[printedLines++], richTextBox1.Font, brush, x, y);
                y += richTextBox1.Font.Size * 1.2f;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            printedLines = 0;
            e.HasMorePages = false;
        }
        #endregion
        #region Zadania
        void newFile()
        {
            TextReader textReader = new StreamReader(filePath);
            if (filePath != Path.GetTempPath() + "null.txt" && richTextBox1.Text == "")
            {
                if (richTextBox1.Text == textReader.ReadToEnd())
                {
                    this.Text = "Bez tytułu - Notatnik";
                    richTextBox1.Text = "";
                    filePath = Path.GetTempPath() + "null.txt";
                }
                else
                {
                    if (MessageBox.Show("W tym pliku zostały wprowadzone zmiany. Czy chcesz je zapisać", "Notatnik", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (filePath == Path.GetTempPath() + "null.txt")
                            saveAsFile();
                        else
                            saveFile();
                        this.Text = "Bez tytułu - Notatnik";
                        richTextBox1.Text = "";
                        filePath = Path.GetTempPath() + "null.txt";
                    }
                    else
                    {
                        this.Text = "Bez tytułu - Notatnik";
                        richTextBox1.Text = "";
                        filePath = Path.GetTempPath() + "null.txt";
                    }
                }
            } else
            {
                this.Text = "Bez tytułu - Notatnik";
                richTextBox1.Text = "";
                filePath = Path.GetTempPath() + "null.txt";
            }
        }

        void openFile(bool fromCmd)
        {
            if (fromCmd)
            {
                this.Text = filePath + " - Notatnik";
                StreamReader streamReader = new StreamReader(filePath);
                richTextBox1.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog1.FileName;
                    this.Text = openFileDialog1.FileName + " - Notatnik";

                    var fileStream = openFileDialog1.OpenFile();
                    TextReader textReader = new StreamReader(fileStream);
                    richTextBox1.Text = textReader.ReadToEnd();
                }
                toolStripStatusLabel1.Text = "Otwarto plik " + openFileDialog1.FileName + "!";
            }
        }

        void saveFile()
        {
            TextWriter textWriter = new StreamWriter(filePath);
            textWriter.Write(richTextBox1.Text);
            textWriter.Close();
            toolStripStatusLabel1.Text = "Zapisano!";
        }

        void saveAsFile()
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
                saveFile();
                this.Text = saveFileDialog1.FileName + " - Notatnik";
            }
            toolStripStatusLabel1.Text = "Zapisano!";
        }

        void copySelected()
        {
            richTextBox1.Copy();
            toolStripStatusLabel1.Text = "Skopiowano!";
        }

        void pasteText() { richTextBox1.Paste(); }

        void cutSelected()
        {
            richTextBox1.Cut();
            toolStripStatusLabel1.Text = "Wycięto!";
        }

        void undoChanges() { richTextBox1.Undo(); }

        void redoChanges() { richTextBox1.Redo(); }

        void changeFontColor()
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText.Length == 0 | richTextBox1.SelectedText.Length == richTextBox1.Text.Length)
                {
                    richTextBox1.ForeColor = colorDialog1.Color;
                    Properties.Settings.Default.KolorCzcionki = colorDialog1.Color;
                    Properties.Settings.Default.Save();
                }
                else
                    richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        void changeBackgroundColor()
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = colorDialog2.Color;

            Properties.Settings.Default.Tlo = colorDialog2.Color;
            Properties.Settings.Default.Save();
        }

        void boldText()
        {
            if (richTextBox1.SelectedText.Length == 0 | richTextBox1.SelectedText.Length == richTextBox1.Text.Length)
            {
                if (!richTextBox1.Font.Bold)
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold);
                else
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
            }
            else
            {
                if (!richTextBox1.Font.Bold)
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                else
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            }
        }

        void italicText()
        {
            if (richTextBox1.SelectedText.Length == 0 | richTextBox1.SelectedText.Length == richTextBox1.Text.Length)
            {
                if (!richTextBox1.Font.Italic)
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic);
                else
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
            }
            else
            {
                if (!richTextBox1.Font.Italic)
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
                else
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            }
        }

        void underlineText()
        {
            if (richTextBox1.SelectedText.Length == 0 | richTextBox1.SelectedText.Length == richTextBox1.Text.Length)
            {
                if (!richTextBox1.Font.Underline)
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Underline);
                else
                    richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
            }
            else
            {
                if (!richTextBox1.Font.Underline)
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
                else
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            }
        }

        #endregion
        #region Skrypty odpowiadające za przyciski
        private void button1_Click(object sender, EventArgs e) { newFile(); }
        private void button2_Click(object sender, EventArgs e) { openFile(false); }
        private void button3_Click(object sender, EventArgs e)
        {
            if (filePath == Path.GetTempPath() + "null.txt")
                saveAsFile();
            else
                saveFile();
        }
        private void button4_Click(object sender, EventArgs e) { saveAsFile(); }
        private void button6_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = Properties.Settings.Default.Czcionka;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
                Properties.Settings.Default.Czcionka = fontDialog1.Font;
                Properties.Settings.Default.Save();
            }
        }
        private void button7_Click(object sender, EventArgs e) { printPreviewDialog1.ShowDialog(); }
        private void button8_Click(object sender, EventArgs e) { copySelected(); }
        private void button9_Click(object sender, EventArgs e) { cutSelected(); }
        private void button10_Click(object sender, EventArgs e) { pasteText(); }
        private void button11_Click(object sender, EventArgs e) { undoChanges(); }
        private void button12_Click(object sender, EventArgs e) { redoChanges(); }
        private void button13_Click(object sender, EventArgs e) { changeFontColor(); panel3.Visible = false; }
        private void button14_Click(object sender, EventArgs e) { changeBackgroundColor(); panel3.Visible = false; }
        private void button15_Click(object sender, EventArgs e) { underlineText(); panel3.Visible = false; }
        private void button16_Click(object sender, EventArgs e) { italicText(); panel3.Visible = false; }
        private void button17_Click(object sender, EventArgs e) { boldText(); panel3.Visible = false; }
        private void button18_Click(object sender, EventArgs e)
        {
            if (!panel3.Visible)
                panel3.Visible = true;
            else
                panel3.Visible = false;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
            panel3.Visible = false;
        }
        #endregion
        #region Skrypty ToolStripa
        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e) { copySelected(); }
        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e) { cutSelected(); }
        private void wklejToolStripMenuItem_Click(object sender, EventArgs e) { pasteText(); }
        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e) { undoChanges(); }
        private void przywrócToolStripMenuItem_Click(object sender, EventArgs e) { redoChanges(); }
        private void zmieńKolorTłaToolStripMenuItem_Click(object sender, EventArgs e) { changeBackgroundColor(); }
        private void zmieńKolorCzcionkiToolStripMenuItem_Click(object sender, EventArgs e) { changeFontColor(); }
        private void pogrubienieToolStripMenuItem_Click(object sender, EventArgs e) { boldText(); }
        private void kursywaToolStripMenuItem_Click(object sender, EventArgs e) { italicText(); }
        private void podkreślenieToolStripMenuItem_Click(object sender, EventArgs e) { underlineText(); }
        private void informacjeOProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }
        private void nowyDokumentToolStripMenuItem_Click(object sender, EventArgs e) { newFile(); }
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath == Path.GetTempPath() + "null.txt")
                saveAsFile();
            else
                saveFile();
        }
        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e) { saveAsFile(); }
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e) { openFile(false); }
        private void drukujToolStripMenuItem_Click(object sender, EventArgs e) { printPreviewDialog1.ShowDialog(); }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\updater.exe"))
            {
                Process.Start("updater.exe");
                this.Close();
            }
            else
            {
                if (MessageBox.Show("Nie posiadasz programu do aktualizacji Notatnika. Być może dlatego, że jest to wersja Portable lub plik \"updater.exe\" został usunięty.", "Nie ma pliku updater.exe!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Process.Start("https://github.com/KrzysiekSiemv/Notepad/releases");
                }
            }
        }
        private void zawijanieWierszyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.WordWrap)
            {
                richTextBox1.WordWrap = true;
                Properties.Settings.Default.ZawijanieWierszy = true;
                Properties.Settings.Default.Save();
                zawijanieWierszyToolStripMenuItem.Checked = true;
            }
            else
            {
                richTextBox1.WordWrap = false;
                Properties.Settings.Default.ZawijanieWierszy = false;
                Properties.Settings.Default.Save();
                zawijanieWierszyToolStripMenuItem.Checked = false;
            }
        }
        #endregion

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FormSize = this.Size;
            Properties.Settings.Default.Save();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText.Length != 0)
            {
                wytnijToolStripMenuItem.Enabled = true;
                kopiujToolStripMenuItem.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
            else
            {
                wytnijToolStripMenuItem.Enabled = false;
                kopiujToolStripMenuItem.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { toolStripStatusLabel1.Text = "Liczba znaków: " + richTextBox1.TextLength; }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                if (MessageBox.Show("Czy chcesz zapisać plik?", "Notatnik", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (filePath == Path.GetTempPath() + "null.txt")
                        saveAsFile();
                    else
                        saveFile();
                }
            } 
        }

        void checkUpdate()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string urlVersion = "https://raw.githubusercontent.com/KrzysiekSiemv/Notepad/main/update/version";
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(urlVersion);

            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadLine();

            if(Application.ProductVersion != content)
            {
                toolStripStatusLabel1.Text = "Jest dostępna nowa wersja! Jeżeli chcesz zainstalować, wybierz w Context Menu: Pobierz update!";
                statusStrip1.BackColor = Color.FromArgb(255, 202, 81, 0);
                updateToolStripMenuItem.Visible = true;
            }
        }
    }
}
