//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

public class frmMain : System.Windows.Forms.Form 
{
	// Collection to hold processes for faster retrieval
	private ArrayList mcolProcesses = new ArrayList();

	// Child form reference to show module detail
	private frmModules mfrmMod;
	private ListViewItem lSingleItem;

	// string constants for display in listviews
	private const string PID_NA  = "N/A";
	private const string PROCESS_NAME_TOTAL  = "_Total (0x0)";
	private const string PROCESS_IDLE  = "Idle";
	private const string PROCESS_SYSTEM  = "System";

	// Used by AddNameValuePair to reduce typing
	private ListView.ListViewItemCollection mits;

#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

	public frmMain() 
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.

		AssemblyInfo ainfo = new AssemblyInfo();
		this.Text = ainfo.Title;
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
	private System.Windows.Forms.StatusBar sbInfo;
	private System.Windows.Forms.Splitter splVert;
	private System.Windows.Forms.ColumnHeader chValue;
	private System.Windows.Forms.ColumnHeader chItem;
	private System.Windows.Forms.ListView lvProcessDetail;
	private System.Windows.Forms.Panel pnlProcess;
	private System.Windows.Forms.ListView lvThreads;
	private System.Windows.Forms.ColumnHeader chThreads;
	private System.Windows.Forms.ColumnHeader chBasePri;
	private System.Windows.Forms.ColumnHeader chCurrentPri;
	private System.Windows.Forms.ColumnHeader chPriBoostEnabled;
	private System.Windows.Forms.ColumnHeader chPriLevel;
	private System.Windows.Forms.ColumnHeader chPrivProcTime;
	private System.Windows.Forms.ColumnHeader chStartAddress;
	private System.Windows.Forms.ColumnHeader chStartTime;
	private System.Windows.Forms.ColumnHeader chTotalProcTime;
	private System.Windows.Forms.ColumnHeader chUserProcTime;
	private System.Windows.Forms.Splitter splHor;
	private System.Windows.Forms.ListView lvProcesses;
	private System.Windows.Forms.ColumnHeader chProcessName;
	private System.Windows.Forms.ColumnHeader chPID;
	private System.Windows.Forms.ColumnHeader chProcessorTime;
	private System.Windows.Forms.ColumnHeader chPriv;
	private System.Windows.Forms.ColumnHeader chUser;
    private System.Windows.Forms.Panel pnlThreads;
	private System.Windows.Forms.MenuItem ctxViewMods;
	private System.Windows.Forms.ContextMenu ctxView;
	private System.Windows.Forms.MenuItem ctxRefresh;
	private System.Windows.Forms.MenuItem MenuItem1;

	private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.sbInfo = new System.Windows.Forms.StatusBar();
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.chProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProcessorTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPriv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxView = new System.Windows.Forms.ContextMenu();
            this.ctxViewMods = new System.Windows.Forms.MenuItem();
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.ctxRefresh = new System.Windows.Forms.MenuItem();
            this.splVert = new System.Windows.Forms.Splitter();
            this.lvProcessDetail = new System.Windows.Forms.ListView();
            this.chItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlThreads = new System.Windows.Forms.Panel();
            this.lvThreads = new System.Windows.Forms.ListView();
            this.chThreads = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBasePri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCurrentPri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPriBoostEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPriLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrivProcTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTotalProcTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUserProcTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splHor = new System.Windows.Forms.Splitter();
            this.pnlProcess.SuspendLayout();
            this.pnlThreads.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbInfo
            // 
            this.sbInfo.Location = new System.Drawing.Point(0, 479);
            this.sbInfo.Name = "sbInfo";
            this.sbInfo.Size = new System.Drawing.Size(927, 26);
            this.sbInfo.TabIndex = 6;
            this.sbInfo.Text = "Ready";
            // 
            // pnlProcess
            // 
            this.pnlProcess.Controls.Add(this.lvProcesses);
            this.pnlProcess.Controls.Add(this.splVert);
            this.pnlProcess.Controls.Add(this.lvProcessDetail);
            this.pnlProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProcess.Location = new System.Drawing.Point(0, 0);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Size = new System.Drawing.Size(927, 425);
            this.pnlProcess.TabIndex = 10;
            // 
            // lvProcesses
            // 
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProcessName,
            this.chPID,
            this.chProcessorTime,
            this.chPriv,
            this.chUser});
            this.lvProcesses.ContextMenu = this.ctxView;
            this.lvProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.Location = new System.Drawing.Point(0, 0);
            this.lvProcesses.MultiSelect = false;
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(557, 425);
            this.lvProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProcesses.TabIndex = 15;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            this.lvProcesses.SelectedIndexChanged += new System.EventHandler(this.lvProcesses_SelectedIndexChanged);
            // 
            // chProcessName
            // 
            this.chProcessName.Text = "Process Name";
            this.chProcessName.Width = 150;
            // 
            // chPID
            // 
            this.chPID.Text = "PID";
            // 
            // chProcessorTime
            // 
            this.chProcessorTime.Text = "Processor Time";
            this.chProcessorTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chProcessorTime.Width = 150;
            // 
            // chPriv
            // 
            this.chPriv.Text = "Priviledged";
            this.chPriv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chPriv.Width = 80;
            // 
            // chUser
            // 
            this.chUser.Text = "User";
            this.chUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chUser.Width = 80;
            // 
            // ctxView
            // 
            this.ctxView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxViewMods,
            this.MenuItem1,
            this.ctxRefresh});
            // 
            // ctxViewMods
            // 
            this.ctxViewMods.Index = 0;
            this.ctxViewMods.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.ctxViewMods.Text = "View &Modules";
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 1;
            this.MenuItem1.Text = "-";
            // 
            // ctxRefresh
            // 
            this.ctxRefresh.Index = 2;
            this.ctxRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.ctxRefresh.Text = "&Refresh";
            // 
            // splVert
            // 
            this.splVert.Dock = System.Windows.Forms.DockStyle.Right;
            this.splVert.Location = new System.Drawing.Point(557, 0);
            this.splVert.Name = "splVert";
            this.splVert.Size = new System.Drawing.Size(3, 425);
            this.splVert.TabIndex = 14;
            this.splVert.TabStop = false;
            // 
            // lvProcessDetail
            // 
            this.lvProcessDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chItem,
            this.chValue});
            this.lvProcessDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvProcessDetail.Location = new System.Drawing.Point(560, 0);
            this.lvProcessDetail.MultiSelect = false;
            this.lvProcessDetail.Name = "lvProcessDetail";
            this.lvProcessDetail.Size = new System.Drawing.Size(367, 425);
            this.lvProcessDetail.TabIndex = 13;
            this.lvProcessDetail.UseCompatibleStateImageBehavior = false;
            this.lvProcessDetail.View = System.Windows.Forms.View.Details;
            // 
            // chItem
            // 
            this.chItem.Text = "Item";
            this.chItem.Width = 165;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 206;
            // 
            // pnlThreads
            // 
            this.pnlThreads.Controls.Add(this.lvThreads);
            this.pnlThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThreads.Location = new System.Drawing.Point(0, 425);
            this.pnlThreads.Name = "pnlThreads";
            this.pnlThreads.Size = new System.Drawing.Size(927, 54);
            this.pnlThreads.TabIndex = 14;
            // 
            // lvThreads
            // 
            this.lvThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chThreads,
            this.chBasePri,
            this.chCurrentPri,
            this.chPriBoostEnabled,
            this.chPriLevel,
            this.chPrivProcTime,
            this.chStartAddress,
            this.chStartTime,
            this.chTotalProcTime,
            this.chUserProcTime});
            this.lvThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvThreads.FullRowSelect = true;
            this.lvThreads.Location = new System.Drawing.Point(0, 0);
            this.lvThreads.MultiSelect = false;
            this.lvThreads.Name = "lvThreads";
            this.lvThreads.Size = new System.Drawing.Size(927, 54);
            this.lvThreads.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvThreads.TabIndex = 14;
            this.lvThreads.UseCompatibleStateImageBehavior = false;
            this.lvThreads.View = System.Windows.Forms.View.Details;
            // 
            // chThreads
            // 
            this.chThreads.Text = "Thread(s)";
            // 
            // chBasePri
            // 
            this.chBasePri.Text = "Base Priority";
            this.chBasePri.Width = 75;
            // 
            // chCurrentPri
            // 
            this.chCurrentPri.Text = "Current Priority";
            this.chCurrentPri.Width = 85;
            // 
            // chPriBoostEnabled
            // 
            this.chPriBoostEnabled.Text = "Priority Boost Enabled";
            this.chPriBoostEnabled.Width = 115;
            // 
            // chPriLevel
            // 
            this.chPriLevel.Text = "Priority Level";
            this.chPriLevel.Width = 75;
            // 
            // chPrivProcTime
            // 
            this.chPrivProcTime.Text = "Privileged";
            // 
            // chStartAddress
            // 
            this.chStartAddress.Text = "Start Address";
            this.chStartAddress.Width = 80;
            // 
            // chStartTime
            // 
            this.chStartTime.Text = "Start Time";
            this.chStartTime.Width = 120;
            // 
            // chTotalProcTime
            // 
            this.chTotalProcTime.Text = "Processor Time";
            this.chTotalProcTime.Width = 120;
            // 
            // chUserProcTime
            // 
            this.chUserProcTime.Text = "User";
            // 
            // splHor
            // 
            this.splHor.Dock = System.Windows.Forms.DockStyle.Top;
            this.splHor.Location = new System.Drawing.Point(0, 425);
            this.splHor.Name = "splHor";
            this.splHor.Size = new System.Drawing.Size(927, 3);
            this.splHor.TabIndex = 16;
            this.splHor.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(927, 505);
            this.Controls.Add(this.splHor);
            this.Controls.Add(this.pnlThreads);
            this.Controls.Add(this.pnlProcess);
            this.Controls.Add(this.sbInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title Comes from Assembly Info";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlProcess.ResumeLayout(false);
            this.pnlThreads.ResumeLayout(false);
            this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

	// This code simply shows the About form.
	private void mnuAbout_Click(object sender, System.EventArgs e) {


	}

	// This code will close the form.
	private void mnuExit_Click(object sender, System.EventArgs e) {
		// Close the current form
		this.Close();
	}

#endregion

	private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		// Clean up the child form if it's there
		if (! (mfrmMod == null)) 
		{
			try 
			{
				mfrmMod.Owner = null;
				mfrmMod.ParentProcess = null;
				mfrmMod.Close();
				mfrmMod.Dispose();				
				mfrmMod = null;
			}
			catch (Exception exp) 
			{
				MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		// Load the list of processes
		EnumProcesses();
	}

	private void lvProcesses_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		// Handle the selection changing.
		try 
		{
			ListView lv  = ((ListView) (sender));
			if (lv.SelectedItems.Count == 1) 
			{
				// Get the process id from the first subitem column
				string strProcessId  = lv.SelectedItems[0].SubItems[1].Text;
				int ItemIndex = lv.FocusedItem.Index;
				// Check to see if we got our fake 'total' process
				if (strProcessId == PID_NA) 
				{
					this.lvProcessDetail.Items.Clear();
					this.lvThreads.Items.Clear();
					return;
				}

				Process p;
				
				p = ((Process) (mcolProcesses[ItemIndex]));
			
				// Get the most current data
				p.Refresh();

				// Get the process detail
				EnumProcess(p);

				// Get the thread detail
				EnumThreads(p);
			}
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void mnuModules_Click(object sender, System.EventArgs e)
	{
		// Load the child form to display module information
		frmModules mfrmMod = null;
		try 
		{
			ListView lv  = this.lvProcesses;

			if (lv.SelectedItems.Count == 1) 
			{
				string strProcessId  = lv.SelectedItems[0].SubItems[1].Text;
				// Check to see if we got our fake 'total' process
				if (strProcessId == PID_NA) 
				{
					return;
				}
				Process p;
				p = ((Process) (mcolProcesses[Convert.ToInt32(strProcessId)]));

				// Don't enumerate the idle process.
				// You will receive an access denied error.

				if (p.ProcessName == PROCESS_IDLE) 
				{
					return;
				}

				// null to show
				if (p.ProcessName == PROCESS_SYSTEM) 
				{
					return;
				}

				p.Refresh();

				// Finally check to see if we can even 
				// Get the module count.
				// if not, no point in going further.

				try 
				{
					int i = p.Modules.Count;
				}
				catch 
				{
					MessageBox.Show("Sorry, you are not authorized to read this information.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				// if the form is not available, load it

				if (mfrmMod == null) 
				{
					mfrmMod = new frmModules();
				}

				// Pass the selected process
				mfrmMod.ParentProcess = p;

				// Get the module data
				mfrmMod.RefreshModules();

				// Show the form
				mfrmMod.ShowDialog(this);
			}
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void mnuRefresh_Click(object sender, System.EventArgs e)
	{
		// Refresh the process list
		this.sbInfo.Text = "Refreshing list, please wait";
		this.sbInfo.Refresh();
		EnumProcesses();
		this.sbInfo.Text = "Ready";
	}

	private void AddNameValuePair(string Item, string voidItem)
	{
		// Helper procedure to add name/value pairs to a listview control
		mits.Add(Item).SubItems.Add(voidItem);
	}

	private void EnumThreads(Process p)
	{
		// Get the thread information for the process.
		// This information is about the physical Win32 threads
		// not System.Threading.Thread threads.

		string strProcessId = string.Empty;

		try {
			this.lvThreads.Items.Clear();
			
			if (strProcessId == PID_NA)
			{
				this.lvThreads.Items.Add(PID_NA);
			}
			else 
			{
				//ProcessThread t;

				// Timespans for individual thread times
				TimeSpan tpt;
				TimeSpan tppt;
				TimeSpan tupt;

				foreach(ProcessThread t in p.Threads)
				{
					// Get thread time and store
					tppt = t.PrivilegedProcessorTime;
					tupt = t.UserProcessorTime;
					tpt = t.TotalProcessorTime;

					// % User Processor Time for thread
					string strPUPT;
					if (tupt.Ticks == 0) 
					{
						strPUPT = "0%";
					}
					else
					{
						decimal decPUPT = decimal.Divide(tupt.Ticks,tpt.Ticks);
						 strPUPT  = decPUPT.ToString("#0%");
					}
					

					// % Privileged Processor Time for thread
					string strPPPT;
					if (tppt.Ticks == 0) 
					{
						strPPPT = "0%";
					}
					else
					{
						Decimal decPPPT = decimal.Divide(tppt.Ticks,tpt.Ticks);
						 strPPPT  = decPPPT.ToString("#0%");
					}
					

					string strTPT;
					strTPT = (tpt.Days.ToString("00") + "." + tpt.Hours.ToString("00") + ":" + tpt.Minutes.ToString("00") + ":" + tpt.Seconds.ToString("00"));
					
					
					
					lSingleItem = this.lvThreads.Items.Add(t.Id.ToString());
					lSingleItem.SubItems.Add(t.BasePriority.ToString());
					lSingleItem.SubItems.Add(t.CurrentPriority.ToString());

					try 
					{
						lSingleItem.SubItems.Add(t.PriorityBoostEnabled.ToString());
					}
					catch 
					{
						lSingleItem.SubItems.Add("N/A");

					}

					try 
					{
						lSingleItem.SubItems.Add(t.PriorityLevel.ToString());
					}
					catch 
					{
						lSingleItem.SubItems.Add("N/A");
					}

					lSingleItem.SubItems.Add(strPPPT);
					lSingleItem.SubItems.Add(t.StartAddress.ToInt32().ToString("x").ToLower());
					lSingleItem.SubItems.Add(t.StartTime.ToShortDateString() + " " + t.StartTime.ToShortTimeString());
					lSingleItem.SubItems.Add(strTPT);
					lSingleItem.SubItems.Add(strPUPT);
				}	
			}
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void EnumProcess(Process p)
	{
		// Get process information
		ListView lv  = this.lvProcessDetail;
		lv.Items.Clear();

		if (p.ProcessName == PROCESS_IDLE) 
		{
			return;
		}

		mits = lv.Items;
		const string NA = "Not Authorized";

		try 
		{
			AddNameValuePair("Start Time", p.StartTime.ToLongDateString() + " " + p.StartTime.ToLongTimeString());
			AddNameValuePair("Responding", p.Responding.ToString());

			try 
			{
				AddNameValuePair("Handle", p.Handle.ToString());
			}
			catch 
			{
				AddNameValuePair("Handle", NA);
			}

			AddNameValuePair("Handle Count", p.HandleCount.ToString("N0"));

			try 
			{
				AddNameValuePair("Main Window Handle", p.MainWindowHandle.ToString());
			}
			catch 
			{
				AddNameValuePair("Main Window Handle", NA);
			}

			try 
			{
				AddNameValuePair("Main Window Title", p.MainWindowTitle);
			}
			catch 
			{
				AddNameValuePair("Main Window Title", NA);
			}

			try 
			{
				// Check to make sure we have a valid reference.
				// The System process is most notable for not exposing 
				// any module data.

				if (p.MainModule == null) 
				{
					AddNameValuePair("Main Module", string.Empty);
				}
				else 
				{
					AddNameValuePair("Main Module", p.MainModule.ModuleName);
				}
			}
			catch 
			{
				AddNameValuePair("Main Module", NA);
			}

			try 
			{
				AddNameValuePair("Module Count", p.Modules.Count.ToString("N0"));
			}
			catch 
			{									   
				AddNameValuePair("Module Count", NA);
			}

			AddNameValuePair("Base Priority", p.BasePriority.ToString());

			try 
			{
				AddNameValuePair("Priority Boost Enabled", p.PriorityBoostEnabled.ToString());
			}
			catch 
			{
				AddNameValuePair("Priority Boost Enabled", NA);

			}

			try 
			{
				AddNameValuePair("Priority Class", p.PriorityClass.ToString());
			}
			catch 
			{
				AddNameValuePair("Priority Class", NA);
			}

			try 
			{
				AddNameValuePair("Processor Affinity", p.ProcessorAffinity.ToInt32().ToString());
			}
			catch 
			{
				AddNameValuePair("Processor Affinity", NA);
			}

			AddNameValuePair("Thread Count", p.Threads.Count.ToString());

			try 
			{
				AddNameValuePair("Min Working Set", p.MinWorkingSet.ToInt32().ToString("N0"));
			}
			catch 
			{
				AddNameValuePair("Min Working Set", NA);
			}

			try 
			{
				AddNameValuePair("Max Working Set", p.MaxWorkingSet.ToInt32().ToString("N0"));
			}
			catch 
			{									   
				AddNameValuePair("Max Working Set", NA);
			}

			AddNameValuePair("Working Set", p.WorkingSet64.ToString("N0"));

			AddNameValuePair("Peak Working Set", p.PeakWorkingSet64.ToString("N0"));

			AddNameValuePair("private Memory Size", p.PrivateMemorySize64.ToString("N0"));

			AddNameValuePair("Nonpaged System Memory Size", p.NonpagedSystemMemorySize64.ToString("N0"));

			AddNameValuePair("Paged Memory Size", p.PagedMemorySize64.ToString("N0"));

			AddNameValuePair("Peak Paged Memory Size", p.PeakPagedMemorySize64.ToString("N0"));

			AddNameValuePair("Virtual Memory Size", p.VirtualMemorySize64.ToString("N0"));

			AddNameValuePair("Peak Virtual Memory Size", p.PeakVirtualMemorySize64.ToString("N0"));
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void EnumProcesses()
	{

		// Timespans for individual process information
		TimeSpan tpt;
		TimeSpan tppt;
		TimeSpan tupt;

		// Timespans for machine
		TimeSpan mtpt = new TimeSpan();
		TimeSpan mtppt = new TimeSpan();
		TimeSpan mtupt = new TimeSpan();
		ListViewItem lSingleItem;
		
		// Enumerate all processes
		try 
		{
			Process[] Processes;

			if (!(mcolProcesses == null)) 
			{
				mcolProcesses = new ArrayList();
			}

			if (this.lvProcesses.Items.Count > 0) 
			{
				this.lvProcesses.Items.Clear();
				this.lvProcessDetail.Items.Clear();
				this.lvThreads.Items.Clear();
			}

			Processes = Process.GetProcesses();

			foreach(Process p in Processes)
			{
				mcolProcesses.Add(p);
				// Get processor time and store
				tppt = p.PrivilegedProcessorTime;
				tupt = p.UserProcessorTime;
				tpt = p.TotalProcessorTime;

				// Add the current process times to total times.
				mtpt = mtpt.Add(tpt);
				mtppt = mtppt.Add(tppt);
				mtupt = mtupt.Add(tupt);

				// % User Processor Time
				   
				decimal dblPUPT = Decimal.Divide(tupt.Ticks, tpt.Ticks);
				string strPUPT = dblPUPT.ToString("#0%");
				

				// % Privileged Processor Time
				decimal dblPPPT = Decimal.Divide(tppt.Ticks, tpt.Ticks);
				string strPPPT  = dblPPPT.ToString("#0%");
				string strTPT;
				
				strTPT = (tpt.Days.ToString("00") + "." + tpt.Hours.ToString("00") + ":" + tpt.Minutes.ToString("00") + ":" + tpt.Seconds.ToString("00"));
			
			lSingleItem = this.lvProcesses.Items.Add(p.ProcessName + " (0x" + (p.Id.ToString("x")).ToLower() + ")");
			lSingleItem.SubItems.Add(p.Id.ToString());
			lSingleItem.SubItems.Add(strTPT);
			lSingleItem.SubItems.Add(strPPPT);
			lSingleItem.SubItems.Add(strPUPT);
			}
			
			// % Total User Processor Time
			decimal mdecPUPT = Decimal.Divide(mtupt.Ticks , mtpt.Ticks);
			string mstrPUPT  = mdecPUPT.ToString("#0%");

			// % Total Privileged Processor Time
			decimal mdecPPPT = decimal.Divide(mtppt.Ticks,mtpt.Ticks);
			string mstrPPPT  = mdecPPPT.ToString("#0%");
			string mstrTPT;

			mstrTPT = (mtpt.Days.ToString("00") + "." + mtpt.Hours.ToString("00") + ":" + mtpt.Minutes.ToString("00") + ":" + mtpt.Seconds.ToString("00"));

			// Add entry for all processes			
			lSingleItem = this.lvProcesses.Items.Add(PROCESS_NAME_TOTAL);
			lSingleItem.SubItems.Add(PID_NA);
			lSingleItem.SubItems.Add(mstrTPT);
			lSingleItem.SubItems.Add(mstrPPPT);
			lSingleItem.SubItems.Add(mstrPUPT);

		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}

