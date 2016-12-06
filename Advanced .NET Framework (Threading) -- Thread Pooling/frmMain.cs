//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class frmMain : System.Windows.Forms.Form
{
	protected AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
	protected ManualResetEvent manualResetEvent1 = new ManualResetEvent(false);
	protected Mutex mutex1 = new Mutex(true);
	protected ProcessGroup processGroup1;
	protected ProcessGroup processGroup2;
	protected ProcessGroup processGroup3;
	protected TimerGroup timerGroup1;
	protected TimerGroup timerGroup2;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    
#region " Windows Form Designer generated code "

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

    private System.Windows.Forms.TabControl MainTabControl;

    private System.Windows.Forms.GroupBox Process1GroupBox;

    private System.Windows.Forms.Button btnNonthreaded;

    private System.Windows.Forms.Label lblProcess1Active;

    private System.Windows.Forms.GroupBox Process2GroupBox;

    private System.Windows.Forms.Label lblProcess2Active;

    private System.Windows.Forms.GroupBox Process3GroupBox;

    private System.Windows.Forms.Label lblProcess3Active;

    private System.Windows.Forms.Label lblThreadNumber;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Label lblProcess1ThreadNum;

    private System.Windows.Forms.Label lblProcess2ThreadNum;

    private System.Windows.Forms.Label lblProcess3ThreadNum;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label lblProcess1IsPoolThread;

    private System.Windows.Forms.Label lblProcess2IsPoolThread;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label lblProcess3IsPoolThread;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.Button btnThreaded;

    private System.Windows.Forms.Button btnThreadPool;

    private System.Windows.Forms.TabPage FunctionTabPage;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.CheckBox chkHighIntensity;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.Label lblSecondsElapsed;

    private System.Windows.Forms.TabPage TimersTabPage;

    private System.Windows.Forms.GroupBox Timer1GroupBox;

    private System.Windows.Forms.Label lblTimer1IsThreadPool;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.Label lblTimer1ThreadNum;

    private System.Windows.Forms.Label Label11;

    private System.Windows.Forms.Label lblTimer1Output;

    private System.Windows.Forms.GroupBox Timer2GroupBox;

    private System.Windows.Forms.Label Label14;

    private System.Windows.Forms.Label lblTimer2ThreadNum;

    private System.Windows.Forms.Label Label16;

    private System.Windows.Forms.Label lblTimer2Output;

    private System.Windows.Forms.Label lblTimer2IsThreadPool;

    private System.Windows.Forms.Button btnStartStop;

    private System.Windows.Forms.TabPage SyncObjectsTabPage;

    private System.Windows.Forms.GroupBox MutexGroupBox;

    private System.Windows.Forms.Label Label10;

    private System.Windows.Forms.Label lblMutexThreadNum;

    private System.Windows.Forms.Label Label13;

    private System.Windows.Forms.Label lblMutexThreadStatus;

    private System.Windows.Forms.GroupBox ManualEventGroupBox;

    private System.Windows.Forms.Label Label18;

    private System.Windows.Forms.Label Label20;

    private System.Windows.Forms.GroupBox AutoEventGroupBox;

    private System.Windows.Forms.Label Label23;

    private System.Windows.Forms.Label Label25;

    private System.Windows.Forms.Button btnWaitForMutex;

    private System.Windows.Forms.Button btnReleaseMutex;

    private System.Windows.Forms.Label lblMutexIsPoolThread;

    private System.Windows.Forms.Label lblManualEventIsPoolThread;

    private System.Windows.Forms.Label lblManualEventThreadNum;

    private System.Windows.Forms.Label lblManualEventThreadStatus;

    private System.Windows.Forms.Button btnWaitForManualEvent;

    private System.Windows.Forms.Button btnSetManualEvent;

    private System.Windows.Forms.Label lblAutoEventIsPoolThread;

    private System.Windows.Forms.Label lblAutoEventThreadNum;

    private System.Windows.Forms.Label lblAutoEventStatus;

    private System.Windows.Forms.Button btnWaitForAutoEvent;

    private System.Windows.Forms.Button btnSetAutoEvent;

    private System.Windows.Forms.Button btnSetReleaseAll;

    private System.Windows.Forms.Label lblInstructions;

    private System.Windows.Forms.Label lblInstructions2;

    private System.Windows.Forms.Label lblInstructions3;

    private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.FunctionTabPage = new System.Windows.Forms.TabPage();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.chkHighIntensity = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnThreadPool = new System.Windows.Forms.Button();
            this.btnThreaded = new System.Windows.Forms.Button();
            this.lblSecondsElapsed = new System.Windows.Forms.Label();
            this.Process3GroupBox = new System.Windows.Forms.GroupBox();
            this.lblProcess3IsPoolThread = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblProcess3ThreadNum = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblProcess3Active = new System.Windows.Forms.Label();
            this.Process2GroupBox = new System.Windows.Forms.GroupBox();
            this.lblProcess2IsPoolThread = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.lblProcess2ThreadNum = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblProcess2Active = new System.Windows.Forms.Label();
            this.btnNonthreaded = new System.Windows.Forms.Button();
            this.Process1GroupBox = new System.Windows.Forms.GroupBox();
            this.lblProcess1IsPoolThread = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblProcess1ThreadNum = new System.Windows.Forms.Label();
            this.lblThreadNumber = new System.Windows.Forms.Label();
            this.lblProcess1Active = new System.Windows.Forms.Label();
            this.TimersTabPage = new System.Windows.Forms.TabPage();
            this.lblInstructions2 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.Timer2GroupBox = new System.Windows.Forms.GroupBox();
            this.lblTimer2IsThreadPool = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.lblTimer2ThreadNum = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.lblTimer2Output = new System.Windows.Forms.Label();
            this.Timer1GroupBox = new System.Windows.Forms.GroupBox();
            this.lblTimer1IsThreadPool = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.lblTimer1ThreadNum = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.lblTimer1Output = new System.Windows.Forms.Label();
            this.SyncObjectsTabPage = new System.Windows.Forms.TabPage();
            this.lblInstructions3 = new System.Windows.Forms.Label();
            this.btnSetReleaseAll = new System.Windows.Forms.Button();
            this.btnSetAutoEvent = new System.Windows.Forms.Button();
            this.btnWaitForAutoEvent = new System.Windows.Forms.Button();
            this.btnSetManualEvent = new System.Windows.Forms.Button();
            this.btnWaitForManualEvent = new System.Windows.Forms.Button();
            this.btnReleaseMutex = new System.Windows.Forms.Button();
            this.btnWaitForMutex = new System.Windows.Forms.Button();
            this.AutoEventGroupBox = new System.Windows.Forms.GroupBox();
            this.lblAutoEventIsPoolThread = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.lblAutoEventThreadNum = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.lblAutoEventStatus = new System.Windows.Forms.Label();
            this.ManualEventGroupBox = new System.Windows.Forms.GroupBox();
            this.lblManualEventIsPoolThread = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.lblManualEventThreadNum = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.lblManualEventThreadStatus = new System.Windows.Forms.Label();
            this.MutexGroupBox = new System.Windows.Forms.GroupBox();
            this.lblMutexIsPoolThread = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblMutexThreadNum = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.lblMutexThreadStatus = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.FunctionTabPage.SuspendLayout();
            this.Process3GroupBox.SuspendLayout();
            this.Process2GroupBox.SuspendLayout();
            this.Process1GroupBox.SuspendLayout();
            this.TimersTabPage.SuspendLayout();
            this.Timer2GroupBox.SuspendLayout();
            this.Timer1GroupBox.SuspendLayout();
            this.SyncObjectsTabPage.SuspendLayout();
            this.AutoEventGroupBox.SuspendLayout();
            this.ManualEventGroupBox.SuspendLayout();
            this.MutexGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            resources.ApplyResources(this.MainTabControl, "MainTabControl");
            this.MainTabControl.Controls.Add(this.FunctionTabPage);
            this.MainTabControl.Controls.Add(this.TimersTabPage);
            this.MainTabControl.Controls.Add(this.SyncObjectsTabPage);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            // 
            // FunctionTabPage
            // 
            resources.ApplyResources(this.FunctionTabPage, "FunctionTabPage");
            this.FunctionTabPage.Controls.Add(this.lblInstructions);
            this.FunctionTabPage.Controls.Add(this.Label8);
            this.FunctionTabPage.Controls.Add(this.chkHighIntensity);
            this.FunctionTabPage.Controls.Add(this.Label6);
            this.FunctionTabPage.Controls.Add(this.btnThreadPool);
            this.FunctionTabPage.Controls.Add(this.btnThreaded);
            this.FunctionTabPage.Controls.Add(this.lblSecondsElapsed);
            this.FunctionTabPage.Controls.Add(this.Process3GroupBox);
            this.FunctionTabPage.Controls.Add(this.Process2GroupBox);
            this.FunctionTabPage.Controls.Add(this.btnNonthreaded);
            this.FunctionTabPage.Controls.Add(this.Process1GroupBox);
            this.FunctionTabPage.Name = "FunctionTabPage";
            this.FunctionTabPage.Click += new System.EventHandler(this.FunctionTabPage_Click);
            // 
            // lblInstructions
            // 
            resources.ApplyResources(this.lblInstructions, "lblInstructions");
            this.lblInstructions.ForeColor = System.Drawing.Color.Blue;
            this.lblInstructions.Name = "lblInstructions";
            // 
            // Label8
            // 
            resources.ApplyResources(this.Label8, "Label8");
            this.Label8.Name = "Label8";
            // 
            // chkHighIntensity
            // 
            resources.ApplyResources(this.chkHighIntensity, "chkHighIntensity");
            this.chkHighIntensity.Name = "chkHighIntensity";
            this.chkHighIntensity.CheckedChanged += new System.EventHandler(this.chkHighIntensity_CheckedChanged);
            // 
            // Label6
            // 
            resources.ApplyResources(this.Label6, "Label6");
            this.Label6.Name = "Label6";
            // 
            // btnThreadPool
            // 
            resources.ApplyResources(this.btnThreadPool, "btnThreadPool");
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // btnThreaded
            // 
            resources.ApplyResources(this.btnThreaded, "btnThreaded");
            this.btnThreaded.Name = "btnThreaded";
            this.btnThreaded.Click += new System.EventHandler(this.btnThreaded_Click);
            // 
            // lblSecondsElapsed
            // 
            resources.ApplyResources(this.lblSecondsElapsed, "lblSecondsElapsed");
            this.lblSecondsElapsed.Name = "lblSecondsElapsed";
            // 
            // Process3GroupBox
            // 
            resources.ApplyResources(this.Process3GroupBox, "Process3GroupBox");
            this.Process3GroupBox.Controls.Add(this.lblProcess3IsPoolThread);
            this.Process3GroupBox.Controls.Add(this.Label7);
            this.Process3GroupBox.Controls.Add(this.lblProcess3ThreadNum);
            this.Process3GroupBox.Controls.Add(this.Label2);
            this.Process3GroupBox.Controls.Add(this.lblProcess3Active);
            this.Process3GroupBox.Name = "Process3GroupBox";
            this.Process3GroupBox.TabStop = false;
            // 
            // lblProcess3IsPoolThread
            // 
            resources.ApplyResources(this.lblProcess3IsPoolThread, "lblProcess3IsPoolThread");
            this.lblProcess3IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProcess3IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcess3IsPoolThread.Name = "lblProcess3IsPoolThread";
            // 
            // Label7
            // 
            resources.ApplyResources(this.Label7, "Label7");
            this.Label7.Name = "Label7";
            // 
            // lblProcess3ThreadNum
            // 
            resources.ApplyResources(this.lblProcess3ThreadNum, "lblProcess3ThreadNum");
            this.lblProcess3ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProcess3ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcess3ThreadNum.Name = "lblProcess3ThreadNum";
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // lblProcess3Active
            // 
            resources.ApplyResources(this.lblProcess3Active, "lblProcess3Active");
            this.lblProcess3Active.ForeColor = System.Drawing.Color.Red;
            this.lblProcess3Active.Name = "lblProcess3Active";
            // 
            // Process2GroupBox
            // 
            resources.ApplyResources(this.Process2GroupBox, "Process2GroupBox");
            this.Process2GroupBox.Controls.Add(this.lblProcess2IsPoolThread);
            this.Process2GroupBox.Controls.Add(this.Label5);
            this.Process2GroupBox.Controls.Add(this.lblProcess2ThreadNum);
            this.Process2GroupBox.Controls.Add(this.Label1);
            this.Process2GroupBox.Controls.Add(this.lblProcess2Active);
            this.Process2GroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Process2GroupBox.Name = "Process2GroupBox";
            this.Process2GroupBox.TabStop = false;
            // 
            // lblProcess2IsPoolThread
            // 
            resources.ApplyResources(this.lblProcess2IsPoolThread, "lblProcess2IsPoolThread");
            this.lblProcess2IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProcess2IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcess2IsPoolThread.Name = "lblProcess2IsPoolThread";
            // 
            // Label5
            // 
            resources.ApplyResources(this.Label5, "Label5");
            this.Label5.Name = "Label5";
            // 
            // lblProcess2ThreadNum
            // 
            resources.ApplyResources(this.lblProcess2ThreadNum, "lblProcess2ThreadNum");
            this.lblProcess2ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProcess2ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcess2ThreadNum.Name = "lblProcess2ThreadNum";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // lblProcess2Active
            // 
            resources.ApplyResources(this.lblProcess2Active, "lblProcess2Active");
            this.lblProcess2Active.ForeColor = System.Drawing.Color.Red;
            this.lblProcess2Active.Name = "lblProcess2Active";
            // 
            // btnNonthreaded
            // 
            resources.ApplyResources(this.btnNonthreaded, "btnNonthreaded");
            this.btnNonthreaded.Name = "btnNonthreaded";
            this.btnNonthreaded.Click += new System.EventHandler(this.btnNonthreaded_Click);
            // 
            // Process1GroupBox
            // 
            resources.ApplyResources(this.Process1GroupBox, "Process1GroupBox");
            this.Process1GroupBox.Controls.Add(this.lblProcess1IsPoolThread);
            this.Process1GroupBox.Controls.Add(this.Label3);
            this.Process1GroupBox.Controls.Add(this.lblProcess1ThreadNum);
            this.Process1GroupBox.Controls.Add(this.lblThreadNumber);
            this.Process1GroupBox.Controls.Add(this.lblProcess1Active);
            this.Process1GroupBox.Name = "Process1GroupBox";
            this.Process1GroupBox.TabStop = false;
            // 
            // lblProcess1IsPoolThread
            // 
            resources.ApplyResources(this.lblProcess1IsPoolThread, "lblProcess1IsPoolThread");
            this.lblProcess1IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProcess1IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcess1IsPoolThread.Name = "lblProcess1IsPoolThread";
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // lblProcess1ThreadNum
            // 
            resources.ApplyResources(this.lblProcess1ThreadNum, "lblProcess1ThreadNum");
            this.lblProcess1ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProcess1ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcess1ThreadNum.Name = "lblProcess1ThreadNum";
            // 
            // lblThreadNumber
            // 
            resources.ApplyResources(this.lblThreadNumber, "lblThreadNumber");
            this.lblThreadNumber.Name = "lblThreadNumber";
            // 
            // lblProcess1Active
            // 
            resources.ApplyResources(this.lblProcess1Active, "lblProcess1Active");
            this.lblProcess1Active.ForeColor = System.Drawing.Color.Red;
            this.lblProcess1Active.Name = "lblProcess1Active";
            // 
            // TimersTabPage
            // 
            this.TimersTabPage.Controls.Add(this.lblInstructions2);
            this.TimersTabPage.Controls.Add(this.btnStartStop);
            this.TimersTabPage.Controls.Add(this.Timer2GroupBox);
            this.TimersTabPage.Controls.Add(this.Timer1GroupBox);
            resources.ApplyResources(this.TimersTabPage, "TimersTabPage");
            this.TimersTabPage.Name = "TimersTabPage";
            this.TimersTabPage.Click += new System.EventHandler(this.TimersTabPage_Click);
            // 
            // lblInstructions2
            // 
            resources.ApplyResources(this.lblInstructions2, "lblInstructions2");
            this.lblInstructions2.ForeColor = System.Drawing.Color.Blue;
            this.lblInstructions2.Name = "lblInstructions2";
            // 
            // btnStartStop
            // 
            resources.ApplyResources(this.btnStartStop, "btnStartStop");
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // Timer2GroupBox
            // 
            resources.ApplyResources(this.Timer2GroupBox, "Timer2GroupBox");
            this.Timer2GroupBox.Controls.Add(this.lblTimer2IsThreadPool);
            this.Timer2GroupBox.Controls.Add(this.Label14);
            this.Timer2GroupBox.Controls.Add(this.lblTimer2ThreadNum);
            this.Timer2GroupBox.Controls.Add(this.Label16);
            this.Timer2GroupBox.Controls.Add(this.lblTimer2Output);
            this.Timer2GroupBox.Name = "Timer2GroupBox";
            this.Timer2GroupBox.TabStop = false;
            // 
            // lblTimer2IsThreadPool
            // 
            resources.ApplyResources(this.lblTimer2IsThreadPool, "lblTimer2IsThreadPool");
            this.lblTimer2IsThreadPool.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTimer2IsThreadPool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer2IsThreadPool.Name = "lblTimer2IsThreadPool";
            // 
            // Label14
            // 
            resources.ApplyResources(this.Label14, "Label14");
            this.Label14.Name = "Label14";
            // 
            // lblTimer2ThreadNum
            // 
            resources.ApplyResources(this.lblTimer2ThreadNum, "lblTimer2ThreadNum");
            this.lblTimer2ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTimer2ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer2ThreadNum.Name = "lblTimer2ThreadNum";
            // 
            // Label16
            // 
            resources.ApplyResources(this.Label16, "Label16");
            this.Label16.Name = "Label16";
            // 
            // lblTimer2Output
            // 
            resources.ApplyResources(this.lblTimer2Output, "lblTimer2Output");
            this.lblTimer2Output.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimer2Output.Name = "lblTimer2Output";
            // 
            // Timer1GroupBox
            // 
            resources.ApplyResources(this.Timer1GroupBox, "Timer1GroupBox");
            this.Timer1GroupBox.Controls.Add(this.lblTimer1IsThreadPool);
            this.Timer1GroupBox.Controls.Add(this.Label9);
            this.Timer1GroupBox.Controls.Add(this.lblTimer1ThreadNum);
            this.Timer1GroupBox.Controls.Add(this.Label11);
            this.Timer1GroupBox.Controls.Add(this.lblTimer1Output);
            this.Timer1GroupBox.Name = "Timer1GroupBox";
            this.Timer1GroupBox.TabStop = false;
            // 
            // lblTimer1IsThreadPool
            // 
            resources.ApplyResources(this.lblTimer1IsThreadPool, "lblTimer1IsThreadPool");
            this.lblTimer1IsThreadPool.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTimer1IsThreadPool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer1IsThreadPool.Name = "lblTimer1IsThreadPool";
            // 
            // Label9
            // 
            resources.ApplyResources(this.Label9, "Label9");
            this.Label9.Name = "Label9";
            // 
            // lblTimer1ThreadNum
            // 
            resources.ApplyResources(this.lblTimer1ThreadNum, "lblTimer1ThreadNum");
            this.lblTimer1ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTimer1ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimer1ThreadNum.Name = "lblTimer1ThreadNum";
            // 
            // Label11
            // 
            resources.ApplyResources(this.Label11, "Label11");
            this.Label11.Name = "Label11";
            // 
            // lblTimer1Output
            // 
            resources.ApplyResources(this.lblTimer1Output, "lblTimer1Output");
            this.lblTimer1Output.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimer1Output.Name = "lblTimer1Output";
            // 
            // SyncObjectsTabPage
            // 
            this.SyncObjectsTabPage.Controls.Add(this.lblInstructions3);
            this.SyncObjectsTabPage.Controls.Add(this.btnSetReleaseAll);
            this.SyncObjectsTabPage.Controls.Add(this.btnSetAutoEvent);
            this.SyncObjectsTabPage.Controls.Add(this.btnWaitForAutoEvent);
            this.SyncObjectsTabPage.Controls.Add(this.btnSetManualEvent);
            this.SyncObjectsTabPage.Controls.Add(this.btnWaitForManualEvent);
            this.SyncObjectsTabPage.Controls.Add(this.btnReleaseMutex);
            this.SyncObjectsTabPage.Controls.Add(this.btnWaitForMutex);
            this.SyncObjectsTabPage.Controls.Add(this.AutoEventGroupBox);
            this.SyncObjectsTabPage.Controls.Add(this.ManualEventGroupBox);
            this.SyncObjectsTabPage.Controls.Add(this.MutexGroupBox);
            resources.ApplyResources(this.SyncObjectsTabPage, "SyncObjectsTabPage");
            this.SyncObjectsTabPage.Name = "SyncObjectsTabPage";
            // 
            // lblInstructions3
            // 
            resources.ApplyResources(this.lblInstructions3, "lblInstructions3");
            this.lblInstructions3.ForeColor = System.Drawing.Color.Blue;
            this.lblInstructions3.Name = "lblInstructions3";
            // 
            // btnSetReleaseAll
            // 
            resources.ApplyResources(this.btnSetReleaseAll, "btnSetReleaseAll");
            this.btnSetReleaseAll.Name = "btnSetReleaseAll";
            this.btnSetReleaseAll.Click += new System.EventHandler(this.btnSetReleaseAll_Click);
            // 
            // btnSetAutoEvent
            // 
            resources.ApplyResources(this.btnSetAutoEvent, "btnSetAutoEvent");
            this.btnSetAutoEvent.Name = "btnSetAutoEvent";
            this.btnSetAutoEvent.Click += new System.EventHandler(this.btnSetAutoEvent_Click);
            // 
            // btnWaitForAutoEvent
            // 
            resources.ApplyResources(this.btnWaitForAutoEvent, "btnWaitForAutoEvent");
            this.btnWaitForAutoEvent.Name = "btnWaitForAutoEvent";
            this.btnWaitForAutoEvent.Click += new System.EventHandler(this.btnWaitForAutoEvent_Click);
            // 
            // btnSetManualEvent
            // 
            resources.ApplyResources(this.btnSetManualEvent, "btnSetManualEvent");
            this.btnSetManualEvent.Name = "btnSetManualEvent";
            this.btnSetManualEvent.Click += new System.EventHandler(this.btnSetManualEvent_Click);
            // 
            // btnWaitForManualEvent
            // 
            resources.ApplyResources(this.btnWaitForManualEvent, "btnWaitForManualEvent");
            this.btnWaitForManualEvent.Name = "btnWaitForManualEvent";
            this.btnWaitForManualEvent.Click += new System.EventHandler(this.btnWaitForManualEvent_Click);
            // 
            // btnReleaseMutex
            // 
            resources.ApplyResources(this.btnReleaseMutex, "btnReleaseMutex");
            this.btnReleaseMutex.Name = "btnReleaseMutex";
            this.btnReleaseMutex.Click += new System.EventHandler(this.btnReleaseMutex_Click);
            // 
            // btnWaitForMutex
            // 
            resources.ApplyResources(this.btnWaitForMutex, "btnWaitForMutex");
            this.btnWaitForMutex.Name = "btnWaitForMutex";
            this.btnWaitForMutex.Click += new System.EventHandler(this.btnWaitForMutex_Click);
            // 
            // AutoEventGroupBox
            // 
            resources.ApplyResources(this.AutoEventGroupBox, "AutoEventGroupBox");
            this.AutoEventGroupBox.Controls.Add(this.lblAutoEventIsPoolThread);
            this.AutoEventGroupBox.Controls.Add(this.Label23);
            this.AutoEventGroupBox.Controls.Add(this.lblAutoEventThreadNum);
            this.AutoEventGroupBox.Controls.Add(this.Label25);
            this.AutoEventGroupBox.Controls.Add(this.lblAutoEventStatus);
            this.AutoEventGroupBox.Name = "AutoEventGroupBox";
            this.AutoEventGroupBox.TabStop = false;
            // 
            // lblAutoEventIsPoolThread
            // 
            resources.ApplyResources(this.lblAutoEventIsPoolThread, "lblAutoEventIsPoolThread");
            this.lblAutoEventIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAutoEventIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAutoEventIsPoolThread.Name = "lblAutoEventIsPoolThread";
            // 
            // Label23
            // 
            resources.ApplyResources(this.Label23, "Label23");
            this.Label23.Name = "Label23";
            // 
            // lblAutoEventThreadNum
            // 
            resources.ApplyResources(this.lblAutoEventThreadNum, "lblAutoEventThreadNum");
            this.lblAutoEventThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAutoEventThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAutoEventThreadNum.Name = "lblAutoEventThreadNum";
            // 
            // Label25
            // 
            resources.ApplyResources(this.Label25, "Label25");
            this.Label25.Name = "Label25";
            // 
            // lblAutoEventStatus
            // 
            resources.ApplyResources(this.lblAutoEventStatus, "lblAutoEventStatus");
            this.lblAutoEventStatus.ForeColor = System.Drawing.Color.Red;
            this.lblAutoEventStatus.Name = "lblAutoEventStatus";
            // 
            // ManualEventGroupBox
            // 
            resources.ApplyResources(this.ManualEventGroupBox, "ManualEventGroupBox");
            this.ManualEventGroupBox.Controls.Add(this.lblManualEventIsPoolThread);
            this.ManualEventGroupBox.Controls.Add(this.Label18);
            this.ManualEventGroupBox.Controls.Add(this.lblManualEventThreadNum);
            this.ManualEventGroupBox.Controls.Add(this.Label20);
            this.ManualEventGroupBox.Controls.Add(this.lblManualEventThreadStatus);
            this.ManualEventGroupBox.Name = "ManualEventGroupBox";
            this.ManualEventGroupBox.TabStop = false;
            // 
            // lblManualEventIsPoolThread
            // 
            resources.ApplyResources(this.lblManualEventIsPoolThread, "lblManualEventIsPoolThread");
            this.lblManualEventIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblManualEventIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManualEventIsPoolThread.Name = "lblManualEventIsPoolThread";
            // 
            // Label18
            // 
            resources.ApplyResources(this.Label18, "Label18");
            this.Label18.Name = "Label18";
            // 
            // lblManualEventThreadNum
            // 
            resources.ApplyResources(this.lblManualEventThreadNum, "lblManualEventThreadNum");
            this.lblManualEventThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblManualEventThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManualEventThreadNum.Name = "lblManualEventThreadNum";
            // 
            // Label20
            // 
            resources.ApplyResources(this.Label20, "Label20");
            this.Label20.Name = "Label20";
            // 
            // lblManualEventThreadStatus
            // 
            resources.ApplyResources(this.lblManualEventThreadStatus, "lblManualEventThreadStatus");
            this.lblManualEventThreadStatus.ForeColor = System.Drawing.Color.Red;
            this.lblManualEventThreadStatus.Name = "lblManualEventThreadStatus";
            // 
            // MutexGroupBox
            // 
            resources.ApplyResources(this.MutexGroupBox, "MutexGroupBox");
            this.MutexGroupBox.Controls.Add(this.lblMutexIsPoolThread);
            this.MutexGroupBox.Controls.Add(this.Label10);
            this.MutexGroupBox.Controls.Add(this.lblMutexThreadNum);
            this.MutexGroupBox.Controls.Add(this.Label13);
            this.MutexGroupBox.Controls.Add(this.lblMutexThreadStatus);
            this.MutexGroupBox.Name = "MutexGroupBox";
            this.MutexGroupBox.TabStop = false;
            // 
            // lblMutexIsPoolThread
            // 
            resources.ApplyResources(this.lblMutexIsPoolThread, "lblMutexIsPoolThread");
            this.lblMutexIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMutexIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMutexIsPoolThread.Name = "lblMutexIsPoolThread";
            // 
            // Label10
            // 
            resources.ApplyResources(this.Label10, "Label10");
            this.Label10.Name = "Label10";
            // 
            // lblMutexThreadNum
            // 
            resources.ApplyResources(this.lblMutexThreadNum, "lblMutexThreadNum");
            this.lblMutexThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMutexThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMutexThreadNum.Name = "lblMutexThreadNum";
            // 
            // Label13
            // 
            resources.ApplyResources(this.Label13, "Label13");
            this.Label13.Name = "Label13";
            // 
            // lblMutexThreadStatus
            // 
            resources.ApplyResources(this.lblMutexThreadStatus, "lblMutexThreadStatus");
            this.lblMutexThreadStatus.ForeColor = System.Drawing.Color.Red;
            this.lblMutexThreadStatus.Name = "lblMutexThreadStatus";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MainTabControl.ResumeLayout(false);
            this.FunctionTabPage.ResumeLayout(false);
            this.Process3GroupBox.ResumeLayout(false);
            this.Process2GroupBox.ResumeLayout(false);
            this.Process1GroupBox.ResumeLayout(false);
            this.TimersTabPage.ResumeLayout(false);
            this.Timer2GroupBox.ResumeLayout(false);
            this.Timer1GroupBox.ResumeLayout(false);
            this.SyncObjectsTabPage.ResumeLayout(false);
            this.AutoEventGroupBox.ResumeLayout(false);
            this.ManualEventGroupBox.ResumeLayout(false);
            this.MutexGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

    // This code simply shows the About form.
    private void mnuAbout_Click(object sender, System.EventArgs e)
	{

    }

    // This code will close the form.
    private void mnuExit_Click(object sender, System.EventArgs e) 
	{
        // Close the current form
        this.Close();
    }

#endregion

    // This subroutine calls three process consecutively, without using threading.
    private void btnNonthreaded_Click(object sender, System.EventArgs e) 
	{
        // Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = false;
        btnThreaded.Enabled = false;
        btnThreadPool.Enabled = false;
        // Prepare the shared variables to run
        ProcessGroup.PrepareToRun();
        // Run each process.
        processGroup1.Run();
        processGroup2.Run();
        processGroup3.Run();
    }

    // This subroutine releases the mutex, allowing OnMutexReleased to fire.
    private void btnReleaseMutex_Click(object sender, System.EventArgs e) 
	{
        // if mutex is released again before resetting exception will be thrown, so
        // disable the buttons to allow this.
        btnReleaseMutex.Enabled = false;
        btnSetReleaseAll.Enabled = false;
        mutex1.ReleaseMutex();
    }

    // This signals the Auto Reset event, allowing OnAutoEventset {to fire.
    private void btnSetAutoEvent_Click(object sender, System.EventArgs e) 
	{
        // Do not allow event to be set again till OnAutoEventset {finishes
        btnSetAutoEvent.Enabled = false;
        btnSetReleaseAll.Enabled = false;
       autoResetEvent1.Set();
    }

    // This signals the Manual Reset event, allowing OnManualEventset {to fire.
    private void btnSetManualEvent_Click(object sender, System.EventArgs e) 
	{
        // Do not allow the event to be set again, until it has been reset.
        btnSetManualEvent.Enabled = false;
        btnSetReleaseAll.Enabled = false;
        manualResetEvent1.Set();
    }

    // This releases the mutex, and sets the auto and manual reset events.
    private void btnSetReleaseAll_Click(object sender, System.EventArgs e) 
	{
        // Disable all release and set buttons till each finishes.
        btnReleaseMutex.Enabled = false;
        btnSetManualEvent.Enabled = false;
        btnSetAutoEvent.Enabled = false;
        btnSetReleaseAll.Enabled = false;
        mutex1.ReleaseMutex();
        manualResetEvent1.Set();
        autoResetEvent1.Set();
    }

    // This starts and stops the timers.  The button caption toggles between start and 
    // stop.
    private void btnStartStop_Click(object sender, System.EventArgs e) 
	{
        // if caption is "Start" then start a 1 second timer and a 2 second timer, 
        // and change the caption to stop, otherwise stop the timers and change the
        // caption to "Start"

		if (btnStartStop.Text == "&Start")
		{
		
			btnStartStop.Text = "&Stop";
			timerGroup1.StartTimer(1000);
			timerGroup2.StartTimer(2000);
		}
		else 
		{
			btnStartStop.Text = "&Start";
			timerGroup1.StopTimer();
			timerGroup2.StopTimer();
		}
    }

    // This subroutine calls three processes in three separate threads.
    private void btnThreaded_Click(object sender, System.EventArgs e) 
	{
        // Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = false;
        btnThreaded.Enabled = false;
        btnThreadPool.Enabled = false;
        // Prepare the shared variables to run
        ProcessGroup.PrepareToRun();
        // Run each process in its own thread.
        processGroup1.StartThread();
        processGroup2.StartThread();
        processGroup3.StartThread();
    }

    // This subroutine calls requests the ThreadPool to run the three processes.
    private void btnThreadPool_Click(object sender, System.EventArgs e)
	{
        // Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = false;
        btnThreaded.Enabled = false;
        btnThreadPool.Enabled = false;
        // Prepare the shared variables to run
        ProcessGroup.PrepareToRun();
        // Send requests to ThreadPool to run the three processes.
        processGroup1.StartPooledThread();
        processGroup2.StartPooledThread();
        processGroup3.StartPooledThread();
    }

    // This subroutine creates an auto reset event, and puts the auto reset process into
    // waiting until the event is set.
    private void btnWaitForAutoEvent_Click(object sender, System.EventArgs e) 
	{
        
        
        // Create a callback to function OnAutoEventSet
        WaitOrTimerCallback callback = new WaitOrTimerCallback(OnAutoEventSet);
        // Register the event to fire OnAutoEventset {when set, specifying it to continue 
        // to monitor the event even after it has run once.  This puts the process into
        // waiting.
        ThreadPool.RegisterWaitForSingleObject(autoResetEvent1, callback,
            null, Timeout.Infinite, false);
        // Show that process is waiting in blue.
        lblAutoEventStatus.Text = "Waiting";
        lblAutoEventStatus.ForeColor = Color.Blue;
        // Allow the event to be set, but don't let it be put into waiting again until
        // it has already been set.
        btnWaitForAutoEvent.Enabled = false;
        btnSetAutoEvent.Enabled = true;
        // if mutex and events are all in waiting status, allow SetRelease all button

        if ((! btnWaitForManualEvent.Enabled) && (! btnWaitForMutex.Enabled))
		{
            btnSetReleaseAll.Enabled = true;
        }
    }

    // This subroutine creates an manual reset event, and puts the manual reset process 
    // into waiting until the event is set.
    private void btnWaitForManualEvent_Click(object sender, System.EventArgs e) 
	{
        
        
        // Create a callback to function OnManualEventSet
        WaitOrTimerCallback callback = new WaitOrTimerCallback(OnManualEventSet);
        // Register the event to fire OnManualEventset {when set, specifying it to run
        // only once.  This puts the process into waiting.
        ThreadPool.RegisterWaitForSingleObject(manualResetEvent1, callback,
            null, Timeout.Infinite, true);
        // Show that process is waiting in blue.
        lblManualEventThreadStatus.Text = "Waiting";
        lblManualEventThreadStatus.ForeColor = Color.Blue;
        // Allow the event to be set, but don't let it be put into waiting again until
        // it has already been set.
        btnWaitForManualEvent.Enabled = false;
        btnSetManualEvent.Enabled = true;
        // if mutex and events are all in waiting status, allow SetRelease all button
        if ((! btnWaitForMutex.Enabled) && (! btnWaitForAutoEvent.Enabled))
		{
            btnSetReleaseAll.Enabled = true;
        }
    }

    // This subroutine creates an mutex, and puts the mutex process into waiting until
    // the mutex is released.
    private void btnWaitForMutex_Click(object sender, System.EventArgs e) 
	{
       
        // Create a callback to function OnMutexReleased
        WaitOrTimerCallback callback = new WaitOrTimerCallback(OnMutexReleased);
        // Register the mutex to fire OnManualEventset {when release, specifying it to run
        // only once.  This puts the process into waiting.
        ThreadPool.RegisterWaitForSingleObject(mutex1, callback, null,
            Timeout.Infinite, true);
        // Show that process is waiting in blue.
        lblMutexThreadStatus.Text = "Waiting";
        lblMutexThreadStatus.ForeColor = Color.Blue;
        // Allow the mutex to be released, but don't let it be put into waiting again 
        // until it has already been released.
        btnWaitForMutex.Enabled = false;
        btnReleaseMutex.Enabled = true;
        // if mutex and events are all in waiting status, allow SetRelease all button
        if ((! btnWaitForManualEvent.Enabled) && (! btnWaitForAutoEvent.Enabled)) 
		{
            btnSetReleaseAll.Enabled = true;
        }
    }

    // Toggles HighIntensity property for ProcessGroup  
    private void chkHighIntensity_CheckedChanged(object sender, System.EventArgs e) 
	{
        ProcessGroup.SetHighIntensity = chkHighIntensity.Checked;
    }

    // Set up all the groups and event handlers.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        processGroup1 = new ProcessGroup(lblProcess1Active, lblProcess1ThreadNum,
                                         lblProcess1IsPoolThread);
        processGroup2 = new ProcessGroup(lblProcess2Active, lblProcess2ThreadNum,
                                         lblProcess2IsPoolThread);
        processGroup3 = new ProcessGroup(lblProcess3Active, lblProcess3ThreadNum,
                                         lblProcess3IsPoolThread);

        processGroup1.Completed += new OnProcessesComplete(OnProcessesCompleted);
		processGroup2.Completed += new OnProcessesComplete(OnProcessesCompleted);
		processGroup3.Completed += new OnProcessesComplete(OnProcessesCompleted);

        ProcessGroup.PrepareToRun();

        timerGroup1 = new TimerGroup(lblTimer1Output, lblTimer1ThreadNum,
                                     lblTimer1IsThreadPool);
        timerGroup2 = new TimerGroup(lblTimer2Output, lblTimer2ThreadNum,
                                    lblTimer2IsThreadPool);
    }

    // This is the callback subroutine for when the auto reset event is set.
    private void OnAutoEventSet(object obj ,bool TimedOut)
	{
        // Show that process is running in green.
        lblAutoEventStatus.Text = "Running";
        lblAutoEventStatus.ForeColor = Color.Green;
        // Update ThreadNum label with current thread number.  GetHashCode will contain
        // a unique value for each thread.
        lblAutoEventThreadNum.Text = 
            Thread.CurrentThread.GetHashCode().ToString();
        // Update the IsThreadPooled label with Yes/No depending on whether the current
        // thread is a pool thread.

		if (Thread.CurrentThread.IsThreadPoolThread)
		{
			lblAutoEventIsPoolThread.Text = "Yes";
		}
		else 
		{
			lblAutoEventIsPoolThread.Text = "No";
		}

        // Put the current thread to sleep for 2 seconds.
        System.Threading.Thread.Sleep(2000);
        // Show that process is waiting in blue.
        lblAutoEventStatus.Text = "Waiting";
        lblAutoEventStatus.ForeColor = Color.Blue;
        // Since this is an auto reset event, reenable the set button.
        btnSetAutoEvent.Enabled = true;
        // if mutex and events are all waiting then allow SetReleaseAll button.

        if ((! btnWaitForManualEvent.Enabled) && (! btnWaitForMutex.Enabled))
		{
            btnSetReleaseAll.Enabled = true;
        }
    }

    // This is the callback subroutine for when the manual reset event is set.
    private void OnManualEventSet(object obj ,bool TimedOut )
	{
        // Show that process is running in green.
        lblManualEventThreadStatus.Text = "Running";
        lblManualEventThreadStatus.ForeColor = Color.Green;
        // Update ThreadNum label with current thread number.  GetHashCode will contain
        // a unique value for each thread.
        lblManualEventThreadNum.Text = 
            Thread.CurrentThread.GetHashCode().ToString();

        // Update the IsThreadPooled label with Yes/No depending on whether the current
        // thread is a pool thread.

		if (Thread.CurrentThread.IsThreadPoolThread)
		{
			lblManualEventIsPoolThread.Text = "Yes";
		}
		else 
		{
			lblManualEventIsPoolThread.Text = "No";
		}

        // Put the current thread to sleep for 2 seconds.
        System.Threading.Thread.Sleep(2000);

        // Show that the process is inactive in read.
        lblManualEventThreadStatus.Text = "Inactive";
        lblManualEventThreadStatus.ForeColor = Color.Red;
        // Dispose of the event.
        manualResetEvent1.Close();
        // Reenable the WaitForManualEvent button.
        btnWaitForManualEvent.Enabled = true;
    }

    // This is the callback subroutine for when the mutex is released.
    private void OnMutexReleased(Object obj ,bool TimedOut )
	{
        // Show that process is running in green.
        lblMutexThreadStatus.Text = "Running";
        lblMutexThreadStatus.ForeColor = Color.Green;
        // Update ThreadNum label with current thread number.  GetHashCode will contain
        // a unique value for each thread.
        lblMutexThreadNum.Text = Thread.CurrentThread.GetHashCode().ToString();
        // Update the IsThreadPooled label with Yes/No depending on whether the current
        // thread is a pool thread.

		if (Thread.CurrentThread.IsThreadPoolThread)
		{
			lblMutexIsPoolThread.Text = "Yes";
		}
		else 
		{
			lblMutexIsPoolThread.Text = "No";
		}

        // Put the current thread to sleep for 2 seconds.
        System.Threading.Thread.Sleep(2000);
        // Show that the process is inactive in read.
        lblMutexThreadStatus.Text = "Inactive";
        lblMutexThreadStatus.ForeColor = Color.Red;

        // Dispose of the mutex.
        mutex1.Close();
        // Reenable the WaitForMutex button.
        btnWaitForMutex.Enabled = true;
    }


//
//    // This is the subroutine that is called when all three processes are finished.
	
    private void OnProcessesCompleted()
	{
        // Get the number of seconds the processes took to run, and fill in the label.
        double secondsElapsed  = ProcessGroup.GetTicksElapsed / 1000;
        lblSecondsElapsed.Text = secondsElapsed.ToString();
        // Enable all of the process buttons.
        btnNonthreaded.Enabled = true;
        btnThreaded.Enabled = true;
        btnThreadPool.Enabled = true;
        // Reset the processed to run again.
        ProcessGroup.PrepareToRun();
    }

	private void FunctionTabPage_Click(object sender, System.EventArgs e)
	{
	
	}

	private void TimersTabPage_Click(object sender, System.EventArgs e)
	{
	
	}
}

