

using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

public class frmMain: System.Windows.Forms.Form {

	static object missing = Missing.Value;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		System.Windows.Forms.Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

    public frmMain () {

        //This call is required by the Windows Form Designer.

        InitializeComponent();

        //Add any initialization after the InitializeComponent() call
        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.

        AssemblyInfo ainfo = new AssemblyInfo();

        this.Text = ainfo.Title;

        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

    }

    //Form overrides dispose to clean up the component list.

    protected override void Dispose(bool disposing) {

        if (disposing) {
            if (components != null) {
                components.Dispose();
            }
        }

        base.Dispose(disposing);

    }

    //Required by the Windows Form Designer

    private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    private System.Windows.Forms.MainMenu mnuMain;
    private System.Windows.Forms.MenuItem mnuFile;
    private System.Windows.Forms.MenuItem mnuExit;
    private System.Windows.Forms.MenuItem mnuHelp;
    private System.Windows.Forms.MenuItem mnuAbout;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.Button btnSpeak;
    private System.Windows.Forms.GroupBox GroupBox1;
    private System.Windows.Forms.OpenFileDialog dlgOpenWordFile;
    private System.Windows.Forms.Button btnBrowseWord;
    private System.Windows.Forms.Button btnSpellCheck;
    private System.Windows.Forms.Button btnGetMenu;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.TabControl tabOfficeDemo;
    private System.Windows.Forms.RadioButton optDontRecognize;
    private System.Windows.Forms.RadioButton optWrite;
    private System.Windows.Forms.RadioButton optWave;
    private System.Windows.Forms.RadioButton optApplaud;
    private System.Windows.Forms.RadioButton optSurprised;
    private System.Windows.Forms.RadioButton optSuggest;
    private System.Windows.Forms.RadioButton optAnnounce;
    private System.Windows.Forms.RadioButton optDoMagic;
    private System.Windows.Forms.RadioButton optExplain;
    private System.Windows.Forms.RadioButton optCongrats;
    private System.Windows.Forms.TextBox txtSpeak;
    private System.Windows.Forms.CheckBox chkMerlinHide;
    private System.Windows.Forms.RichTextBox rtfDocument;
    private System.Windows.Forms.DataGrid grdMenu;
    private System.Windows.Forms.TabPage pgeWizard;
    private System.Windows.Forms.TabPage pgeWord;
    private System.Windows.Forms.TabPage pgeExcel;

    private void InitializeComponent() {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
        this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
        this.mnuFile = new System.Windows.Forms.MenuItem();
        this.mnuExit = new System.Windows.Forms.MenuItem();
        this.mnuHelp = new System.Windows.Forms.MenuItem();
        this.mnuAbout = new System.Windows.Forms.MenuItem();
        this.tabOfficeDemo = new System.Windows.Forms.TabControl();
        this.pgeWizard = new System.Windows.Forms.TabPage();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.optDontRecognize = new System.Windows.Forms.RadioButton();
        this.optWrite = new System.Windows.Forms.RadioButton();
        this.optWave = new System.Windows.Forms.RadioButton();
        this.optApplaud = new System.Windows.Forms.RadioButton();
        this.optSurprised = new System.Windows.Forms.RadioButton();
        this.optSuggest = new System.Windows.Forms.RadioButton();
        this.optAnnounce = new System.Windows.Forms.RadioButton();
        this.optDoMagic = new System.Windows.Forms.RadioButton();
        this.optExplain = new System.Windows.Forms.RadioButton();
        this.optCongrats = new System.Windows.Forms.RadioButton();
        this.btnSpeak = new System.Windows.Forms.Button();
        this.txtSpeak = new System.Windows.Forms.TextBox();
        this.Label2 = new System.Windows.Forms.Label();
        this.pgeWord = new System.Windows.Forms.TabPage();
        this.btnSpellCheck = new System.Windows.Forms.Button();
        this.rtfDocument = new System.Windows.Forms.RichTextBox();
        this.btnBrowseWord = new System.Windows.Forms.Button();
        this.pgeExcel = new System.Windows.Forms.TabPage();
        this.btnExport = new System.Windows.Forms.Button();
        this.btnGetMenu = new System.Windows.Forms.Button();
        this.grdMenu = new System.Windows.Forms.DataGrid();
        this.dlgOpenWordFile = new System.Windows.Forms.OpenFileDialog();
        this.chkMerlinHide = new System.Windows.Forms.CheckBox();
        this.tabOfficeDemo.SuspendLayout();
        this.pgeWizard.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.pgeWord.SuspendLayout();
        this.pgeExcel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grdMenu)).BeginInit();
        this.SuspendLayout();
        // 
        // mnuMain
        // 
        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuHelp});
        // 
        // mnuFile
        // 
        this.mnuFile.Index = 0;
        this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuExit});
        resources.ApplyResources(this.mnuFile, "mnuFile");
        // 
        // mnuExit
        // 
        this.mnuExit.Index = 0;
        resources.ApplyResources(this.mnuExit, "mnuExit");
        this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
        // 
        // mnuHelp
        // 
        this.mnuHelp.Index = 1;
        this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout});
        resources.ApplyResources(this.mnuHelp, "mnuHelp");
        // 
        // mnuAbout
        // 
        this.mnuAbout.Index = 0;
        resources.ApplyResources(this.mnuAbout, "mnuAbout");
        this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
        // 
        // tabOfficeDemo
        // 
        resources.ApplyResources(this.tabOfficeDemo, "tabOfficeDemo");
        this.tabOfficeDemo.Controls.Add(this.pgeWizard);
        this.tabOfficeDemo.Controls.Add(this.pgeWord);
        this.tabOfficeDemo.Controls.Add(this.pgeExcel);
        this.tabOfficeDemo.Name = "tabOfficeDemo";
        this.tabOfficeDemo.SelectedIndex = 0;
        // 
        // pgeWizard
        // 
        resources.ApplyResources(this.pgeWizard, "pgeWizard");
        this.pgeWizard.BackColor = System.Drawing.SystemColors.Control;
        this.pgeWizard.Controls.Add(this.GroupBox1);
        this.pgeWizard.Controls.Add(this.btnSpeak);
        this.pgeWizard.Controls.Add(this.txtSpeak);
        this.pgeWizard.Controls.Add(this.Label2);
        this.pgeWizard.Name = "pgeWizard";
        // 
        // GroupBox1
        // 
        resources.ApplyResources(this.GroupBox1, "GroupBox1");
        this.GroupBox1.Controls.Add(this.optDontRecognize);
        this.GroupBox1.Controls.Add(this.optWrite);
        this.GroupBox1.Controls.Add(this.optWave);
        this.GroupBox1.Controls.Add(this.optApplaud);
        this.GroupBox1.Controls.Add(this.optSurprised);
        this.GroupBox1.Controls.Add(this.optSuggest);
        this.GroupBox1.Controls.Add(this.optAnnounce);
        this.GroupBox1.Controls.Add(this.optDoMagic);
        this.GroupBox1.Controls.Add(this.optExplain);
        this.GroupBox1.Controls.Add(this.optCongrats);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.TabStop = false;
        // 
        // optDontRecognize
        // 
        resources.ApplyResources(this.optDontRecognize, "optDontRecognize");
        this.optDontRecognize.Name = "optDontRecognize";
        this.optDontRecognize.Tag = "DontRecognize";
        this.optDontRecognize.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optWrite
        // 
        resources.ApplyResources(this.optWrite, "optWrite");
        this.optWrite.Name = "optWrite";
        this.optWrite.Tag = "Write";
        this.optWrite.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optWave
        // 
        resources.ApplyResources(this.optWave, "optWave");
        this.optWave.Name = "optWave";
        this.optWave.Tag = "Wave";
        this.optWave.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optApplaud
        // 
        resources.ApplyResources(this.optApplaud, "optApplaud");
        this.optApplaud.Name = "optApplaud";
        this.optApplaud.Tag = "Applaud";
        this.optApplaud.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optSurprised
        // 
        resources.ApplyResources(this.optSurprised, "optSurprised");
        this.optSurprised.Name = "optSurprised";
        this.optSurprised.Tag = "Surprised";
        this.optSurprised.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optSuggest
        // 
        resources.ApplyResources(this.optSuggest, "optSuggest");
        this.optSuggest.Name = "optSuggest";
        this.optSuggest.Tag = "Suggest";
        this.optSuggest.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optAnnounce
        // 
        resources.ApplyResources(this.optAnnounce, "optAnnounce");
        this.optAnnounce.Name = "optAnnounce";
        this.optAnnounce.Tag = "Announce";
        this.optAnnounce.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optDoMagic
        // 
        resources.ApplyResources(this.optDoMagic, "optDoMagic");
        this.optDoMagic.Name = "optDoMagic";
        this.optDoMagic.Tag = "GetAttention";
        this.optDoMagic.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optExplain
        // 
        resources.ApplyResources(this.optExplain, "optExplain");
        this.optExplain.Name = "optExplain";
        this.optExplain.Tag = "Explain";
        this.optExplain.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // optCongrats
        // 
        resources.ApplyResources(this.optCongrats, "optCongrats");
        this.optCongrats.Name = "optCongrats";
        this.optCongrats.Tag = "Congratulate";
        this.optCongrats.Click += new System.EventHandler(this.rdoAnimations_Click);
        // 
        // btnSpeak
        // 
        resources.ApplyResources(this.btnSpeak, "btnSpeak");
        this.btnSpeak.BackColor = System.Drawing.SystemColors.Control;
        this.btnSpeak.Name = "btnSpeak";
        this.btnSpeak.UseVisualStyleBackColor = false;
        this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
        // 
        // txtSpeak
        // 
        resources.ApplyResources(this.txtSpeak, "txtSpeak");
        this.txtSpeak.Name = "txtSpeak";
        // 
        // Label2
        // 
        resources.ApplyResources(this.Label2, "Label2");
        this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label2.Name = "Label2";
        // 
        // pgeWord
        // 
        resources.ApplyResources(this.pgeWord, "pgeWord");
        this.pgeWord.BackColor = System.Drawing.SystemColors.Control;
        this.pgeWord.Controls.Add(this.btnSpellCheck);
        this.pgeWord.Controls.Add(this.rtfDocument);
        this.pgeWord.Controls.Add(this.btnBrowseWord);
        this.pgeWord.Name = "pgeWord";
        // 
        // btnSpellCheck
        // 
        resources.ApplyResources(this.btnSpellCheck, "btnSpellCheck");
        this.btnSpellCheck.BackColor = System.Drawing.SystemColors.Control;
        this.btnSpellCheck.Name = "btnSpellCheck";
        this.btnSpellCheck.UseVisualStyleBackColor = false;
        this.btnSpellCheck.Click += new System.EventHandler(this.btnSpellCheck_Click);
        // 
        // rtfDocument
        // 
        resources.ApplyResources(this.rtfDocument, "rtfDocument");
        this.rtfDocument.Name = "rtfDocument";
        // 
        // btnBrowseWord
        // 
        resources.ApplyResources(this.btnBrowseWord, "btnBrowseWord");
        this.btnBrowseWord.BackColor = System.Drawing.SystemColors.Control;
        this.btnBrowseWord.Name = "btnBrowseWord";
        this.btnBrowseWord.UseVisualStyleBackColor = false;
        this.btnBrowseWord.Click += new System.EventHandler(this.btnBrowseWord_Click);
        // 
        // pgeExcel
        // 
        resources.ApplyResources(this.pgeExcel, "pgeExcel");
        this.pgeExcel.BackColor = System.Drawing.SystemColors.Control;
        this.pgeExcel.Controls.Add(this.btnExport);
        this.pgeExcel.Controls.Add(this.btnGetMenu);
        this.pgeExcel.Controls.Add(this.grdMenu);
        this.pgeExcel.Name = "pgeExcel";
        // 
        // btnExport
        // 
        resources.ApplyResources(this.btnExport, "btnExport");
        this.btnExport.BackColor = System.Drawing.SystemColors.Control;
        this.btnExport.Name = "btnExport";
        this.btnExport.UseVisualStyleBackColor = false;
        this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
        // 
        // btnGetMenu
        // 
        resources.ApplyResources(this.btnGetMenu, "btnGetMenu");
        this.btnGetMenu.BackColor = System.Drawing.SystemColors.Control;
        this.btnGetMenu.Name = "btnGetMenu";
        this.btnGetMenu.UseVisualStyleBackColor = false;
        this.btnGetMenu.Click += new System.EventHandler(this.btnGetMenu_Click);
        // 
        // grdMenu
        // 
        resources.ApplyResources(this.grdMenu, "grdMenu");
        this.grdMenu.AlternatingBackColor = System.Drawing.Color.Lavender;
        this.grdMenu.BackColor = System.Drawing.Color.WhiteSmoke;
        this.grdMenu.BackgroundColor = System.Drawing.Color.LightGray;
        this.grdMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.grdMenu.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
        this.grdMenu.CaptionForeColor = System.Drawing.Color.MidnightBlue;
        this.grdMenu.DataMember = "";
        this.grdMenu.FlatMode = true;
        this.grdMenu.ForeColor = System.Drawing.Color.MidnightBlue;
        this.grdMenu.GridLineColor = System.Drawing.Color.Gainsboro;
        this.grdMenu.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
        this.grdMenu.HeaderBackColor = System.Drawing.Color.MidnightBlue;
        this.grdMenu.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
        this.grdMenu.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
        this.grdMenu.LinkColor = System.Drawing.Color.Teal;
        this.grdMenu.Name = "grdMenu";
        this.grdMenu.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
        this.grdMenu.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
        this.grdMenu.SelectionBackColor = System.Drawing.Color.CadetBlue;
        this.grdMenu.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
        // 
        // chkMerlinHide
        // 
        resources.ApplyResources(this.chkMerlinHide, "chkMerlinHide");
        this.chkMerlinHide.Name = "chkMerlinHide";
        this.chkMerlinHide.CheckedChanged += new System.EventHandler(this.chkMerlinOnOff_CheckedChanged);
        // 
        // frmMain
        // 
        resources.ApplyResources(this, "$this");
        this.Controls.Add(this.chkMerlinHide);
        this.Controls.Add(this.tabOfficeDemo);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Menu = this.mnuMain;
        this.Name = "frmMain";
        this.Load += new System.EventHandler(this.frmMain_Load);
        this.tabOfficeDemo.ResumeLayout(false);
        this.pgeWizard.ResumeLayout(false);
        this.pgeWizard.PerformLayout();
        this.GroupBox1.ResumeLayout(false);
        this.pgeWord.ResumeLayout(false);
        this.pgeExcel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.grdMenu)).EndInit();
        this.ResumeLayout(false);

    }

#endregion

#region " Standard Menu Code "

    // This code simply shows the About form.

    private void mnuAbout_Click(object sender, System.EventArgs e) {

        // Open the About form in Dialog Mode

        frmAbout frm = new frmAbout();

        frm.ShowDialog(this);

        frm.Dispose();

    }

    // This code will close the form.

    private void mnuExit_Click(object sender, System.EventArgs e) {

        // Close the current form

        this.Close();

    }

#endregion


    private DataSet dsMenu;
    private bool styleAlreadyExists = false;

    // the Browse button on the Word tab which allows the user to find a
    // Text Format document on their hard drive and load it
    // into the RichTextBox control.

    private void btnBrowseWord_Click(object sender, System.EventArgs e) 
	{

            dlgOpenWordFile.InitialDirectory = @"C:\";
            dlgOpenWordFile.Filter = "Text Format (*.txt)|*.txt";
            dlgOpenWordFile.FilterIndex = 1;

            // The OpenFileDialog control only has an Open button, not an OK button.
            // However, there is no DialogResult.Open enum so use DialogResult.OK.
            if (dlgOpenWordFile.ShowDialog() == DialogResult.OK) 
				{
                try 
				{
                    rtfDocument.LoadFile(dlgOpenWordFile.FileName, RichTextBoxStreamType.PlainText);
               } 
				catch
				{
                    MessageBox.Show("The document you are attempting to load " +
                        "is not in the correct format.", "Document Load Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
    }

    // the "Export to Excel >>" button click event, which allows the user to
    // export the contents of the Dataset to an Excel spreadsheet and then run a
    // simple Average function to determine the calorie average for all the foods.

    private void btnExport_Click(object sender, System.EventArgs e) 
		{

        // An Excel spreadsheet involves a hierarchy of objects, from Application
       // to Workbook to Worksheet.
        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)excelBook.Worksheets.get_Item(1);


        

        // Unlike the Word demo, we'll make the spreadsheet visible so you can see
        // the data being entered.
        excelApp.Visible = true;

            // Set the column headers and desired formatting for the spreadsheet.
            excelWorksheet.Columns.ColumnWidth = 21.71;
			excelWorksheet.get_Range("A1",missing).Value2 = "Item";
            excelWorksheet.get_Range("A1",missing).Font.Bold = true;
            excelWorksheet.get_Range("B1",missing).Value2 = "Price";
            excelWorksheet.get_Range("B1",missing).Font.Bold = true;
            excelWorksheet.get_Range("C1",missing).Value2 = "Calories";
            excelWorksheet.get_Range("C1",missing).Font.Bold = true;

            // Start the counter on the second row, following the column headers
            int i = 2;

            // Loop through the Rows collection of the Dataset and write the data
            // in each row to the cells in Excel. 

            foreach(DataRow dr in dsMenu.Tables[0].Rows)
			{
                excelWorksheet.get_Range("A" + i.ToString(),missing).Value2 = dr["Item"].ToString();
                excelWorksheet.get_Range("B" + i.ToString(),missing).Value2 = dr["Price"].ToString();
                excelWorksheet.get_Range("C" + i.ToString(),missing).Value2 = dr["Calories"].ToString();
                i += 1;
            }

            // Select and apply formatting to the cell that will display the calorie
            // average, then call the Average formula.
            excelWorksheet.get_Range("C7",missing).Select();
            excelWorksheet.get_Range("C7",missing).Font.Color = Color.FromArgb(255, 0, 0);
            excelWorksheet.get_Range("C7",missing).Font.Bold = true;
            excelApp.ActiveCell.FormulaR1C1 = "=AVERAGE(R[-5]C:R[-1]C)";     

    }

    // the "get {Menu" button click event, which creates and fills a DataSet
    // from an XML document, loads it into a DataGrid, and then applies custom
    // formatting to the DataGrid.

    private void btnGetMenu_Click(object sender, System.EventArgs e) 
	{

        // Fill a Dataset by loading an XML document with items from a fictitious 
        // lunch menu.

        dsMenu = new DataSet();
        dsMenu.ReadXml(System.Windows.Forms.Application.ExecutablePath + "..\\..\\..\\..\\menu.xml");

        // Set the DataGrid caption and bind it to the DataSet.

        grdMenu.CaptionText = "Today's Menu";
        grdMenu.DataSource = dsMenu.Tables[0];

        // Use a table style object to apply custom formatting to the DataGrid.
        // Only create this style the first time the data is loaded.

        if (!styleAlreadyExists) {
            DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();

                grdTableStyle1.AlternatingBackColor = Color.Lavender;
                grdTableStyle1.BackColor = Color.WhiteSmoke;
                grdTableStyle1.ForeColor = Color.MidnightBlue;
                grdTableStyle1.GridLineColor = Color.Gainsboro;
                grdTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
                grdTableStyle1.HeaderBackColor = Color.MidnightBlue;
                grdTableStyle1.HeaderFont = new System.Drawing.Font("Tahoma", (float)8.0, FontStyle.Bold);
                grdTableStyle1.HeaderForeColor = Color.WhiteSmoke;
                grdTableStyle1.LinkColor = Color.Teal;
                // Do not forget to set the MappingName property. 
                // Without this, the DataGridTableStyle properties
                // and any associated DataGridColumnStyle objects
                // will have no effect.
                grdTableStyle1.MappingName = "Food";
                grdTableStyle1.SelectionBackColor = Color.CadetBlue;
                grdTableStyle1.SelectionForeColor = Color.WhiteSmoke;
            
            // Use column style objects to apply formatting specific to each column.
            DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();
            grdColStyle1.HeaderText = "Item";
            grdColStyle1.MappingName = "Item";
            grdColStyle1.Width = 125;
            DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();

                grdColStyle2.HeaderText = "Price";
                grdColStyle2.MappingName = "Price";
                grdColStyle2.Width = 50;
            
            DataGridTextBoxColumn grdColStyle3 = new DataGridTextBoxColumn();

                grdColStyle3.HeaderText = "Calories";
                grdColStyle3.MappingName = "Calories";
                grdColStyle3.Width = 70;

            // Add the column style objects to the tables style's column styles 
            // collection. if you fail to do this the column styles will not apply.

            grdTableStyle1.GridColumnStyles.AddRange (new DataGridColumnStyle[]
                {grdColStyle1, grdColStyle2, grdColStyle3});

            // Again, failure to add the style to the collection will cause the style
            // to not take effect.

            grdMenu.TableStyles.Add(grdTableStyle1);
            styleAlreadyExists = true;
        }

        // Now that the DataGrid is filled it is appropriate to show the button
        // that will allow the user to export the contents of the Dataset to 
        // an Excel spreadsheet.
        btnExport.Visible = true;
    }

    // the Speak button click event, which makes Merlin say whatever the
    // user enters into the TextBox.
    private void btnSpeak_Click(object sender, System.EventArgs e) 
	{

    }

    // the Spellcheck button click event, allowing the user to run the Word
    // spellchecker against whatever text is in the RichTextBox control. Notice that
    // Word never needs to be seen.
    //
    // This method simply displays a dialog box.  However you could also leverage 
    // this functionality to create a more feature  rich application that mimics the
    // Word spell checker (allows the use of custom dictionaries etc.)
    private void btnSpellCheck_Click(object sender, System.EventArgs e) 
	{
        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
    
        bool  bolHasNoSpellingErrors = wordApp.CheckSpelling(rtfDocument.Text,
			ref missing, ref missing, ref missing, ref missing, ref missing,
			ref missing, ref missing, ref missing, ref missing, ref missing,
			ref missing, ref missing);
        string strSpellCheck = "Your document has spelling errors.";

        if (bolHasNoSpellingErrors) {
            strSpellCheck = "Congratulations, your document " +
                "is free of spelling errors.";
        }

        MessageBox.Show(strSpellCheck, "Spell Check Results", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);

    }

    // the CheckChanged event for the checkbox that hides or shows Merlin.

    private void chkMerlinOnOff_CheckedChanged(object sender, System.EventArgs e) 
	{



    }

    // the Form load event, which fires when the form is first loaded.

    private void frmMain_Load(object sender, System.EventArgs e) {

        // The Agent object is used to open a connection to the Agent server,
        // load the character, and then associate the character with the 
        // variable referencing the IAgentCtlCharacter interface. From then
        // on you program against the agentCharacter.


        
        // Use the Location property to place Merlin relative to the upper left 
        // corner of the Form. 


            // You can make Merlin's speech sound more natural by inserting speech
            // output tags like Pau (Pause), Chr (Character of the Voice), 
            // Emp (Emphasis) or Spd (Speed). Surround each name-value pair with a
            // backslash character. 

        
        // Hide the "Export to Excel>>" Button on the Excel tab until the 
        // DataGrid is databound.

        btnExport.Visible = false;

    }

    // the click events of all the Merlin animations.

    private void rdoAnimations_Click(object sender, System.EventArgs e) 
		//optDontRecognize.Click, optWrite.Click, optWave.Click, optApplaud.Click, optSurprised.Click, optSuggest.Click, optAnnounce.Click, optDoMagic.Click, optExplain.Click, optCongrats.Click;
	{
      

        

    }

    // the TabControl's SelectedIndexChanged event, which fires when either
    // the Word or Excel tabs are clicked. This moves Merlin out of the way of the
    // user interface elements on these two tabs.

    private void tabOfficeDemo_SelectedIndexChanged(object sender, System.EventArgs e) 
		//tabOfficeDemo.SelectedIndexChanged;
	{
        

    }

}

