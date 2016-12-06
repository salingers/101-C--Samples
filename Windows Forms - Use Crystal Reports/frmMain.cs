
using System.Data;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    protected const string MSDE_SERVER  = @"(local)\VSdotNET";

    protected const string SQL_CONNECTION_STRING  =	"Server=localhost;" + 
													"DataBase=Northwind;" + 
													"Integrated Security=SSPI;Connect Timeout=5";

    protected const string MSDE_CONNECTION_STRING  = "Server=" + MSDE_SERVER + ";" + 
													 "DataBase=Northwind;" + 
													 "Integrated Security=SSPI;Connect Timeout=5";

    private string Connectionstring  = SQL_CONNECTION_STRING;

    private bool HasConnected  = false;

    private string ServerName  = "localhost";

#region " Windows Form Designer generated code "

    public frmMain() 
	{

        //This call is required by the Windows Form Designer.

        InitializeComponent();

        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.

        AssemblyInfo ainfo = new AssemblyInfo();

        this.Text = ainfo.Title;

        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

        crvBasic.DisplayToolbar = true;

        crvParameter.DisplayToolbar = true;

        crvDynamicFormat.DisplayToolbar = true;

        crvGraphDrillDown.DisplayToolbar = true;

        // Here we need to populate the combo box with the customer names found in the
        // customers table in the northwind databse.

        SqlConnection cnSQL ;

        SqlCommand cmSQL ;

        // Create a datareader object to read the data from the command object.

        SqlDataReader drSQL ;

        // Display a status message box saying that we are attempting to connect.
        // This only needs to be done the first time a connection is attempted.
        // After we have determined that MSDE or SQL Server is installed, this 
        // message no longer needs to be displayed

        frmStatus frmStatusMessage =new frmStatus();

        if (!HasConnected)
		{

            frmStatusMessage.Show("Connecting to SQL Server");

        }

        // Attempt to connect to SQL server or MSDE

        bool IsConnecting  = true;

        while (IsConnecting)
		{

			try 
			{

				// Define connection string.
				// You may need to change this for your environment.

				cnSQL = new SqlConnection(Connectionstring);
				cnSQL.Open();

				// Instantiate Command Object to execute SQL Statements

				cmSQL = new SqlCommand();

				// Attach the command to the connection

				cmSQL.Connection = cnSQL;

				// Set the command type to Text

				cmSQL.CommandType = CommandType.Text;

				// START: Commands are for this How-To only.
				// Drop GetAllCustomerOrders Store Procedure if it exists.

				cmSQL.CommandText = "IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GetAllCustomerOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) " + 

					"DROP PROCEDURE [dbo].[GetAllCustomerOrders] ";

				// Execute the statement

				cmSQL.ExecuteNonQuery();

				// Create GetAllCustomerOrders Stored Procedure

				cmSQL.CommandText = "CREATE PROCEDURE dbo.GetAllCustomerOrders " + "AS " + 
					"SELECT CUST.CompanyName, " + 
					"ORD.OrderID, " + 
					"ORD.OrderDate, " + 
					"ORD.ShippedDate, " + 
					"PROD.ProductName, " + 
					"ORD_D.UnitPrice, " + 
					"ORD_D.Quantity " + 
					"FROM Customers CUST " + 
					"INNER JOIN Orders ORD " + 
					"ON CUST.CustomerID = ORD.CustomerID " + 
					"INNER JOIN [Order Details] ORD_D " + 
					"ON ORD.OrderID = ORD_D.OrderID " + 
					"INNER JOIN Products PROD " + 
					"ON ORD_D.ProductID = PROD.ProductID " + 
					"ORDER BY ORD.OrderDate	" + 
					"Return";

				// Execute the statement

				cmSQL.ExecuteNonQuery();

				// Drop GetCustomerOrders Store Procedure if it exists.  This How-To Only

				cmSQL.CommandText = "IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) " + 
					"DROP PROCEDURE [dbo].[GetCustomerOrders] ";

				// Execute the statement

				cmSQL.ExecuteNonQuery();

				cmSQL.CommandText = "CREATE PROCEDURE dbo.GetCustomerOrders " + 
					"@CustomerName nvarchar(50) " + 
					"AS " + 
					"SELECT ORD.OrderID, " + 
					"ORD.ShippedDate, " + 
					"ORD.OrderDate, " + 
					"PROD.ProductName, " + 
					"ORD_D.UnitPrice, " + 
					"ORD_D.Quantity " + 
					"FROM Customers CUST " + 
					"INNER JOIN Orders ORD " + 
					"ON CUST.CustomerID = ORD.CustomerID " + 
					"INNER JOIN [Order Details] ORD_D " + 
					"ON ORD.OrderID = ORD_D.OrderID " + 
					"INNER JOIN Products PROD " + 
					"ON ORD_D.ProductID = PROD.ProductID " + 
					"WHERE CUST.CompanyName = @CustomerName " + 
					"ORDER BY ORD.OrderDate	" + 
					"RETURN";

				// Execute the statement

				cmSQL.ExecuteNonQuery();

				// END: Commands for this How-To only.             
				// Select statement to pull all the customers from
				// the customer table in the northwind databse.

				cmSQL.CommandText = "SELECT CompanyName " + 
					"FROM Customers";

				// Execute the query we defined in the command object.

				drSQL = cmSQL.ExecuteReader();

				// Loop through the records while there is still records to 
				// retrieve.

				while (drSQL.Read())
				{

					// Add the Customers Company Name to the combo box.
					cbCustomers.Items.Add(drSQL["CompanyName"].ToString());

				}

                // Set the combo box to the first item.

                cbCustomers.SelectedIndex = 0;
                IsConnecting = false;
                HasConnected = true;

                // Close Connection.

                drSQL.Close();
                cnSQL.Close();

                // Clean up.

                cnSQL.Dispose();
                cmSQL.Dispose();

			} 
			catch( SqlException Err)
			{

				if (Connectionstring == SQL_CONNECTION_STRING)
				{

					// Couldn't connect to SQL server. Now try MSDE
					Connectionstring = MSDE_CONNECTION_STRING;
					ServerName = MSDE_SERVER;
					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE

					frmStatusMessage.Close();
					MessageBox.Show("To run this sample you must have SQL Server ot MSDE with " + 
									"the Northwind database installed.  For instructions on " + 
									"installing MSDE, view the Readme file.", 
									"SQL Server/MSDE not found");

					// Quit program if neither connection method was successful.

					
					Application.Exit();

				}

           } 
			catch(Exception Err) 
			{

                // Report Non SQL Error to the user.
                MessageBox.Show(Err.ToString(),  "General Error");

            }

        }

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

    internal System.Windows.Forms.MenuItem MenuItem1;

    internal System.Windows.Forms.MenuItem MenuItem2;

    private System.Windows.Forms.MenuItem mnuAbout;

    private System.Windows.Forms.MenuItem mnuExit;

    internal System.Windows.Forms.TabControl TabControl1;

    internal System.Windows.Forms.TabPage tpReportBasic;

    internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvBasic;

    internal System.Windows.Forms.TabPage tpParameterReport;

    internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvParameter;

    internal System.Windows.Forms.Label lblCustomer;

    internal System.Windows.Forms.ComboBox cbCustomers;

    internal System.Windows.Forms.Button btnPreviewCustomerReport;

    internal System.Windows.Forms.TabPage tpDynamicFormatReport;

    internal System.Windows.Forms.TabPage tpGraphDrillDownReport;

    internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvDynamicFormat;

    internal CrystalDecisions.Windows.Forms.CrystalReportViewer crvGraphDrillDown;

    internal System.Windows.Forms.TextBox txtUnitsToHighlight;

    internal System.Windows.Forms.ComboBox cbHighlightColor;

    internal System.Windows.Forms.Label Label1;

    internal System.Windows.Forms.Label Label2;

    internal System.Windows.Forms.Button btnPreviewDrillDownReport;

    internal System.Windows.Forms.Label Label3;

    internal System.Windows.Forms.Label Label4;

    internal System.Windows.Forms.Button btnPreviewBasicReport;

    internal System.Windows.Forms.Button btnPreviewDynamicReport;

    private void InitializeComponent() 
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tpReportBasic = new System.Windows.Forms.TabPage();
            this.btnPreviewBasicReport = new System.Windows.Forms.Button();
            this.crvBasic = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tpDynamicFormatReport = new System.Windows.Forms.TabPage();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnPreviewDynamicReport = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cbHighlightColor = new System.Windows.Forms.ComboBox();
            this.txtUnitsToHighlight = new System.Windows.Forms.TextBox();
            this.crvDynamicFormat = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tpParameterReport = new System.Windows.Forms.TabPage();
            this.btnPreviewCustomerReport = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.crvParameter = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tpGraphDrillDownReport = new System.Windows.Forms.TabPage();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnPreviewDrillDownReport = new System.Windows.Forms.Button();
            this.crvGraphDrillDown = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TabControl1.SuspendLayout();
            this.tpReportBasic.SuspendLayout();
            this.tpDynamicFormatReport.SuspendLayout();
            this.tpParameterReport.SuspendLayout();
            this.tpGraphDrillDownReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1,
            this.MenuItem2});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuExit});
            resources.ApplyResources(this.MenuItem1, "MenuItem1");
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 0;
            resources.ApplyResources(this.mnuExit, "mnuExit");
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 1;
            this.MenuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout});
            resources.ApplyResources(this.MenuItem2, "MenuItem2");
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            resources.ApplyResources(this.mnuAbout, "mnuAbout");
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tpReportBasic);
            this.TabControl1.Controls.Add(this.tpDynamicFormatReport);
            this.TabControl1.Controls.Add(this.tpParameterReport);
            this.TabControl1.Controls.Add(this.tpGraphDrillDownReport);
            resources.ApplyResources(this.TabControl1, "TabControl1");
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            // 
            // tpReportBasic
            // 
            this.tpReportBasic.Controls.Add(this.btnPreviewBasicReport);
            this.tpReportBasic.Controls.Add(this.crvBasic);
            resources.ApplyResources(this.tpReportBasic, "tpReportBasic");
            this.tpReportBasic.Name = "tpReportBasic";
            // 
            // btnPreviewBasicReport
            // 
            resources.ApplyResources(this.btnPreviewBasicReport, "btnPreviewBasicReport");
            this.btnPreviewBasicReport.Name = "btnPreviewBasicReport";
            this.btnPreviewBasicReport.Click += new System.EventHandler(this.btnPreviewBasicReport_Click);
            // 
            // crvBasic
            // 
            this.crvBasic.ActiveViewIndex = -1;
            resources.ApplyResources(this.crvBasic, "crvBasic");
            this.crvBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBasic.Name = "crvBasic";
            this.crvBasic.SelectionFormula = "";
            this.crvBasic.ViewTimeSelectionFormula = "";
            // 
            // tpDynamicFormatReport
            // 
            this.tpDynamicFormatReport.Controls.Add(this.Label4);
            this.tpDynamicFormatReport.Controls.Add(this.btnPreviewDynamicReport);
            this.tpDynamicFormatReport.Controls.Add(this.Label2);
            this.tpDynamicFormatReport.Controls.Add(this.Label1);
            this.tpDynamicFormatReport.Controls.Add(this.cbHighlightColor);
            this.tpDynamicFormatReport.Controls.Add(this.txtUnitsToHighlight);
            this.tpDynamicFormatReport.Controls.Add(this.crvDynamicFormat);
            resources.ApplyResources(this.tpDynamicFormatReport, "tpDynamicFormatReport");
            this.tpDynamicFormatReport.Name = "tpDynamicFormatReport";
            // 
            // Label4
            // 
            resources.ApplyResources(this.Label4, "Label4");
            this.Label4.Name = "Label4";
            // 
            // btnPreviewDynamicReport
            // 
            resources.ApplyResources(this.btnPreviewDynamicReport, "btnPreviewDynamicReport");
            this.btnPreviewDynamicReport.Name = "btnPreviewDynamicReport";
            this.btnPreviewDynamicReport.Click += new System.EventHandler(this.btnPreviewDynamicReport_Click);
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // cbHighlightColor
            // 
            resources.ApplyResources(this.cbHighlightColor, "cbHighlightColor");
            this.cbHighlightColor.Items.AddRange(new object[] {
            resources.GetString("cbHighlightColor.Items"),
            resources.GetString("cbHighlightColor.Items1"),
            resources.GetString("cbHighlightColor.Items2")});
            this.cbHighlightColor.Name = "cbHighlightColor";
            // 
            // txtUnitsToHighlight
            // 
            resources.ApplyResources(this.txtUnitsToHighlight, "txtUnitsToHighlight");
            this.txtUnitsToHighlight.Name = "txtUnitsToHighlight";
            // 
            // crvDynamicFormat
            // 
            this.crvDynamicFormat.ActiveViewIndex = -1;
            resources.ApplyResources(this.crvDynamicFormat, "crvDynamicFormat");
            this.crvDynamicFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDynamicFormat.Name = "crvDynamicFormat";
            this.crvDynamicFormat.SelectionFormula = "";
            this.crvDynamicFormat.ViewTimeSelectionFormula = "";
            // 
            // tpParameterReport
            // 
            this.tpParameterReport.Controls.Add(this.btnPreviewCustomerReport);
            this.tpParameterReport.Controls.Add(this.lblCustomer);
            this.tpParameterReport.Controls.Add(this.cbCustomers);
            this.tpParameterReport.Controls.Add(this.crvParameter);
            resources.ApplyResources(this.tpParameterReport, "tpParameterReport");
            this.tpParameterReport.Name = "tpParameterReport";
            // 
            // btnPreviewCustomerReport
            // 
            resources.ApplyResources(this.btnPreviewCustomerReport, "btnPreviewCustomerReport");
            this.btnPreviewCustomerReport.Name = "btnPreviewCustomerReport";
            this.btnPreviewCustomerReport.Click += new System.EventHandler(this.btnPreviewCustomerReport_Click);
            // 
            // lblCustomer
            // 
            resources.ApplyResources(this.lblCustomer, "lblCustomer");
            this.lblCustomer.Name = "lblCustomer";
            // 
            // cbCustomers
            // 
            resources.ApplyResources(this.cbCustomers, "cbCustomers");
            this.cbCustomers.Name = "cbCustomers";
            // 
            // crvParameter
            // 
            this.crvParameter.ActiveViewIndex = -1;
            resources.ApplyResources(this.crvParameter, "crvParameter");
            this.crvParameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvParameter.Name = "crvParameter";
            this.crvParameter.SelectionFormula = "";
            this.crvParameter.ViewTimeSelectionFormula = "";
            // 
            // tpGraphDrillDownReport
            // 
            this.tpGraphDrillDownReport.Controls.Add(this.Label3);
            this.tpGraphDrillDownReport.Controls.Add(this.btnPreviewDrillDownReport);
            this.tpGraphDrillDownReport.Controls.Add(this.crvGraphDrillDown);
            resources.ApplyResources(this.tpGraphDrillDownReport, "tpGraphDrillDownReport");
            this.tpGraphDrillDownReport.Name = "tpGraphDrillDownReport";
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // btnPreviewDrillDownReport
            // 
            resources.ApplyResources(this.btnPreviewDrillDownReport, "btnPreviewDrillDownReport");
            this.btnPreviewDrillDownReport.Name = "btnPreviewDrillDownReport";
            this.btnPreviewDrillDownReport.Click += new System.EventHandler(this.btnPreviewDrillDownReport_Click);
            // 
            // crvGraphDrillDown
            // 
            this.crvGraphDrillDown.ActiveViewIndex = -1;
            resources.ApplyResources(this.crvGraphDrillDown, "crvGraphDrillDown");
            this.crvGraphDrillDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvGraphDrillDown.Name = "crvGraphDrillDown";
            this.crvGraphDrillDown.SelectionFormula = "";
            this.crvGraphDrillDown.ViewTimeSelectionFormula = "";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.TabControl1);
            this.Menu = this.mnuMain;
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TabControl1.ResumeLayout(false);
            this.tpReportBasic.ResumeLayout(false);
            this.tpDynamicFormatReport.ResumeLayout(false);
            this.tpDynamicFormatReport.PerformLayout();
            this.tpParameterReport.ResumeLayout(false);
            this.tpParameterReport.PerformLayout();
            this.tpGraphDrillDownReport.ResumeLayout(false);
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

    private void btnPreviewBasicReport_Click(object sender, System.EventArgs e) 
	{

        // In this event the Ten Most Expensive Products Report is loaded 

        // and displayed in the crystal reports viewer.

        // Objects used to set the proper database connection information

		
        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;

        // Create a report document instance to hold the report

        ReportDocument rptExpensiveProducts =new ReportDocument();

        try 
		{

            // Load the report

            rptExpensiveProducts.Load(@"..\..\TenMostExpensiveProducts.rpt");

            // Set the connection information for all the tables used in the report
            // Leave UserID and Password blank for trusted connection

			foreach(CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptExpensiveProducts.Database.Tables)
			{

				tliCurrent = tbCurrent.LogOnInfo;
				
				tliCurrent.ConnectionInfo.ServerName = ServerName;
				tliCurrent.ConnectionInfo.UserID = string.Empty;
				tliCurrent.ConnectionInfo.Password = string.Empty;
				tliCurrent.ConnectionInfo.DatabaseName = "Northwind";
				tbCurrent.ApplyLogOnInfo(tliCurrent);

			}

            // Set the report source for the crystal reports 
            // viewer to the report instance.

            crvBasic.ReportSource = rptExpensiveProducts;

            // Zoom viewer to fit to the whole page so the user can see the report

            crvBasic.Zoom(2);

		} 
		catch( LoadSaveReportException Exp )
		{

            MessageBox.Show("Incorrect path for loading report.", "Load Report Error");

		} 
		catch( Exception Exp)
		{
            MessageBox.Show(Exp.Message, "General Error");
        }

    }
	public bool IsNumeric(string val)
	{
		try
		{
			double result = 0;
			return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
		}
		catch
		{
			return false;
		}
	}

    private void btnPreviewCustomerReport_Click(object sender, System.EventArgs e)
	{

        // In this event the Customer Orders Report is loaded 
        // and displayed in the crystal reports viewer.
        // This report calls for a parameter which is pulled
        // from the customer name combo box (cbCustomers).
        // Objects used to set the parameters in the report

        CrystalDecisions.Shared.ParameterValues pvCollection =new CrystalDecisions.Shared.ParameterValues();

        CrystalDecisions.Shared.ParameterDiscreteValue pdvCustomerName = new CrystalDecisions.Shared.ParameterDiscreteValue();

        // Objects used to set the proper database connection information


        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;

        // Create a report document instance to hold the report

        ReportDocument rptCustomersOrders = new ReportDocument();

        try 
		{

            // Load the report

            rptCustomersOrders.Load(@"..\..\CustomerOrders.rpt");

            // Set the connection information for all the tables used in the report
            // Leave UserID and Password blank for trusted connection

			foreach(CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptCustomersOrders.Database.Tables)
			{

				tliCurrent = tbCurrent.LogOnInfo;
				
				tliCurrent.ConnectionInfo.ServerName = ServerName;
				tliCurrent.ConnectionInfo.UserID = string.Empty;
				tliCurrent.ConnectionInfo.Password = string.Empty;
				tliCurrent.ConnectionInfo.DatabaseName = "Northwind";
				tbCurrent.ApplyLogOnInfo(tliCurrent);

			}

            // Set the discreet value to the customers name.

            pdvCustomerName.Value = cbCustomers.Text;

            // Add it to the parameter collection.

            pvCollection.Add(pdvCustomerName);

            // Apply the current parameter values.

            rptCustomersOrders.DataDefinition.ParameterFields["@CustomerName"].ApplyCurrentValues(pvCollection);

            // Hide group tree for this report

            crvParameter.DisplayGroupTree = false;

            // Set the report source for the crystal reports viewer to the 
            // report instance.

            crvParameter.ReportSource = rptCustomersOrders;

            // Zoom viewer to fit to the whole page so the user can see the report

            crvParameter.Zoom(2);

		} 
		catch(LoadSaveReportException Exp)
		{

            MessageBox.Show("Incorrect path for loading report.", "Load Report Error");

		} 
		catch( Exception Exp)
		{
            MessageBox.Show(Exp.Message, "General Error");
        }
    }

    private void btnPreviewDrillDownReport_Click(object sender, System.EventArgs e)
	{

        // In this event the Top 5 Products Sold Report is loaded 
        // and displayed in the crystal reports viewer.
        // This Report has a graph which can be used to drill down to the detail
        // of the report.
        // Create a report document instance to hold the report

        ReportDocument rptDrillDown = new ReportDocument();

        // Objects used to set the proper database connection information

       
        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;

        try 
		{

            // Load the report
            rptDrillDown.Load(@"..\..\Top5ProductsSold.rpt");

            // Set the connection information for all the tables used in the report
            // Leave UserID and Password blank for trusted connection

			foreach( CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptDrillDown.Database.Tables)
			{
				tliCurrent = tbCurrent.LogOnInfo;
				
				tliCurrent.ConnectionInfo.ServerName = ServerName;
				tliCurrent.ConnectionInfo.UserID = string.Empty;
				tliCurrent.ConnectionInfo.Password = string.Empty;
				tliCurrent.ConnectionInfo.DatabaseName = "Northwind";
				tbCurrent.ApplyLogOnInfo(tliCurrent);

			}

            // Set the report source for the crystal reports viewer to 
            // the report instance.

            crvGraphDrillDown.ReportSource = rptDrillDown;

            // Hide group tree for this report

            crvParameter.DisplayGroupTree = false;

            // Zoom viewer to fit to the whole page so the user can see the report

            crvGraphDrillDown.Zoom(2);

       } 
		catch(LoadSaveReportException  Exp)
		{

            MessageBox.Show("Incorrect path for loading report.", "Load Report Error");

		} 
		catch(Exception  Exp )
		{

            MessageBox.Show(Exp.Message, "General Error");

        }

    }

    private void btnPreviewDynamicReport_Click(object sender, System.EventArgs e)
	{

        // In this event the All Customers Orders Report is loaded 
        // and displayed in the crystal reports viewer.  On this report
        // the user can set a unit price and a color.  These parameters
        // are passed into the report to determine if a row is highlighted
        // in the selected color.  During the design of the report
        // a formula was added to the details section which controls
        // background color.  The formula says that if the unit price is
        // greater than the value passed in then that detail lines background
        // color will be the color passed in else no color.
        // This report is also a landscape report.  Inorder to display and print 
        // a landscape report correctly a report document object must be created at 
        // runtime and the report then needs to be assigned to
        // it.  This is an error in Crystal and more information can be
        // found at:  
        // http://support.crystaldecisions/library/kbase/articles/c2011099.asp
        // Create a report document instance to hold the report

        ReportDocument rptAllCustomersOrders = new ReportDocument();

        // Objects used to set the parameters in the report

        CrystalDecisions.Shared.ParameterValues pvCollection = new CrystalDecisions.Shared.ParameterValues();

        CrystalDecisions.Shared.ParameterDiscreteValue pdvColor = new CrystalDecisions.Shared.ParameterDiscreteValue();

        CrystalDecisions.Shared.ParameterDiscreteValue pdvUnitPrice = new CrystalDecisions.Shared.ParameterDiscreteValue();

        // Objects used to set the proper database connection information

      

        CrystalDecisions.Shared.TableLogOnInfo tliCurrent;

        // Set the proper values for the colors
	
		int red = 255;
		int green = 65280;
		int blue = 16711680;
		
        if (!IsNumeric(txtUnitsToHighlight.Text))
			{

            MessageBox.Show("Please enter a number into the unit price text box.", this.Text);
            return;
        }

        try 
		{

            // Load the report

            rptAllCustomersOrders.Load(@"..\..\AllCustomersOrders.rpt");

            // Set the connection information for all the tables used in the report
            // Leave UserID and Password blank for trusted connection

			foreach(CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rptAllCustomersOrders.Database.Tables)
			{

				tliCurrent = tbCurrent.LogOnInfo;
				
				tliCurrent.ConnectionInfo.ServerName = ServerName;
				tliCurrent.ConnectionInfo.UserID = string.Empty;
				tliCurrent.ConnectionInfo.Password = string.Empty;
				tliCurrent.ConnectionInfo.DatabaseName = "Northwind";
				tbCurrent.ApplyLogOnInfo(tliCurrent);

			}

            // Set the discreet value to the selected color.

            switch( cbHighlightColor.Text)
			{
			
                case "Red":

                    pdvColor.Value = red;
					break;

                case "Green":

                    pdvColor.Value = green;
					break;
                case "Blue":

                    pdvColor.Value = blue;
					break;
			}

            // Set the discreet value to the Unit Price.
            pdvUnitPrice.Value = txtUnitsToHighlight.Text;

            // Add the color value to the parameter collection.

            pvCollection.Add(pdvColor);

            // Apply the color parameter value.

            rptAllCustomersOrders.DataDefinition.ParameterFields["ColorToHighlight"].ApplyCurrentValues(pvCollection);

            // Clear for next parameter

            pvCollection.Clear();

            // Add the unit price value to the parameter collection.

            pvCollection.Add(pdvUnitPrice);

            // Apply the unit price parameter value.

            rptAllCustomersOrders.DataDefinition.ParameterFields["PriceToCheck"].ApplyCurrentValues(pvCollection);

            // Show group tree for this report

            crvDynamicFormat.DisplayGroupTree = true;

            // Set the report source for the crystal reports viewer to 

            // the report instance.

            crvDynamicFormat.ReportSource = rptAllCustomersOrders;

            // Zoom viewer to fit whole page so the user can see the report

            crvDynamicFormat.Zoom(2);

		} 
		catch(LoadSaveReportException Exp)
		{
            MessageBox.Show("Incorrect path for loading report.", 
							"Load Report Error");

		} 
		catch(Exception Exp)
		{
            MessageBox.Show(Exp.Message, "General Error");
        }

    }

}

