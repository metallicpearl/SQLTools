using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;
using DapperExtensions;
using System.Data.Common;
using System.IO;
using System.Data;
using ADO.Net;
using System.Diagnostics;
using System.Windows.Input;
using WindowsInput;
using WindowsInput.Native;
using System.Text;
using System.Timers;
using System.Linq;
using System.Windows;

namespace WinFormsApp1
{

    /// <summary>
    ///FORM CLASS
    /// </summary>

    public partial class Form1 : Form
    {


        /// <summary>
        /// Initialisation
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.WorkerSupportsCancellation = true;

            backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
            backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);
            backgroundWorker2.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker2_ProgressChanged);
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;

            backgroundWorker3.DoWork += new DoWorkEventHandler(backgroundWorker3_DoWork);
            backgroundWorker3.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker3_RunWorkerCompleted);
            //backgroundWorker3.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker3_ProgressChanged);
            backgroundWorker3.WorkerReportsProgress = true;
            backgroundWorker3.WorkerSupportsCancellation = true;

            backgroundWorker4.DoWork += new DoWorkEventHandler(backgroundWorker4_DoWork);
            backgroundWorker4.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker4_RunWorkerCompleted);
            //backgroundWorker4.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker4_ProgressChanged);
            backgroundWorker4.WorkerSupportsCancellation = true;

            backgroundWorker5.DoWork += new DoWorkEventHandler(backgroundWorker5_DoWork);
            backgroundWorker5.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker5_RunWorkerCompleted);
            //backgroundWorker4.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker4_ProgressChanged);
            backgroundWorker5.WorkerSupportsCancellation = true;

            backgroundWorker6.DoWork += new DoWorkEventHandler(backgroundWorker6_DoWork);
            backgroundWorker6.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker6_RunWorkerCompleted);
            //backgroundWorker4.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker4_ProgressChanged);
            backgroundWorker6.WorkerSupportsCancellation = true;

            textBox9.Visible = false;
            textBox9.ForeColor = Color.Red;
            textBox10.Visible = false;
            textBox10.ForeColor = Color.Red;
            autocomplete = false;

            checkforfile();

        }


        /// <summary>
        /// Non-SQL String declarations
        /// </summary>

        public string resultas;
        public DataAdapter dataAdap;
        public DataTable dta;
        public DataTable dta2;
        public DataTable dta3;
        public DataSet dsa;
        public string connex;
        public string sqlcomm;
        public string sqlcomm2;
        public string ar;
        public string sqlcommarith;
        public string f3v;
        public string f4v;
        public string f5v;
        public string f6v;
        private static AutoResetEvent event_1 = new AutoResetEvent(true);
        public string hold;
        public static string f1v;
        public static string f2v;
        public string ctp;
        public string res;
        public string s;
        public string d;
        public string u;
        public string p;
        public string ins;
        public string t;
        public string pl;
        public string searchmode = "partial";
        public string lastsearched;
        public string errormessages;
        public bool relationshipsearchsuccess;
        public string? builtpath;
        public bool actualclick;
        public string holdingpath;
        public bool endpressed;
        public int sqltextindex;
        public string laswor;
        public string currentword;
        public string[] holds;
        public string quer;
        public string quer2;
        public bool f5pressed;
        public bool busy;
        public int indexes;
        public System.Timers.Timer timer;
        public bool autocomplete;
        public int currentcaretposition;
        public bool autocompletebusy;
        public int currentlen;
        public int lineIndex;
        public int splitint;
        public int lastspacebeforetext;
        public int caretposition;
        public bool checkinglinepos;
        public int splits;
        public int lsp;
        public string beforetext;
        public string indexchar;
        public bool containsreturn;
        public string addchar;
        public bool newlineonened;

        public List<string> tablelist;
        public List<string> columnlist;

        /// <summary>
        /// SQL declarations
        /// </summary>





        public string sqlquery1 =

            @"
            Begin Transaction    
            ";

        public string sqlquery2 =

            @"
            Rollback
            ";


        public string sql1 =
         @"
                
                

                SELECT 
                c.TABLE_NAME AS 'Table Name',
                c.COLUMN_NAME AS 'Column Name'
                FROM INFORMATION_SCHEMA.COLUMNS c
                WHERE 
                c.TABLE_NAME LIKE '%";


        public string sql2 =
              @"%' 
                AND 
                c.COLUMN_NAME LIKE '%";


        public string sql3 =
              @"%' 
                GROUP BY c.COLUMN_NAME, c.TABLE_NAME
                ORDER BY 
                c.Table_Name

                OPTION (RECOMPILE)
                ";


        public string sql4 =
              @"
                

                SELECT 
                c.COLUMN_NAME AS 'Column Name',
                c.TABLE_NAME AS 'Table Name'
                FROM INFORMATION_SCHEMA.COLUMNS c
                WHERE 
                c.COLUMN_NAME LIKE '%";


        public string sql5 =

                @"DECLARE @SearchStr nvarchar(100) = '";

        public string sql6 =
                        @"'

                    
               
                DECLARE @Results TABLE(ColumnName nvarchar(370), ColumnValue nvarchar(3630))

                SET NOCOUNT ON

                DECLARE @TableName nvarchar(256), @ColumnName nvarchar(128), @SearchStr2 nvarchar(110)
                SET  @TableName = ''
                SET @SearchStr2 = QUOTENAME('%' + @SearchStr + '%', '''')

                WHILE @TableName IS NOT NULL

                BEGIN
                    SET @ColumnName = ''
                    SET @TableName =
                    (
                        SELECT MIN(QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME))
                        FROM     INFORMATION_SCHEMA.TABLES
                        WHERE         TABLE_TYPE = 'BASE TABLE'
                            AND    QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME) > @TableName
                            AND    OBJECTPROPERTY(
                                    OBJECT_ID(
                                        QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME)
                                         ), 'IsMSShipped'
                                           ) = 0
                    )

                    WHILE(@TableName IS NOT NULL) AND(@ColumnName IS NOT NULL)

                    BEGIN
                        SET @ColumnName =
                        (
                            SELECT MIN(QUOTENAME(COLUMN_NAME))
                            FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE         TABLE_SCHEMA = PARSENAME(@TableName, 2)
                                AND TABLE_NAME = PARSENAME(@TableName, 1)
                                AND DATA_TYPE IN('char', 'varchar', 'nchar', 'nvarchar', 'int', 'decimal')
                                AND QUOTENAME(COLUMN_NAME) > @ColumnName
                        )

                        IF @ColumnName IS NOT NULL

                        BEGIN
                            INSERT INTO @Results
                            EXEC
                            (
                                'SELECT ''' + @TableName + '.' + @ColumnName + ''', LEFT(' + @ColumnName + ', 3630) 
                                FROM ' + @TableName + '(NOLOCK) ' +
                                ' WHERE ' + @ColumnName + ' LIKE ' + @SearchStr2
                            )
                        END
                    END
                END

                SELECT 
                replace(replace(replace(replace(ColumnName,'[dbo].',''),'.',' > '),'[',''),']','') AS [Column Path],
                ColumnValue AS [Column Value]

                FROM @Results

                GROUP BY ColumnName, ColumnValue

                    OPTION (RECOMPILE)
                ";


        public string sql7 =
                            @"
                declare  

                @table varchar (50) 

                select 

                @table = '";

        public string sql8 =
        @"' 



SELECT
  
	tab2.name AS [Referenced table],
    col2.name AS [Referenced column],
    tab1.name AS [Referencing table],
    col1.name AS [Referencing column]

FROM sys.foreign_key_columns fkc
INNER JOIN sys.objects obj
    ON obj.object_id = fkc.constraint_object_id
INNER JOIN sys.tables tab1
    ON tab1.object_id = fkc.parent_object_id
INNER JOIN sys.schemas sch
    ON tab1.schema_id = sch.schema_id
INNER JOIN sys.columns col1
    ON col1.column_id = parent_column_id AND col1.object_id = tab1.object_id
INNER JOIN sys.tables tab2
    ON tab2.object_id = fkc.referenced_object_id
INNER JOIN sys.columns col2
    ON col2.column_id = referenced_column_id AND col2.object_id = tab2.object_id
                where tab2.[name] = @table";


        public string sql1b =
 @"

                SELECT 
                c.TABLE_NAME AS 'Table Name',
                c.COLUMN_NAME AS 'Column Name'
                FROM INFORMATION_SCHEMA.COLUMNS c
                WHERE 
                c.TABLE_NAME = '";


        public string sql2b =
              @"' 
                AND 
                c.COLUMN_NAME = '";


        public string sql3b =
              @"' 
                GROUP BY c.COLUMN_NAME, c.TABLE_NAME
                ORDER BY 
                c.Table_Name

                OPTION (RECOMPILE)
                ";


        public string sql4b =
              @"
                SELECT 
                c.COLUMN_NAME AS 'Column Name',
                c.TABLE_NAME AS 'Table Name'
                FROM INFORMATION_SCHEMA.COLUMNS c
                WHERE 
                c.COLUMN_NAME = '";


        public string sql5b =

                @"DECLARE @SearchStr nvarchar(100) = '";

        public string sql6b =
                                    @"'
                DECLARE @Results TABLE(ColumnName nvarchar(370), ColumnValue nvarchar(3630))

                SET NOCOUNT ON

                DECLARE @TableName nvarchar(256), @ColumnName nvarchar(128), @SearchStr2 nvarchar(110)
                SET  @TableName = ''
                SET @SearchStr2 = QUOTENAME('' + @SearchStr + '', '''')

                WHILE @TableName IS NOT NULL

                BEGIN
                    SET @ColumnName = ''
                    SET @TableName =
                    (
                        SELECT MIN(QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME))
                        FROM     INFORMATION_SCHEMA.TABLES
                        WHERE         TABLE_TYPE = 'BASE TABLE'
                            AND    QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME) > @TableName
                            AND    OBJECTPROPERTY(
                                    OBJECT_ID(
                                        QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME)
                                         ), 'IsMSShipped'
                                           ) = 0
                    )

                    WHILE(@TableName IS NOT NULL) AND(@ColumnName IS NOT NULL)

                    BEGIN
                        SET @ColumnName =
                        (
                            SELECT MIN(QUOTENAME(COLUMN_NAME))
                            FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE         TABLE_SCHEMA = PARSENAME(@TableName, 2)
                                AND TABLE_NAME = PARSENAME(@TableName, 1)
                                AND DATA_TYPE IN('char', 'varchar', 'nchar', 'nvarchar', 'int', 'decimal')
                                AND QUOTENAME(COLUMN_NAME) > @ColumnName
                        )

                        IF @ColumnName IS NOT NULL

                        BEGIN
                            INSERT INTO @Results
                            EXEC
                            (
                                'SELECT ''' + @TableName + '.' + @ColumnName + ''', LEFT(' + @ColumnName + ', 3630) 
                                FROM ' + @TableName + '(NOLOCK) ' +
                                ' WHERE ' + @ColumnName + ' LIKE ' + @SearchStr2
                            )
                        END
                    END
                END

                SELECT 
                replace(replace(replace(replace(ColumnName,'[dbo].',''),'.',' > '),'[',''),']','') AS [Column Path],
                ColumnValue AS [Column Value]

                FROM @Results

                GROUP BY ColumnName, ColumnValue

                    OPTION (RECOMPILE)
                ";


        public string sql7b =
            @"

SELECT  
	tab2.name AS [Referenced table],
    col2.name AS [Referenced column],
    tab1.name AS [Referencing table],
    col1.name AS [Referencing column]

FROM sys.foreign_key_columns fkc
INNER JOIN sys.objects obj
    ON obj.object_id = fkc.constraint_object_id
INNER JOIN sys.tables tab1
    ON tab1.object_id = fkc.parent_object_id
INNER JOIN sys.schemas sch
    ON tab1.schema_id = sch.schema_id
INNER JOIN sys.columns col1
    ON col1.column_id = parent_column_id AND col1.object_id = tab1.object_id
INNER JOIN sys.tables tab2
    ON tab2.object_id = fkc.referenced_object_id
INNER JOIN sys.columns col2
    ON col2.column_id = referenced_column_id AND col2.object_id = tab2.object_id
WHERE tab2.name
LIKE '%";

        public string sql8b = "%'";




        /// <summary>
        /// Constructor for connection strings
        /// </summary>


        public Form1(string server, string database, string username, string password, string security)
        {
            s = server;
            d = database;
            u = username;
            p = password;
            ins = security;
        }


        /// <summary>
        /// Pass to BGWorkers
        /// </summary>


        public void passtobgworker(object sender, EventArgs e)
        {
            startAsyncButton_Click(sender, e);
        }


        public void passtobgworker2(object sender, EventArgs e)
        {
            startAsyncButton_Click2(sender, e);
        }


        public void passtobgworker3(object sender, EventArgs e)
        {
            startAsyncButton_Click3(sender, e);
        }


        void backgroundWorker1_cancel(object sender, EventArgs e)
        {
        }

        public void forclosing(object sender, EventArgs e)

        {
            Application.Restart();
        }



        /// <summary>
        /// Tab 1
        /// </summary>


        public void checkforfile()
        {

            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("TestFile.txt"))
                {

                    string line = sr.ReadLine();
                    string srv = line.Split(',')[0];
                    string db = line.Split(',')[1];
                    string un = line.Split(',')[2];
                    string pw = line.Split(',')[3];
                    string auth = line.Split(',')[4];

                    textBox1.Text = srv;
                    textBox2.Text = db;
                    textBox3.Text = un;
                    textBox4.Text = pw;

                    if (auth != null)
                    {
                        if (auth == "windows")
                        {
                            radioButton1.Checked = true;
                            radioButton2.Checked = false;
                            textBox3.ReadOnly = true;
                            textBox4.ReadOnly = true;
                        }
                        if (auth == "sql")
                        {
                            radioButton1.Checked = false;
                            radioButton2.Checked = true;
                        }

                    }



                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Override file format is incorrect or not in the application folder.");
            }

        }


        async void startAsyncButton_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            label11.Visible = true;
            label14.Visible = false;
            label12.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            this.label17.Location = new System.Drawing.Point(268, 112);
            this.label17.Text = "Not Connected";
            this.label17.TextAlign = ContentAlignment.TopRight;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView3.ColumnHeadersVisible = false;
            this.dataGridView4.ColumnHeadersVisible = false;
            this.dataGridView5.ColumnHeadersVisible = false;
            this.dataGridView6.ColumnHeadersVisible = false;
            contextMenuStrip1.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            contextMenuStrip2.Enabled = false;
            toolStripMenuItem2.Enabled = false;
            contextMenuStrip3.Enabled = false;
            CopyCell.Enabled = false;
            CopyColumn.Enabled = false;
            CopyRow.Enabled = false;

            sqlcomm = "";
            endpressed = false;

            if (dta != null)
            {
                dta.Clear();
            }


            if (backgroundWorker1.IsBusy != true)
            {
                try
                {
                    backgroundWorker1.RunWorkerAsync();

                }
                catch (Exception ex)
                {


                }
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                {
                    if (radioButton1.Checked == true)
                    {
                        Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", "; Trusted_Connection=True;");
                        connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.ins).ToString();
                    }

                    else if (radioButton2.Checked == true)
                    {
                        Form1 connectionstring = new Form1("Server=", "; Database=", "; User Id=", "; Password=", ";");
                        connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.u + textBox3.Text + connectionstring.p + textBox4.Text + connectionstring.ins).ToString();

                    }

                    BackgroundWorker worker = sender as BackgroundWorker;
                    if (worker != null)

                        try
                        {
                            SqlConnection cmd = new SqlConnection(connex);

                            try
                            {
                                if (radioButton7.Checked == true)

                                {

                                    if (radioButton3.Checked == true)
                                    {
                                        sqlcomm = (sql1 + textBox5.Text.ToString() + sql3);
                                    }
                                    if (radioButton4.Checked == true)
                                    {
                                        sqlcomm = (sql4 + textBox7.Text.ToString() + sql3);
                                    }
                                    if (radioButton5.Checked == true)
                                    {
                                        sqlcomm = (sql1 + textBox5.Text.ToString() + sql2 + textBox7.Text.ToString() + sql3);
                                    }
                                }


                                if (radioButton6.Checked == true)

                                {

                                    if (radioButton3.Checked == true)
                                    {
                                        sqlcomm = (sql1b + textBox5.Text.ToString() + sql3b);
                                    }
                                    if (radioButton4.Checked == true)
                                    {
                                        sqlcomm = (sql4b + textBox7.Text.ToString() + sql3b);
                                    }
                                    if (radioButton5.Checked == true)
                                    {
                                        sqlcomm = (sql1b + textBox5.Text.ToString() + sql2b + textBox7.Text.ToString() + sql3b);
                                    }
                                }


                                SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd);
                                SqlDataAdapter adapter = new SqlDataAdapter();
                                static void OpenAndSetArithAbort(SqlConnection cmd)
                                {

                                    using (SqlCommand cmd2 = cmd.CreateCommand())
                                    {
                                        cmd2.CommandType = CommandType.Text;
                                        cmd2.CommandText = "SET ARITHABORT ON";
                                        cmd2.CommandTimeout = 0;

                                        cmd.Open();


                                        cmd2.ExecuteNonQuery();
                                    }

                                    return;
                                }

                                OpenAndSetArithAbort(cmd);

                                if (cmd.State == ConnectionState.Open)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connected";
                                        this.label17.Location = new System.Drawing.Point(288, 112);
                                        this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                    }
                                 );


                                    if (cmd == null)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connection Failed";
                                            this.label17.Location = new System.Drawing.Point(255, 112);
                                            this.label17.ForeColor = System.Drawing.Color.DarkRed;
                                        }
                                     );

                                    }

                                }
                                adapter.SelectCommand = cmd1;
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);

                                foreach (DataColumn dc in ds.Columns)
                                {

                                    foreach (DataRow dr in ds.Rows)
                                    {

                                        {
                                            dta = dr.Table;
                                            dta.AcceptChanges();

                                            if (worker.CancellationPending == true)
                                            {
                                                e.Result = null;
                                                cmd.Close();
                                                return;
                                            }

                                            if (worker.CancellationPending == false)
                                            {
                                                e.Result = true;
                                                return;
                                            }

                                        }
                                    }
                                    return;

                                }

                            }

                            catch (Exception ex)

                            {

                                if (worker.CancellationPending == true)

                                    return;

                                {
                                    string msg = ex.Message;
                                    MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);

                                }
                            }
                            finally
                            {
                                cmd.Close();
                            }


                        }
                        catch (Exception ex)
                        {
                            string msg = "Please enter valid connection details.";
                            MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                        }
                }
                return;
            }
        }


        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            label11.Visible = false;
            label12.Visible = false;
            button3.Enabled = false;
        }


        async void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            {

                {
                    ctp = "ctp1";
                    button3.Enabled = true;
                    button3.Text = "Results to Clipboard";
                    label11.Visible = false;
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    label11.Text = "Working...";
                    ctp = "ctp1";


                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();
                    if (dta != null)
                    {
                        contextMenuStrip1.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        dta = dta.Copy();
                        dataGridView1.DataSource = dta;
                        this.dataGridView1.ColumnHeadersVisible = true;

                        if (dta.Rows.Count < 1)
                        {
                            label12.Visible = true;
                        }
                    }

                    if (dta is null)
                    {
                        label12.Visible = true;
                        this.dataGridView1.ColumnHeadersVisible = false;
                        button3.Enabled = false;
                    }

                    if (label12.Visible == true)
                    {
                        this.dataGridView1.ColumnHeadersVisible = false;
                        button3.Enabled = false;
                        contextMenuStrip1.Enabled = false;
                        toolStripMenuItem1.Enabled = false;
                        contextMenuStrip2.Enabled = false;
                        toolStripMenuItem2.Enabled = false;
                    }

                }
            }
        }


        /// <summary>
        /// Tab 2
        /// </summary>

        async void startAsyncButton_Click2(object sender, EventArgs e)

        {
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView3.ColumnHeadersVisible = false;

            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            label13.Visible = true;
            label12.Visible = false;
            label14.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            this.label17.Location = new System.Drawing.Point(268, 112);
            this.label17.Text = "Not Connected";
            this.label17.TextAlign = ContentAlignment.TopRight;
            this.label17.ForeColor = System.Drawing.Color.Black;
            contextMenuStrip1.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            contextMenuStrip2.Enabled = false;
            toolStripMenuItem2.Enabled = false;


            sqlcomm = "";

            if (dta != null)
            {
                dta.Clear();
            }


            if (backgroundWorker2.IsBusy != true)
            {
                try
                {
                    backgroundWorker2.RunWorkerAsync();
                }
                catch (Exception ex)
                {


                }
            }
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            {
                if (radioButton1.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", "; Trusted_Connection=True;");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.ins).ToString();
                }

                else if (radioButton2.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; User Id=", "; Password=", ";");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.u + textBox3.Text + connectionstring.p + textBox4.Text + connectionstring.ins).ToString();
                }

                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker != null)

                    try
                    {
                        using (SqlConnection cmd = new SqlConnection(connex))
                        {
                            try
                            {
                                if (radioButton6.Checked == true)
                                {
                                    sqlcomm = (sql5b + textBox8.Text + sql6b);
                                }

                                if (radioButton7.Checked == true)
                                {
                                    sqlcomm = (sql5 + textBox8.Text + sql6);
                                }

                                SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd);
                                cmd1.CommandTimeout = 0;
                                SqlDataAdapter adapter = new SqlDataAdapter();

                                static void OpenAndSetArithAbort(SqlConnection cmd)
                                {

                                    using (SqlCommand cmd2 = cmd.CreateCommand())
                                    {
                                        cmd2.CommandType = CommandType.Text;
                                        cmd2.CommandText = "SET ARITHABORT ON";
                                        cmd.Open();
                                        cmd2.ExecuteNonQuery();
                                    }

                                    return;
                                }


                                OpenAndSetArithAbort(cmd);

                                if (cmd1.Connection.State == ConnectionState.Open)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connected";
                                        this.label17.Location = new System.Drawing.Point(288, 112);
                                        this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                    }
                                 );
                                }

                                adapter.SelectCommand = cmd1;
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);

                                foreach (DataColumn dc in ds.Columns)
                                {

                                    foreach (DataRow dr in ds.Rows)
                                    {

                                        {
                                            dta = dr.Table;
                                            dta.AcceptChanges();

                                            if (worker.CancellationPending == true)
                                            {

                                                cmd.Close();
                                                e.Result = null;
                                                return;

                                            }

                                            if (worker.CancellationPending == false)

                                            {
                                                e.Result = true;
                                                return;

                                            }
                                        }
                                    }

                                }

                            }

                            catch (Exception ex)

                            {
                                if (worker.CancellationPending == true)

                                    return;

                                if (ex.Message != null)
                                {
                                    string msg = ex.Message;
                                    MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);

                                }
                            }
                            finally
                            {
                                cmd.Close();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = "Please enter valid connection details.";
                        MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                    }

            }
            return;
        }


        void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {


            label13.Visible = false;
            label14.Visible = false;
            button3.Enabled = false;

        }

        async void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            {
                ctp = "ctp2";
                button3.Enabled = true;
                button3.Text = "Results to Clipboard";
                button2.Enabled = true;
                button1.Enabled = true;
                button4.Enabled = true;
                label13.Text = "Working...";
                label13.Visible = false;
                SqlConnection cmd = new SqlConnection();
                cmd.Close();
                if (dta != null)
                {
                    dta = dta.Copy();
                    dataGridView2.DataSource = dta;
                    this.dataGridView2.ColumnHeadersVisible = true;

                    if (dta.Rows.Count < 1)
                    {
                        label14.Visible = true;
                    }
                }

                if (dta is null)
                {
                    label14.Visible = true;
                    this.dataGridView2.ColumnHeadersVisible = false;
                    button3.Enabled = false;
                }

                if (label14.Visible == true)
                {
                    this.dataGridView2.ColumnHeadersVisible = false;
                    button3.Enabled = false;
                    contextMenuStrip1.Enabled = false;
                    toolStripMenuItem1.Enabled = false;
                    contextMenuStrip2.Enabled = false;
                    toolStripMenuItem2.Enabled = false;
                }
            }
        }


        /// <summary>
        /// Tab 3
        /// </summary>

        async void startAsyncButton_Click3(object sender, EventArgs e)
        {
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView3.ColumnHeadersVisible = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            label18.Visible = true;
            label19.Visible = false;
            //label12.Visible = false;
            //label14.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            this.label17.Location = new System.Drawing.Point(268, 112);
            this.label17.Text = "Not Connected";
            this.label17.TextAlign = ContentAlignment.TopRight;
            this.label17.ForeColor = System.Drawing.Color.Black;
            contextMenuStrip1.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            contextMenuStrip2.Enabled = false;
            toolStripMenuItem2.Enabled = false;
            sqlcomm = "";

            if (dta != null)
            {
                dta.Clear();
            }


            if (backgroundWorker3.IsBusy != true)
            {
                try
                {
                    backgroundWorker3.RunWorkerAsync();
                }
                catch (Exception ex)
                {


                }
            }
        }
        void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {


            {
                {
                    if (radioButton1.Checked == true)
                    {
                        Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", "; Trusted_Connection=True;");
                        connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.ins).ToString();
                    }

                    else if (radioButton2.Checked == true)
                    {
                        Form1 connectionstring = new Form1("Server=", "; Database=", "; User Id=", "; Password=", ";");
                        connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.u + textBox3.Text + connectionstring.p + textBox4.Text + connectionstring.ins).ToString();

                    }

                    BackgroundWorker worker = sender as BackgroundWorker;
                    if (worker != null)

                        try
                        {
                            SqlConnection cmd = new SqlConnection(connex);


                            if (radioButton6.Checked == true)
                            {
                                sqlcomm = (sql7 + textBox6.Text.ToString() + sql8);
                            }

                            else if (radioButton7.Checked == true)
                            {
                                sqlcomm = (sql7b + textBox6.Text.ToString() + sql8b);
                            }

                            try
                            {





                                SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd);
                                SqlDataAdapter adapter = new SqlDataAdapter();
                                static void OpenAndSetArithAbort(SqlConnection cmd)
                                {

                                    using (SqlCommand cmd2 = cmd.CreateCommand())
                                    {
                                        cmd2.CommandType = CommandType.Text;
                                        cmd2.CommandText = "SET ARITHABORT ON";
                                        cmd2.CommandTimeout = 0;

                                        cmd.Open();


                                        cmd2.ExecuteNonQuery();
                                    }

                                    return;
                                }

                                OpenAndSetArithAbort(cmd);

                                if (cmd.State == ConnectionState.Open)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connected";
                                        this.label17.Location = new System.Drawing.Point(288, 112);
                                        this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                    }
                                 );


                                    if (cmd == null)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connection Failed";
                                            this.label17.Location = new System.Drawing.Point(255, 112);
                                            this.label17.ForeColor = System.Drawing.Color.DarkRed;
                                        }
                                     );

                                    }

                                }
                                adapter.SelectCommand = cmd1;
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);

                                foreach (DataColumn dc in ds.Columns)
                                {

                                    foreach (DataRow dr in ds.Rows)
                                    {

                                        {
                                            dta = dr.Table;
                                            dta.AcceptChanges();

                                            e.Result = true;
                                            return;


                                        }
                                    }

                                    return;
                                }

                            }

                            catch (Exception ex)

                            {

                                if (worker.CancellationPending == true)

                                    return;

                                {
                                    string msg = ex.Message;
                                    MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);

                                }
                            }
                            finally
                            {
                                cmd.Close();

                            }


                        }
                        catch (Exception ex)
                        {
                            string msg = "Please enter valid connection details.";
                            MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                        }
                }
                return;
            }


        }
        void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            {
                ctp = "ctp3";
                button3.Enabled = true;
                button3.Text = "Results to Clipboard";
                button2.Enabled = true;
                button1.Enabled = true;
                button4.Enabled = true;
                label18.Text = "Working...";
                label18.Visible = false;
                SqlConnection cmd = new SqlConnection();
                cmd.Close();




                if (dta != null)
                {

                    contextMenuStrip2.Enabled = true;
                    toolStripMenuItem2.Enabled = true;
                    dta = dta.Copy();
                    dataGridView3.DataSource = dta;
                    this.dataGridView3.ColumnHeadersVisible = true;
                    relationshipsearchsuccess = true;
                    button7.Enabled = true;
                    button7.Text = "Copy Search Term History to Clipboard";

                    if (builtpath == null && dataGridView3.RowCount < 1)
                    {
                        builtpath = ("--START OF SEARCH--" + Environment.NewLine + textBox6.Text// + " < [Initial Search Term]"
                            );

                    }


                    if (builtpath == null && dataGridView3 != null)
                    {
                        builtpath = ("--START OF SEARCH--" + Environment.NewLine + textBox6.Text + "[Initial Search Term]" + Environment.NewLine + "Table: " + dataGridView3.SelectedCells[0].Value + " | Column: " + dataGridView3.SelectedCells[1].Value);

                    }




                    if (builtpath != null && dataGridView3.SelectedCells.Count != 0 && builtpath != "--START OF SEARCH--" + Environment.NewLine + textBox6.Text + "[Initial Search Term]" + Environment.NewLine + "Table: " + dataGridView3.SelectedCells[0].Value + " | Column: " + dataGridView3.SelectedCells[1].Value)


                    {
                        builtpath += (Environment.NewLine + "Table: " + dataGridView3.SelectedCells[0].Value + " | Column: " + dataGridView3.SelectedCells[1].Value);
                    }

                    if (builtpath == null)
                    {
                        builtpath += textBox6.Text;
                    }

                    if (builtpath == "")
                    {

                        builtpath += textBox6.Text;

                    }

                    if (builtpath == (Environment.NewLine).ToString())
                    {
                        Clipboard.Clear();
                        builtpath = textBox6.Text;

                    }

                    if (dta.Rows.Count < 1)
                    {
                        label19.Visible = true;
                        relationshipsearchsuccess = false;
                        //if (builtpath is null)
                        //{
                        //    actualclick = false;
                        //}

                    }


                }



                if (dta is null)
                {
                    label19.Visible = true;
                    this.dataGridView3.ColumnHeadersVisible = false;
                    button3.Enabled = false;
                    relationshipsearchsuccess = false;
                }

                if (label19.Visible == true)
                {
                    this.dataGridView3.ColumnHeadersVisible = false;
                    button3.Enabled = false;
                    contextMenuStrip1.Enabled = false;
                    toolStripMenuItem1.Enabled = false;
                    contextMenuStrip2.Enabled = false;
                    toolStripMenuItem2.Enabled = false;



                }


            }


        }



        /// <summary>
        /// Menu functions
        /// </summary>



        public void clickmenu(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {
                label19.Visible = false;

                int index = new int();

                if (dataGridView1.Columns[0].Name == "Table Name")
                    index = 0;
                if (dataGridView1.Columns[1].Name == "Table Name")
                    index = 1;

                var holding = dataGridView1.SelectedCells[index].Value;
                if (holding != null)
                {
                    textBox6.Text = holding.ToString();
                    tabControl1.SelectedIndex = 2;
                    startAsyncButton_Click3(sender, e);
                    actualclick = true;
                }
            }

            else
                return;

        }

        public void clickmenu2(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0 || dataGridView3.RowCount > 0)
            {
                label19.Visible = false;

                int index = new int();

                if (dataGridView3.Columns[0].Name == "Referencing Table")
                    index = 0;
                if (dataGridView3.Columns[1].Name == "Referencing")
                    index = 1;

                var holding = dataGridView3.SelectedCells[index].Value;
                if (holding != null)
                {
                    //builtpath += textBox6.Text;
                    textBox6.Text = holding.ToString();
                    tabControl1.SelectedIndex = 2;
                    startAsyncButton_Click3(sender, e);
                    actualclick = false;
                }
            }

            else
                return;

        }



        /// <summary>
        /// Copy functions
        /// </summary>


        public void builtpathcopy(object sender, EventArgs e)
        {


            if (builtpath != null)
            {
                builtpath += Environment.NewLine + "--END OF SEARCH--";
                Clipboard.SetText(builtpath);
                button7.Enabled = false;
                button7.Text = "Copied to Clipboard";
                builtpath = null;
            }

            if (builtpath == null)
            {
                return;

            }
        }






        void copyresults(object sender, EventArgs e)

        {


            if (dta is not null && tabControl1.SelectedTab == this.tabPage4)

            {
                if (String.Equals(ctp, "ctp4"))
                {

                    var newline = System.Environment.NewLine;
                    var tab = "\t";
                    var clipboard_string = new StringBuilder();



                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i == (row.Cells.Count - 1))
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + newline);
                            else
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + ",");
                        }
                    }
                    button3.Enabled = false;
                    button3.Text = "Results Copied";


                    if (clipboard_string != null)
                        Clipboard.SetText(clipboard_string.ToString());

                    if (clipboard_string == null)
                    {
                        return;
                    }



                    if (dta == null)
                    {
                        return;
                    }

                }

                if (!(String.Equals(ctp, "ctp4")))
                {
                    return;
                }
            }




            if (dta is not null && tabControl1.SelectedTab == this.tabPage1)

            {
                if (String.Equals(ctp, "ctp1"))
                {

                    var newline = System.Environment.NewLine;
                    var tab = "\t";
                    var clipboard_string = new StringBuilder();



                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i == (row.Cells.Count - 1))
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + newline);
                            else
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + ",");
                        }
                    }
                    button3.Enabled = false;
                    button3.Text = "Results Copied";


                    if (clipboard_string != null)
                        Clipboard.SetText(clipboard_string.ToString());

                    if (clipboard_string == null)
                    {
                        return;
                    }



                    if (dta == null)
                    {
                        return;
                    }

                }

                if (!(String.Equals(ctp, "ctp1")))
                {
                    return;
                }
            }




            if (dta is not null && tabControl1.SelectedTab == this.tabPage2)

            {
                if (String.Equals(ctp, "ctp2"))


                {
                    var newline = System.Environment.NewLine;
                    var tab = "\t";
                    var clipboard_string = new StringBuilder();

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i == (row.Cells.Count - 1))
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + newline);
                            else
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + ",");
                        }
                    }

                    button3.Enabled = false;
                    button3.Text = "Results Copied";

                    if (clipboard_string == null)
                    {
                        return;
                    }
                    if (clipboard_string != null)
                        Clipboard.SetText(clipboard_string.ToString());
                }

                if (dta == null)
                {
                    return;
                }

                if (!(String.Equals(ctp, "ctp2")))
                {
                    return;
                }
            }

            if (dta is not null && tabControl1.SelectedTab == this.tabPage3)

            {
                if (String.Equals(ctp, "ctp3"))




                {

                    var newline = System.Environment.NewLine;
                    var tab = "\t";
                    var clipboard_string = new StringBuilder();

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i == (row.Cells.Count - 1))
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + newline);
                            else
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + ",");
                        }
                    }

                    button3.Enabled = false;
                    button3.Text = "Results Copied";

                    if (clipboard_string == null)
                    {
                        return;
                    }
                    if (clipboard_string != null)
                        Clipboard.SetText(clipboard_string.ToString());
                }

                if (dta == null)
                {
                    return;
                }


                if (!(String.Equals(ctp, "ctp3")))
                {
                    return;
                }

            }


        }


        /// <summary>
        /// Other functions
        /// </summary>


        public void torestart(object sender, EventArgs e)
        {
            button5.Text = "Restarting...";
            button5.Enabled = false;
            Thread.Sleep(500);
            forclosing(sender, e);

        }



        public void checkenter1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }



        public void checkenter2(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }


        public void checkenter3(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }



        void Authentication_Value(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                Set_ReadOnly_For_SQL(sender, e);
            else if
                (radioButton2.Checked == true)
                Set_Editable_For_Windows(sender, e);
        }


        void Search_Type(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
                Set_Search_Table(sender, e);
            else if
                (radioButton4.Checked == true)
                Set_Search_Column(sender, e);
            else if
                (radioButton5.Checked == true)
                Set_Search_Both(sender, e);
        }


        void Set_ReadOnly_For_SQL(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
        }

        void Set_Editable_For_Windows(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        void Set_Search_Table(object sender, EventArgs e)
        {
            textBox7.ReadOnly = true;
            textBox7.Clear();
            textBox5.ReadOnly = false;
        }

        void Set_Search_Column(object sender, EventArgs e)
        {
            textBox7.ReadOnly = false;
            textBox5.ReadOnly = true;
            textBox5.Clear();
        }


        void Set_Search_Both(object sender, EventArgs e)
        {
            textBox7.ReadOnly = false;
            textBox5.ReadOnly = false;
        }


        private void searchingCheckedChanged(object sender, EventArgs e)
        {

            if (radioButton6.Checked == true)
            {

                exactmatch(sender, e);
            }

            else if (radioButton7.Checked == true)
            {

                partialmatch(sender, e);
            }

        }


        private void partialmatch(object sender, EventArgs e)
        {
            radioButton6.Checked = false;
            searchmode = "partial";
        }


        private void exactmatch(object sender, EventArgs e)
        {
            radioButton7.Checked = false;
            searchmode = "exact";
        }


        private void differentiatesearch(object sender, EventArgs e)
        {
            builtpath = null;
            startAsyncButton_Click3(sender, e);
        }


        void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {

                e.SuppressKeyPress = true;
            }
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = false;


        }












        private void dotextstuff(object sender, EventArgs e)
        {
            //string lastword = richTextBox1.Text.Substring(richTextBox1.Text.Substring(0, richTextBox1.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);
            //int laswl = lastword.

            string findText = laswor;

            int index = 0;

            int len = laswor.Length;

            int positionOfcarett = caretposition;

            //do
            //{
            index = richTextBox1.Find(findText, index, RichTextBoxFinds.WholeWord);
            if (index > -1)
            {

                richTextBox1.Select(positionOfcarett, -findText.Length);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.DeselectAll();
                richTextBox1.SelectionLength = 0;
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.SelectionStart = positionOfcarett;



                index++;
                //sqltextindex++;

            }




            //} while (index > -1);

            //richTextBox1.ForeColor = Color.Black;
        }



        private void dotextstuffblack(object sender, EventArgs e)
        {
            //string lastword = richTextBox1.Text.Substring(richTextBox1.Text.Substring(0, richTextBox1.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);
            //int laswl = lastword.

            string findText = laswor;
            int index = 0;
            int len = laswor.Length;

            int lineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);

            int positionOfcarett = caretposition;

            // do
            //{
            lineIndex = richTextBox1.GetFirstCharIndexOfCurrentLine();

            index = richTextBox1.Find(findText, index, RichTextBoxFinds.WholeWord);
            if (index > -1)
            {

                richTextBox1.Select(positionOfcarett, -findText.Length);
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionLength = 0;
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                //richTextBox1.DeselectAll();
                richTextBox1.SelectionStart = positionOfcarett;


                index++;
                //sqltextindex++;

            }




            //} while (index > -1);

            //richTextBox1.ForeColor = Color.Black;
        }




        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }



        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (lb.Visible == true && e.KeyCode != Keys.Decimal || autocompletebusy == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Decimal)
            {
                if (autocomplete == false)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    getdbdetails(sender, e);
                    getdbdetails(sender, e);

                }
                else if (autocomplete == true)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    lb.Hide();
                    autocomplete = false;
                    //richTextBox1.DeselectAll();

                    if (lb.Items.Count > 0 && lb.Visible == false)
                    {
                        //richTextBox1.SelectedText = null;
                        richTextBox1.SelectionStart = currentcaretposition;

                    }
                }

            }


            if (e.KeyCode == Keys.F5 && busy == true)
            {
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F5 && busy == false)
            {
                busy = true;
                dataGridView4.Refresh();
                richTextBox1.Enabled = false;
                richTextBox1_KeyDowns(sender, e);


            }

            var prochar = new string[45];
            prochar[1] = ".";
            prochar[2] = "$";
            prochar[3] = "^";
            prochar[4] = "{";
            prochar[5] = "[";
            prochar[6] = "(";
            prochar[7] = "|";
            prochar[8] = ")";
            prochar[9] = "*";
            prochar[10] = "+";
            prochar[11] = "?";
            prochar[12] = "\\";
            prochar[13] = "]";
            prochar[14] = "]";
            prochar[15] = "{";
            prochar[16] = "}";
            prochar[17] = "-";
            prochar[18] = "=";
            prochar[19] = "_";
            prochar[20] = "+";
            prochar[21] = "!";
            prochar[22] = "&";
            prochar[23] = "£";
            prochar[24] = "$";
            prochar[25] = "%";
            prochar[26] = "^";
            prochar[27] = "&";
            prochar[28] = "(";
            prochar[29] = ")";
            prochar[30] = "//";
            prochar[31] = "*";
            prochar[32] = "-";
            prochar[33] = "+";
            prochar[34] = "@";
            prochar[35] = "~";
            prochar[36] = "'";
            prochar[37] = "#";
            prochar[38] = "?";
            prochar[39] = Environment.NewLine;
            prochar[40] = "<";
            prochar[41] = ">";




            if (caretposition == 0)
            {
                indexchar = "\n";
            }

            if (caretposition > 0)
            {
                indexchar = " ";
            }


            string rtbnl = richTextBox1.Text.Replace("\n", " ");
            //string rtbn2 = rtbnl.Replace('\\', ' ');
            int ls1 = rtbnl.LastIndexOf(indexchar);
            string[] split1 = rtbnl.Split(indexchar);
            string[] splitrev1 = split1.Reverse().ToArray();


            if (splitrev1.Length > 0)
            {

                holds = splitrev1.Skip(0).ToArray();
            }

            else
            {
                holds = splitrev1;
            }

            if (holds[0] == " ")
            {

            }

            string seclas1 = holds[0].Replace(Environment.NewLine, " ");

            if ((prochar.Contains(seclas1) == false))
            {

                if (e.KeyCode == Keys.Enter)
                {
                    richTextBox1.ScrollToCaret();
                }


                if ((

                   e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.F5) &&
                   richTextBox1.TextLength > 1 &&
                   f5pressed == false
                   )
                {

                    //InputSimulator ks = new InputSimulator();

                    //int len = richTextBox1.TextLength;

                    var procwords = new string[300];
                    procwords[1] = "ABSOLUTE";
                    procwords[2] = "EXEC";
                    procwords[3] = "OVERLAPS";
                    procwords[4] = "ACTION";
                    procwords[5] = "EXECUTE";
                    procwords[6] = "PAD";
                    procwords[7] = "ADA";
                    procwords[8] = "EXISTS";
                    procwords[9] = "PARTIAL";
                    procwords[10] = "ADD";
                    procwords[11] = "EXTERNAL";
                    procwords[12] = "PASCAL";
                    procwords[13] = "ALL";
                    procwords[14] = "EXTRACT";
                    procwords[15] = "POSITION";
                    procwords[16] = "ALLOCATE";
                    procwords[17] = "FALSE";
                    procwords[18] = "PRECISION";
                    procwords[19] = "ALTER";
                    procwords[20] = "FETCH";
                    procwords[21] = "PREPARE";
                    procwords[22] = "AND";
                    procwords[23] = "FIRST";
                    procwords[24] = "PRESERVE";
                    procwords[25] = "ANY";
                    procwords[26] = "FLOAT";
                    procwords[27] = "PRIMARY";
                    procwords[28] = "ARE";
                    procwords[29] = "FOR";
                    procwords[30] = "PRIOR";
                    procwords[31] = "AS";
                    procwords[32] = "FOREIGN";
                    procwords[33] = "PRIVILEGES";
                    procwords[34] = "ASC";
                    procwords[35] = "FORTRAN";
                    procwords[36] = "PROCEDURE";
                    procwords[37] = "ASSERTION";
                    procwords[38] = "FOUND";
                    procwords[39] = "PUBLIC";
                    procwords[40] = "AT";
                    procwords[41] = "FROM";
                    procwords[42] = "READ";
                    procwords[43] = "AUTHORIZATION";
                    procwords[44] = "FULL";
                    procwords[45] = "REAL";
                    procwords[46] = "AVG";
                    procwords[47] = "GET";
                    procwords[48] = "REFERENCES";
                    procwords[49] = "BEGIN";
                    procwords[50] = "GLOBAL";
                    procwords[51] = "RELATIVE";
                    procwords[52] = "BETWEEN";
                    procwords[53] = "GO";
                    procwords[54] = "RESTRICT";
                    procwords[55] = "BIT";
                    procwords[56] = "GOTO";
                    procwords[57] = "REVOKE";
                    procwords[58] = "BIT_LENGTH";
                    procwords[59] = "GRANT";
                    procwords[60] = "RIGHT";
                    procwords[61] = "BOTH";
                    procwords[62] = "GROUP";
                    procwords[63] = "ROLLBACK";
                    procwords[64] = "BY";
                    procwords[65] = "HAVING";
                    procwords[66] = "ROWS";
                    procwords[67] = "CASCADE";
                    procwords[68] = "HOUR";
                    procwords[69] = "SCHEMA";
                    procwords[70] = "CASCADED";
                    procwords[71] = "IDENTITY";
                    procwords[72] = "SCROLL";
                    procwords[73] = "CASE";
                    procwords[74] = "IMMEDIATE";
                    procwords[75] = "SECOND";
                    procwords[76] = "CAST";
                    procwords[77] = "IN";
                    procwords[78] = "SECTION";
                    procwords[79] = "CATALOG";
                    procwords[80] = "INCLUDE";
                    procwords[81] = "SELECT";
                    procwords[82] = "CHAR";
                    procwords[83] = "INDEX";
                    procwords[84] = "SESSION";
                    procwords[85] = "CHAR_LENGTH";
                    procwords[86] = "INDICATOR";
                    procwords[87] = "SESSION_USER";
                    procwords[88] = "CHARACTER";
                    procwords[89] = "INITIALLY";
                    procwords[90] = "SET";
                    procwords[91] = "CHARACTER_LENGTH";
                    procwords[92] = "INNER";
                    procwords[93] = "SIZE";
                    procwords[94] = "CHECK";
                    procwords[95] = "INPUT";
                    procwords[96] = "SMALLINT";
                    procwords[97] = "CLOSE";
                    procwords[98] = "INSENSITIVE";
                    procwords[99] = "SOME";
                    procwords[100] = "COALESCE";
                    procwords[101] = "INSERT";
                    procwords[102] = "SPACE";
                    procwords[103] = "COLLATE";
                    procwords[104] = "INT";
                    procwords[105] = "SQL";
                    procwords[106] = "COLLATION";
                    procwords[107] = "INTEGER";
                    procwords[108] = "SQLCA";
                    procwords[109] = "COLUMN";
                    procwords[110] = "INTERSECT";
                    procwords[111] = "SQLCODE";
                    procwords[112] = "COMMIT";
                    procwords[113] = "INTERVAL";
                    procwords[114] = "SQLERROR";
                    procwords[115] = "CONNECT";
                    procwords[116] = "INTO";
                    procwords[117] = "SQLSTATE";
                    procwords[118] = "CONNECTION";
                    procwords[119] = "IS";
                    procwords[120] = "SQLWARNING";
                    procwords[121] = "CONSTRAINT";
                    procwords[122] = "ISOLATION";
                    procwords[123] = "SUBSTRING";
                    procwords[124] = "CONSTRAINTS";
                    procwords[125] = "JOIN";
                    procwords[126] = "SUM";
                    procwords[127] = "CONTINUE";
                    procwords[128] = "KEY";
                    procwords[129] = "SYSTEM_USER";
                    procwords[130] = "CONVERT";
                    procwords[131] = "LANGUAGE";
                    procwords[132] = "TABLE";
                    procwords[133] = "CORRESPONDING";
                    procwords[134] = "LAST";
                    procwords[135] = "TEMPORARY";
                    procwords[136] = "COUNT";
                    procwords[137] = "LEADING";
                    procwords[138] = "THEN";
                    procwords[139] = "CREATE";
                    procwords[140] = "LEFT";
                    procwords[141] = "TIME";
                    procwords[142] = "CROSS";
                    procwords[143] = "LEVEL";
                    procwords[144] = "TIMESTAMP";
                    procwords[145] = "CURRENT";
                    procwords[146] = "LIKE";
                    procwords[147] = "TIMEZONE_HOUR";
                    procwords[148] = "CURRENT_DATE";
                    procwords[149] = "LOCAL";
                    procwords[150] = "TIMEZONE_MINUTE";
                    procwords[151] = "CURRENT_TIME";
                    procwords[152] = "LOWER";
                    procwords[153] = "TO";
                    procwords[154] = "CURRENT_TIMESTAMP";
                    procwords[155] = "MATCH";
                    procwords[156] = "TRAILING";
                    procwords[157] = "CURRENT_USER";
                    procwords[158] = "MAX";
                    procwords[159] = "TRANSACTION";
                    procwords[160] = "CURSOR";
                    procwords[161] = "MIN";
                    procwords[162] = "TRANSLATE";
                    procwords[163] = "DATE";
                    procwords[164] = "MINUTE";
                    procwords[165] = "TRANSLATION";
                    procwords[166] = "DAY";
                    procwords[167] = "MODULE";
                    procwords[168] = "TRIM";
                    procwords[169] = "DEALLOCATE";
                    procwords[170] = "MONTH";
                    procwords[171] = "TRUE";
                    procwords[172] = "DEC";
                    procwords[173] = "NAMES";
                    procwords[174] = "UNION";
                    procwords[175] = "DECIMAL";
                    procwords[176] = "NATIONAL";
                    procwords[177] = "UNIQUE";
                    procwords[178] = "DECLARE";
                    procwords[179] = "NATURAL";
                    procwords[180] = "UNKNOWN";
                    procwords[181] = "DEFAULT";
                    procwords[182] = "NCHAR";
                    procwords[183] = "UPDATE";
                    procwords[184] = "DEFERRABLE";
                    procwords[185] = "NEXT";
                    procwords[186] = "UPPER";
                    procwords[187] = "DEFERRED";
                    procwords[188] = "NO";
                    procwords[189] = "USAGE";
                    procwords[190] = "DELETE";
                    procwords[191] = "NONE";
                    procwords[192] = "USER";
                    procwords[193] = "DESC";
                    procwords[194] = "NOT";
                    procwords[195] = "USING";
                    procwords[196] = "DESCRIBE";
                    procwords[197] = "NULL";
                    procwords[198] = "VALUE";
                    procwords[199] = "DESCRIPTOR";
                    procwords[200] = "NULLIF";
                    procwords[201] = "VALUES";
                    procwords[202] = "DIAGNOSTICS";
                    procwords[203] = "NUMERIC";
                    procwords[204] = "VARCHAR";
                    procwords[205] = "DISCONNECT";
                    procwords[206] = "OCTET_LENGTH";
                    procwords[207] = "VARYING";
                    procwords[208] = "DISTINCT";
                    procwords[209] = "OF";
                    procwords[210] = "VIEW";
                    procwords[211] = "DOMAIN";
                    procwords[212] = "ON";
                    procwords[213] = "WHEN";
                    procwords[214] = "DOUBLE";
                    procwords[215] = "ONLY";
                    procwords[216] = "WHENEVER";
                    procwords[217] = "DROP";
                    procwords[218] = "OPEN";
                    procwords[219] = "WHERE";
                    procwords[220] = "ELSE";
                    procwords[221] = "OPTION";
                    procwords[222] = "WITH";
                    procwords[223] = "END";
                    procwords[224] = "OR";
                    procwords[225] = "WORK";
                    procwords[226] = "END-EXEC";
                    procwords[227] = "ORDER";
                    procwords[228] = "WRITE";
                    procwords[229] = "ESCAPE";
                    procwords[230] = "OUTER";
                    procwords[231] = "YEAR";
                    procwords[232] = "EXCEPT";
                    procwords[233] = "OUTPUT";
                    procwords[234] = "ZONE";
                    procwords[235] = "EXCEPTION";

                    //int startpos = richTextBox1.Text.LastIndexOf(" ")-1;
                    //int currentpos = richTextBox1.Text.Length;
                    caretposition = richTextBox1.SelectionStart;

                    int caretline = richTextBox1.GetFirstCharIndexOfCurrentLine();

                    if (caretposition == 0)
                    {
                        indexchar = "\n";
                    }

                    if (caretposition > 0)
                    {
                        indexchar = " ";
                    }

                    beforetext = richTextBox1.Text.Substring(caretline, caretposition - caretline);

                    //richTextBox1.Select(lastspacebeforetext = beforetext.LastIndexOf(' ') + 1, currentlen);

                    lastspacebeforetext = beforetext.LastIndexOf(indexchar);

                    //string rtbnl1 = richTextBox1.Text.Replace("\n", " ");
                    //int ls11 = rtbnl1.LastIndexOf(" ");
                    //int ls = richTextBox1.Text.LastIndexOf(" ");

                    int lineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                    string[] split = beforetext.Split(indexchar);

                    string[] splitrev = split.Reverse().ToArray();

                    holds = splitrev;

                    //currentword = splitrev[0];

                    string seclas = holds[0].Replace("\n", " ");

                    int seclascursor = holds[0].LastIndexOf(" ");

                    //if (ls != -1)
                    //{
                    //lastword = richTextBox1.Text.Substring(richTextBox1.Text.Substring(0, richTextBox1.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);   
                    //}

                    int lastwordlen = seclas.Length;
                    string lwup = seclas.ToUpper();

                    if ((seclas1.Contains("*")) == false)
                    {

                        if (procwords.Contains(lwup))
                        {
                            laswor = seclas;
                            dotextstuff(sender, e);

                        }

                        if ((procwords.Contains(lwup)) == false)
                        {
                            laswor = seclas;
                            dotextstuffblack(sender, e);

                        }
                    }
                }
            }
        }


        private void richTextBox1_KeyDowns(object sender, EventArgs e)
        {

            errortextbox.Visible = false;
            dataGridView4.Visible = true;

            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView3.ColumnHeadersVisible = false;
            this.dataGridView4.ColumnHeadersVisible = false;
            this.dataGridView5.ColumnHeadersVisible = false;
            this.dataGridView6.ColumnHeadersVisible = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            //label18.Visible = true;
            label19.Visible = false;
            //label12.Visible = false;
            //label14.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            this.label17.Location = new System.Drawing.Point(268, 112);
            this.label17.Text = "Not Connected";
            this.label17.TextAlign = ContentAlignment.TopRight;
            this.label17.ForeColor = System.Drawing.Color.Black;
            contextMenuStrip1.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            contextMenuStrip2.Enabled = false;
            toolStripMenuItem2.Enabled = false;
            sqlcomm = "";

            quer = richTextBox1.Text;




            if (backgroundWorker4.IsBusy != true)
            {
                try
                {
                    backgroundWorker4.RunWorkerAsync();
                    label23.Visible = true;
                    busy = true;
                }
                catch (Exception ex)
                {


                }
            }


        }


        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {




            BeginInvoke((MethodInvoker)delegate
            {
                dataGridView4.DataSource = null;
                groupBox8.Text = "Results";
                errortextbox.Visible = false;
            });

            {
                if (radioButton1.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", "; Trusted_Connection=True;");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.ins).ToString();
                }

                else if (radioButton2.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; User Id=", "; Password=", ";");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.u + textBox3.Text + connectionstring.p + textBox4.Text + connectionstring.ins).ToString();
                }

                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker != null)

                    try
                    {
                        using (SqlConnection cmd = new SqlConnection(connex))
                        {
                            try
                            {

                                {




                                    sqlcomm = sqlquery1 + " " + quer + " " + sqlquery2;

                                    SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd);
                                    cmd1.CommandTimeout = 0;
                                    SqlDataAdapter adapter = new SqlDataAdapter();

                                    static void OpenAndSetArithAbort(SqlConnection cmd)
                                    {

                                        using (SqlCommand cmd2 = cmd.CreateCommand())
                                        {
                                            cmd2.CommandType = CommandType.Text;
                                            cmd2.CommandText = "SET ARITHABORT ON";
                                            cmd.Open();
                                            cmd2.ExecuteNonQuery();
                                        }

                                        return;
                                    }


                                    OpenAndSetArithAbort(cmd);

                                    if (cmd1.Connection.State == ConnectionState.Open)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connected";
                                            this.label17.Location = new System.Drawing.Point(288, 112);
                                            this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                        }
                                     );
                                    }

                                    adapter.SelectCommand = cmd1;
                                    DataTable ds = new DataTable();
                                    adapter.Fill(ds);
                                    if (dta != null)
                                    {
                                        dta.Clear();
                                    }

                                    foreach (DataColumn dc in ds.Columns)
                                    {

                                        foreach (DataRow dr in ds.Rows)
                                        {

                                            {
                                                dta = dr.Table;
                                                dta.AcceptChanges();

                                                if (worker.CancellationPending == true)
                                                {

                                                    cmd.Close();
                                                    e.Result = null;
                                                    return;

                                                }

                                                if (worker.CancellationPending == false)

                                                {
                                                    e.Result = true;
                                                    return;

                                                }
                                            }
                                        }

                                    }

                                }
                            }

                            catch (Exception ex)

                            {
                                if (worker.CancellationPending == true)

                                    return;

                                if (ex.Message != null)
                                {
                                    string msg = ex.Message;


                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        //MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                        dataGridView4.Rows.Clear();
                                        errortextbox.Visible = true;
                                        errortextbox.Text = msg;
                                        groupBox8.Text = "Error";
                                        label23.Visible = false;

                                    });
                                }
                            }
                            finally
                            {
                                cmd.Close();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = "Please enter valid connection details.";
                        //MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);

                        BeginInvoke((MethodInvoker)delegate
                        {
                            dataGridView4.Rows.Clear();
                            errortextbox.Visible = true;
                            errortextbox.Text = msg;
                            groupBox8.Text = "Error";
                            label23.Visible = false;
                        });
                    }

            }
            return;
        }


        public void HideHeaders(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource is null)
            {
                dataGridView4.ColumnHeadersVisible = false;
                this.dataGridView5.ColumnHeadersVisible = false;
                this.dataGridView6.ColumnHeadersVisible = false;
                dataGridView4.ReadOnly = true;
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.ScrollBars = ScrollBars.None;
            }

        }

        async void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            {

                {
                    f5pressed = false;
                    ctp = "ctp4";
                    button3.Enabled = true;
                    button3.Text = "Results to Clipboard";
                    label23.Visible = false;
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    label23.Text = "Working...";
                    ctp = "ctp4";

                    //dataGridView4.Rows.Clear();

                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();
                    if (dta != null)
                    {
                        contextMenuStrip1.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        dta = dta.Copy();
                        dataGridView4.DataSource = null;
                        dataGridView4.Refresh();
                        dataGridView4.DataSource = dta;
                        dataGridView4.ScrollBars = ScrollBars.Both;


                        if (dta.Rows.Count < 1 || dta == null)
                        {
                            label22.Visible = true;
                            dataGridView4.ScrollBars = ScrollBars.None;
                            errortextbox.Visible = false;
                        }


                        if (dta.Rows.Count > 0)
                        {
                            label22.Visible = false;
                        }

                    }

                    if (dta is null)
                    {
                        label22.Visible = true;
                        this.dataGridView4.ColumnHeadersVisible = false;
                        this.dataGridView5.ColumnHeadersVisible = false;
                        this.dataGridView6.ColumnHeadersVisible = false;
                        button3.Enabled = false;
                    }

                    if (label22.Visible == true)
                    {
                        this.dataGridView4.ColumnHeadersVisible = false;
                        this.dataGridView5.ColumnHeadersVisible = false;
                        this.dataGridView6.ColumnHeadersVisible = false;
                        button3.Enabled = false;
                        contextMenuStrip1.Enabled = false;
                        toolStripMenuItem1.Enabled = false;
                        contextMenuStrip2.Enabled = false;
                        toolStripMenuItem2.Enabled = false;
                    }

                    busy = false;
                    richTextBox1.Enabled = true;
                }
            }
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }


        public void treeviewbuild()
        {



        }

        private void getdbdetails(object sender, EventArgs e)
        {

            lineIndex = richTextBox1.GetLineFromCharIndex(caretposition);

            int txtlen = richTextBox1.Text.Length;

            richTextBox1.SelectedText = "";

            caretposition = richTextBox1.SelectionStart;

            string tosplit = richTextBox1.Text.Replace("\n", " ");

            string[] rtbarray = tosplit.Split(" ");




            //{
            splits = 1;
            //}



            string beforetext = richTextBox1.Text.Substring(0, caretposition);

            string beforetextedited = beforetext.Replace("\n", " ");

            string aftertext = richTextBox1.Text.Substring(caretposition, (richTextBox1.Text.Length - caretposition));

            if (beforetextedited.LastIndexOf(" ") < 0)
            {
                lsp = 0;
            }

            else
            {
                lsp = beforetextedited.LastIndexOf(" ");
            }

            richTextBox1.Select(lsp, caretposition - lsp);

            string wrd = richTextBox1.SelectedText.ToString();


            if (beforetext.Contains("\n"))
            {
                containsreturn = true;
            }

            if (!beforetext.Contains("\n"))
            {
                containsreturn = false;
            }


            //lastspacebeforetext = beforetext.LastIndexOf(' ');

            //lineIndex = richTextBox1.GetLineFromCharIndex(caretposition);

            //splitint = beforetext.LastIndexOf(" ");

            //if (splitint > 0)
            //{

            //    string[] split = beforetext.Split(' ');

            //    int splitcount = split.Count();

            //    if (splitcount <= 2)
            //    {
            //        holds = split.ToArray();
            //    }

            //   if (splitcount > 2 && caretposition > lastspacebeforetext)
            //   {
            //        holds = split.Reverse().ToArray();
            //        splits = 0;

            //    }
            currentword = wrd.Replace('\n', ' ');

            if (lb.Visible == true)
            {
                currentlen = 0;
            }


            if (lb.Visible == false)
            {

                currentlen = currentword.Length;
            }

            currentcaretposition = richTextBox1.SelectionStart;

            richTextBox1.DeselectAll();



            //this.tablelist = new List<string>();
            //this.columnlist = new List<string>();


            //if (Keys.Control != 0 && e.KeyData == Keys.OemPeriod)

            //if (richTextBox1.SelectionStart >= 0 && richTextBox1.Text.LastIndexOf(' ') >= 0)
            //{

            //string lastWord = richTextBox1.Text.TrimEnd().Substring(richTextBox1.Text.TrimEnd().LastIndexOf(' ')).Trim();

            //TABLES

            Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", ";Trusted_Connection=True;");
            string cnxstr = (connectionstring.s + "DESKTOP-99C3KON" + connectionstring.d + "NORTHWIND" + connectionstring.ins).ToString();


            SqlConnection conn = new SqlConnection(cnxstr);


            string command = "select table_name FROM INFORMATION_SCHEMA.TABLES where table_name like '%" + currentword + "%'";
            SqlCommand cmd = new SqlCommand(command);
            cmd.Connection = conn;
            string result = command.ToString();
            conn.Open();

            //DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable ds = new DataTable();
            adapter.Fill(ds);


            //foreach (DataRow dr in ds.Rows)
            //{
            //    BeginInvoke((MethodInvoker)delegate
            //    {

            //        string l = dr[0].ToString();
            //        tablelist.Add(l);

            //    });

            //}
            //COLUMNS

            Form1 connectionstring2 = new Form1("Server=", "; Database=", "; username=", "; password=", ";Trusted_Connection=True;");
            string cnxstr2 = (connectionstring.s + "DESKTOP-99C3KON" + connectionstring2.d + "NORTHWIND" + connectionstring2.ins).ToString();


            SqlConnection conn2 = new SqlConnection(cnxstr2);


            string command2 = "select concat(table_name,'.',column_name) FROM INFORMATION_SCHEMA.COLUMNS where column_name like '%" + currentword.Replace(" ", "") + "%'";
            SqlCommand cmd2 = new SqlCommand(command2);
            cmd2.Connection = conn2;
            string result2 = command2.ToString();
            conn2.Open();

            //DataTable dt = new DataTable();

            SqlDataAdapter adapter2 = new SqlDataAdapter();
            adapter2.SelectCommand = cmd2;
            DataTable ds2 = new DataTable();
            adapter2.Fill(ds2);

            ListBox listBox = new ListBox();

            lb.Items.Clear();

            foreach (DataRow dr2 in ds2.Rows)
            {
                // BeginInvoke((MethodInvoker)delegate
                //{

                string l = dr2[0].ToString();
                //columnlist.Add(l);
                //contextMenuStrip4.Items.Add(l);
                lb.Items.Add(l);

                // });

            }


            lb.EndUpdate();
            lb.Refresh();


            if (lb.Items.Count == 0)
            {
                richTextBox1.SelectionStart = caretposition;
            }

            if (lb.Items.Count > 0)
            {
                autocompletebusy = true;

                richTextBox1.Select(lastspacebeforetext = beforetext.LastIndexOf(' ') + 1, currentlen + 1);

                string sl = richTextBox1.SelectedText;

                lb.Show();

                lb.Focus();

                //richTextBox1.Focus();

                int charpos = richTextBox1.SelectionStart;


                Point carpos = richTextBox1.GetPositionFromCharIndex(charpos);

                lb.Location = carpos;
                lb.Visible = true;
                lb.SetSelected(0, true);
            }


            autocomplete = false;
            autocompletebusy = false;





        }

        private void Lb_KeyDown(object sender, KeyEventArgs e)
        {


            if (containsreturn == true)
            {
                addchar = "\n";
            }

            if (containsreturn == false)
            {
                addchar = "";
            }



            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {

                if (e.KeyCode == Keys.Down)
                {
                    if (lb.SelectedIndex < (lb.Items.Count - 1))
                        lb.SelectedIndex++;
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (lb.SelectedIndex > 0)
                        lb.SelectedIndex--;
                    e.Handled = true;
                }

            }

            //if 
            //(
            //    e.KeyData != Keys.Enter || e.KeyCode != Keys.Tab || 
            //    e.KeyCode != Keys.Up || e.KeyCode != Keys.Down)
            //{

            //    if (lb.Visible == true)
            //    {
            //        lb.Visible = false;
            //    }
            //}


            if (e.KeyData == Keys.Enter)
            {

                richTextBox1.GetLineFromCharIndex(lineIndex);


                if (lb.SelectedIndex != -1)
                {
                    string beforetext = richTextBox1.Text.Substring(0, caretposition);

                    string beforetext2 = beforetext.Replace("\n", " ");

                    lastspacebeforetext = beforetext2.LastIndexOf(' ');



                    if (lb.Visible == true)
                    {



                        richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                        richTextBox1.SelectionColor = Color.Black;

                        richTextBox1.SelectedText = lb.SelectedItem.ToString() + " " + addchar;

                        autocomplete = false;

                        richTextBox1.Focus();



                    }

                    lb.Hide();

                    lb.Visible = false;

                    autocompletebusy = false;
                    autocomplete = false;

                    richTextBox1.DeselectAll();
                    richTextBox1.Refresh();
                }
            }


            if (e.KeyCode == Keys.Left && lb.SelectedItem is not null)
            {



                string beforetext = richTextBox1.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');



                //if (lb.Visible == true)
                //{



                //    richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                //    richTextBox1.SelectedText = lb.SelectedItem.ToString() + " ";

                //    autocomplete = false;

                //    richTextBox1.Focus();



                //}



                if (lb.Visible == true)
                {
                    //richTextBox1.Select(lastspace, currentlen + 2);

                    //richTextBox1.SelectedText = "";

                    //string appendageleft = lb.SelectedItem.ToString().Split('.')[0];

                    //richTextBox1.AppendText(" " + appendageleft);

                    //lb.Hide();

                    //int sellength = lb.SelectedItem.ToString().Length;

                    //autocomplete = false;

                    //richTextBox1.Focus();

                    //richTextBox1.SelectionStart = lastspace + sellength + 1;


                    richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox1.SelectionColor = Color.Black;

                    string appendageleft = lb.SelectedItem.ToString().Split('.')[0];

                    richTextBox1.SelectedText = appendageleft + " " + addchar;

                    autocomplete = false;

                    richTextBox1.Focus();

                    lb.Hide();
                    //richTextBox1.SelectionStart = caretposition;

                    richTextBox1.Focus();
                    richTextBox1.DeselectAll();
                    richTextBox1.Refresh();


                }
            }


            if (e.KeyCode == Keys.Right && lb.SelectedItem is not null)
            {

                string beforetext = richTextBox1.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');

                int lastcharacter = beforetext.Length - 1;

                if (beforetext.Substring(0, lastcharacter) == "\n")
                {
                    newlineonened = true;
                }


                if (beforetext.Substring(0, lastcharacter) != "\n")
                {
                    newlineonened = false;
                }


                //if (lb.Visible == true)
                //{



                //    richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                //    richTextBox1.SelectedText = lb.SelectedItem.ToString() + " ";

                //    autocomplete = false;

                //    richTextBox1.Focus();



                //}



                if (lb.Visible == true)
                {
                    //richTextBox1.Select(lastspace, currentlen + 2);

                    //richTextBox1.SelectedText = "";

                    //string appendageleft = lb.SelectedItem.ToString().Split('.')[0];

                    //richTextBox1.AppendText(" " + appendageleft);

                    //lb.Hide();

                    //int sellength = lb.SelectedItem.ToString().Length;

                    //autocomplete = false;

                    //richTextBox1.Focus();

                    //richTextBox1.SelectionStart = lastspace + sellength + 1;


                    richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);


                    richTextBox1.SelectionColor = Color.Black;


                    string appendageright = lb.SelectedItem.ToString().Split('.')[1];

                    richTextBox1.SelectedText = appendageright + " " + addchar;

                    //richTextBox1.SelectionStart = caretposition;

                    autocomplete = false;

                    richTextBox1.Focus();

                    lb.Hide();
                    //richTextBox1.SelectionStart = caretposition;

                    richTextBox1.Focus();
                    richTextBox1.DeselectAll();
                    richTextBox1.Refresh();




                }
            }


            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                lb.Hide();
                richTextBox1.SelectionStart = caretposition;
                richTextBox1.DeselectAll();
                richTextBox1.Focus();

                richTextBox1.Refresh();

            }


        }

        private void lbclick(object sender, EventArgs e)
        {

        }

        private void insertspace(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }



        private void dotextstuff2(object sender, EventArgs e)
        {
            //string lastword = richTextBox2.Text.Substring(richTextBox2.Text.Substring(0, richTextBox2.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);
            //int laswl = lastword.

            string findText = laswor;

            int index = 0;

            int len = laswor.Length;

            int positionOfcarett = caretposition;

            //do
            //{
            index = richTextBox2.Find(findText, index, RichTextBoxFinds.WholeWord);
            if (index > -1)
            {

                richTextBox2.Select(positionOfcarett, -findText.Length);
                richTextBox2.SelectionColor = Color.Blue;
                richTextBox2.DeselectAll();
                richTextBox2.SelectionLength = 0;
                richTextBox2.ForeColor = Color.Black;
                richTextBox2.SelectionStart = positionOfcarett;



                index++;
                //sqltextindex++;

            }




            //} while (index > -1);

            //richTextBox2.ForeColor = Color.Black;
        }



        private void dotextstuffblack2(object sender, EventArgs e)
        {
            //string lastword = richTextBox2.Text.Substring(richTextBox2.Text.Substring(0, richTextBox2.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);
            //int laswl = lastword.

            string findText = laswor;
            int index = 0;
            int len = laswor.Length;

            int lineIndex = richTextBox2.GetLineFromCharIndex(richTextBox2.SelectionStart);

            int positionOfcarett = caretposition;

            // do
            //{
            lineIndex = richTextBox2.GetFirstCharIndexOfCurrentLine();

            index = richTextBox2.Find(findText, index, RichTextBoxFinds.WholeWord);
            if (index > -1)
            {

                richTextBox2.Select(positionOfcarett, -findText.Length);
                richTextBox2.SelectionColor = Color.Black;
                richTextBox2.SelectionLength = 0;
                richTextBox2.ForeColor = Color.Black;
                richTextBox2.SelectionStart = richTextBox2.Text.Length;
                //richTextBox2.DeselectAll();
                richTextBox2.SelectionStart = positionOfcarett;


                index++;
                //sqltextindex++;

            }




            //} while (index > -1);

            //richTextBox2.ForeColor = Color.Black;
        }




        private void tabControl1_KeyPress2(object sender, KeyPressEventArgs e)
        {

        }



        private void richTextBox2_KeyDown2(object sender, KeyEventArgs e)
        {

            if (listBox1.Visible == true && e.KeyCode != Keys.Decimal || autocompletebusy == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Decimal)
            {
                if (autocomplete == false)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    getdbdetails2(sender, e);

                }
                else if (autocomplete == true)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    listBox1.Hide();
                    autocomplete = false;
                    //richTextBox2.DeselectAll();

                    if (listBox1.Items.Count > 0 && listBox1.Visible == false)
                    {
                        //richTextBox2.SelectedText = null;
                        richTextBox2.SelectionStart = currentcaretposition;

                    }
                }

            }


            if (e.KeyCode == Keys.F5 && busy == true)
            {
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F5 && busy == false)
            {
                //busy = true;
                dataGridView6.DataSource = null;
                dataGridView7.DataSource = null;
                //richTextBox2.Enabled = false;
                //richTextBox2_KeyDowns2(sender, e);
                //tabControl3.SelectedTab = tabPage9;


            }

            var prochar = new string[45];
            prochar[1] = ".";
            prochar[2] = "$";
            prochar[3] = "^";
            prochar[4] = "{";
            prochar[5] = "[";
            prochar[6] = "(";
            prochar[7] = "|";
            prochar[8] = ")";
            prochar[9] = "*";
            prochar[10] = "+";
            prochar[11] = "?";
            prochar[12] = "\\";
            prochar[13] = "]";
            prochar[14] = "]";
            prochar[15] = "{";
            prochar[16] = "}";
            prochar[17] = "-";
            prochar[18] = "=";
            prochar[19] = "_";
            prochar[20] = "+";
            prochar[21] = "!";
            prochar[22] = "&";
            prochar[23] = "£";
            prochar[24] = "$";
            prochar[25] = "%";
            prochar[26] = "^";
            prochar[27] = "&";
            prochar[28] = "(";
            prochar[29] = ")";
            prochar[30] = "//";
            prochar[31] = "*";
            prochar[32] = "-";
            prochar[33] = "+";
            prochar[34] = "@";
            prochar[35] = "~";
            prochar[36] = "'";
            prochar[37] = "#";
            prochar[38] = "?";
            prochar[39] = Environment.NewLine;
            prochar[40] = "<";
            prochar[41] = ">";




            if (caretposition == 0)
            {
                indexchar = "\n";
            }

            if (caretposition > 0)
            {
                indexchar = " ";
            }


            string rtbnl = richTextBox2.Text.Replace("\n", " ");
            //string rtbn2 = rtbnl.Replace('\\', ' ');
            int ls1 = rtbnl.LastIndexOf(indexchar);
            string[] split1 = rtbnl.Split(indexchar);
            string[] splitrev1 = split1.Reverse().ToArray();


            if (splitrev1.Length > 0)
            {

                holds = splitrev1.Skip(0).ToArray();
            }

            else
            {
                holds = splitrev1;
            }

            if (holds[0] == " ")
            {

            }

            string seclas1 = holds[0].Replace(Environment.NewLine, " ");

            if ((prochar.Contains(seclas1) == false))
            {

                if (e.KeyCode == Keys.Enter)
                {
                    richTextBox2.ScrollToCaret();
                }


                if ((

                   e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.F5) &&
                   richTextBox2.TextLength > 1 &&
                   f5pressed == false
                   )
                {

                    //InputSimulator ks = new InputSimulator();

                    //int len = richTextBox2.TextLength;

                    var procwords = new string[300];
                    procwords[1] = "ABSOLUTE";
                    procwords[2] = "EXEC";
                    procwords[3] = "OVERLAPS";
                    procwords[4] = "ACTION";
                    procwords[5] = "EXECUTE";
                    procwords[6] = "PAD";
                    procwords[7] = "ADA";
                    procwords[8] = "EXISTS";
                    procwords[9] = "PARTIAL";
                    procwords[10] = "ADD";
                    procwords[11] = "EXTERNAL";
                    procwords[12] = "PASCAL";
                    procwords[13] = "ALL";
                    procwords[14] = "EXTRACT";
                    procwords[15] = "POSITION";
                    procwords[16] = "ALLOCATE";
                    procwords[17] = "FALSE";
                    procwords[18] = "PRECISION";
                    procwords[19] = "ALTER";
                    procwords[20] = "FETCH";
                    procwords[21] = "PREPARE";
                    procwords[22] = "AND";
                    procwords[23] = "FIRST";
                    procwords[24] = "PRESERVE";
                    procwords[25] = "ANY";
                    procwords[26] = "FLOAT";
                    procwords[27] = "PRIMARY";
                    procwords[28] = "ARE";
                    procwords[29] = "FOR";
                    procwords[30] = "PRIOR";
                    procwords[31] = "AS";
                    procwords[32] = "FOREIGN";
                    procwords[33] = "PRIVILEGES";
                    procwords[34] = "ASC";
                    procwords[35] = "FORTRAN";
                    procwords[36] = "PROCEDURE";
                    procwords[37] = "ASSERTION";
                    procwords[38] = "FOUND";
                    procwords[39] = "PUBLIC";
                    procwords[40] = "AT";
                    procwords[41] = "FROM";
                    procwords[42] = "READ";
                    procwords[43] = "AUTHORIZATION";
                    procwords[44] = "FULL";
                    procwords[45] = "REAL";
                    procwords[46] = "AVG";
                    procwords[47] = "GET";
                    procwords[48] = "REFERENCES";
                    procwords[49] = "BEGIN";
                    procwords[50] = "GLOBAL";
                    procwords[51] = "RELATIVE";
                    procwords[52] = "BETWEEN";
                    procwords[53] = "GO";
                    procwords[54] = "RESTRICT";
                    procwords[55] = "BIT";
                    procwords[56] = "GOTO";
                    procwords[57] = "REVOKE";
                    procwords[58] = "BIT_LENGTH";
                    procwords[59] = "GRANT";
                    procwords[60] = "RIGHT";
                    procwords[61] = "BOTH";
                    procwords[62] = "GROUP";
                    procwords[63] = "ROLLBACK";
                    procwords[64] = "BY";
                    procwords[65] = "HAVING";
                    procwords[66] = "ROWS";
                    procwords[67] = "CASCADE";
                    procwords[68] = "HOUR";
                    procwords[69] = "SCHEMA";
                    procwords[70] = "CASCADED";
                    procwords[71] = "IDENTITY";
                    procwords[72] = "SCROLL";
                    procwords[73] = "CASE";
                    procwords[74] = "IMMEDIATE";
                    procwords[75] = "SECOND";
                    procwords[76] = "CAST";
                    procwords[77] = "IN";
                    procwords[78] = "SECTION";
                    procwords[79] = "CATALOG";
                    procwords[80] = "INCLUDE";
                    procwords[81] = "SELECT";
                    procwords[82] = "CHAR";
                    procwords[83] = "INDEX";
                    procwords[84] = "SESSION";
                    procwords[85] = "CHAR_LENGTH";
                    procwords[86] = "INDICATOR";
                    procwords[87] = "SESSION_USER";
                    procwords[88] = "CHARACTER";
                    procwords[89] = "INITIALLY";
                    procwords[90] = "SET";
                    procwords[91] = "CHARACTER_LENGTH";
                    procwords[92] = "INNER";
                    procwords[93] = "SIZE";
                    procwords[94] = "CHECK";
                    procwords[95] = "INPUT";
                    procwords[96] = "SMALLINT";
                    procwords[97] = "CLOSE";
                    procwords[98] = "INSENSITIVE";
                    procwords[99] = "SOME";
                    procwords[100] = "COALESCE";
                    procwords[101] = "INSERT";
                    procwords[102] = "SPACE";
                    procwords[103] = "COLLATE";
                    procwords[104] = "INT";
                    procwords[105] = "SQL";
                    procwords[106] = "COLLATION";
                    procwords[107] = "INTEGER";
                    procwords[108] = "SQLCA";
                    procwords[109] = "COLUMN";
                    procwords[110] = "INTERSECT";
                    procwords[111] = "SQLCODE";
                    procwords[112] = "COMMIT";
                    procwords[113] = "INTERVAL";
                    procwords[114] = "SQLERROR";
                    procwords[115] = "CONNECT";
                    procwords[116] = "INTO";
                    procwords[117] = "SQLSTATE";
                    procwords[118] = "CONNECTION";
                    procwords[119] = "IS";
                    procwords[120] = "SQLWARNING";
                    procwords[121] = "CONSTRAINT";
                    procwords[122] = "ISOLATION";
                    procwords[123] = "SUBSTRING";
                    procwords[124] = "CONSTRAINTS";
                    procwords[125] = "JOIN";
                    procwords[126] = "SUM";
                    procwords[127] = "CONTINUE";
                    procwords[128] = "KEY";
                    procwords[129] = "SYSTEM_USER";
                    procwords[130] = "CONVERT";
                    procwords[131] = "LANGUAGE";
                    procwords[132] = "TABLE";
                    procwords[133] = "CORRESPONDING";
                    procwords[134] = "LAST";
                    procwords[135] = "TEMPORARY";
                    procwords[136] = "COUNT";
                    procwords[137] = "LEADING";
                    procwords[138] = "THEN";
                    procwords[139] = "CREATE";
                    procwords[140] = "LEFT";
                    procwords[141] = "TIME";
                    procwords[142] = "CROSS";
                    procwords[143] = "LEVEL";
                    procwords[144] = "TIMESTAMP";
                    procwords[145] = "CURRENT";
                    procwords[146] = "LIKE";
                    procwords[147] = "TIMEZONE_HOUR";
                    procwords[148] = "CURRENT_DATE";
                    procwords[149] = "LOCAL";
                    procwords[150] = "TIMEZONE_MINUTE";
                    procwords[151] = "CURRENT_TIME";
                    procwords[152] = "LOWER";
                    procwords[153] = "TO";
                    procwords[154] = "CURRENT_TIMESTAMP";
                    procwords[155] = "MATCH";
                    procwords[156] = "TRAILING";
                    procwords[157] = "CURRENT_USER";
                    procwords[158] = "MAX";
                    procwords[159] = "TRANSACTION";
                    procwords[160] = "CURSOR";
                    procwords[161] = "MIN";
                    procwords[162] = "TRANSLATE";
                    procwords[163] = "DATE";
                    procwords[164] = "MINUTE";
                    procwords[165] = "TRANSLATION";
                    procwords[166] = "DAY";
                    procwords[167] = "MODULE";
                    procwords[168] = "TRIM";
                    procwords[169] = "DEALLOCATE";
                    procwords[170] = "MONTH";
                    procwords[171] = "TRUE";
                    procwords[172] = "DEC";
                    procwords[173] = "NAMES";
                    procwords[174] = "UNION";
                    procwords[175] = "DECIMAL";
                    procwords[176] = "NATIONAL";
                    procwords[177] = "UNIQUE";
                    procwords[178] = "DECLARE";
                    procwords[179] = "NATURAL";
                    procwords[180] = "UNKNOWN";
                    procwords[181] = "DEFAULT";
                    procwords[182] = "NCHAR";
                    procwords[183] = "UPDATE";
                    procwords[184] = "DEFERRABLE";
                    procwords[185] = "NEXT";
                    procwords[186] = "UPPER";
                    procwords[187] = "DEFERRED";
                    procwords[188] = "NO";
                    procwords[189] = "USAGE";
                    procwords[190] = "DELETE";
                    procwords[191] = "NONE";
                    procwords[192] = "USER";
                    procwords[193] = "DESC";
                    procwords[194] = "NOT";
                    procwords[195] = "USING";
                    procwords[196] = "DESCRIBE";
                    procwords[197] = "NULL";
                    procwords[198] = "VALUE";
                    procwords[199] = "DESCRIPTOR";
                    procwords[200] = "NULLIF";
                    procwords[201] = "VALUES";
                    procwords[202] = "DIAGNOSTICS";
                    procwords[203] = "NUMERIC";
                    procwords[204] = "VARCHAR";
                    procwords[205] = "DISCONNECT";
                    procwords[206] = "OCTET_LENGTH";
                    procwords[207] = "VARYING";
                    procwords[208] = "DISTINCT";
                    procwords[209] = "OF";
                    procwords[210] = "VIEW";
                    procwords[211] = "DOMAIN";
                    procwords[212] = "ON";
                    procwords[213] = "WHEN";
                    procwords[214] = "DOUBLE";
                    procwords[215] = "ONLY";
                    procwords[216] = "WHENEVER";
                    procwords[217] = "DROP";
                    procwords[218] = "OPEN";
                    procwords[219] = "WHERE";
                    procwords[220] = "ELSE";
                    procwords[221] = "OPTION";
                    procwords[222] = "WITH";
                    procwords[223] = "END";
                    procwords[224] = "OR";
                    procwords[225] = "WORK";
                    procwords[226] = "END-EXEC";
                    procwords[227] = "ORDER";
                    procwords[228] = "WRITE";
                    procwords[229] = "ESCAPE";
                    procwords[230] = "OUTER";
                    procwords[231] = "YEAR";
                    procwords[232] = "EXCEPT";
                    procwords[233] = "OUTPUT";
                    procwords[234] = "ZONE";
                    procwords[235] = "EXCEPTION";

                    //int startpos = richTextBox2.Text.LastIndexOf(" ")-1;
                    //int currentpos = richTextBox2.Text.Length;
                    caretposition = richTextBox2.SelectionStart;

                    int caretline = richTextBox2.GetFirstCharIndexOfCurrentLine();

                    if (caretposition == 0)
                    {
                        indexchar = "\n";
                    }

                    if (caretposition > 0)
                    {
                        indexchar = " ";
                    }

                    beforetext = richTextBox2.Text.Substring(caretline, caretposition - caretline);

                    //richTextBox2.Select(lastspacebeforetext = beforetext.LastIndexOf(' ') + 1, currentlen);

                    lastspacebeforetext = beforetext.LastIndexOf(indexchar);

                    //string rtbnl1 = richTextBox2.Text.Replace("\n", " ");
                    //int ls11 = rtbnl1.LastIndexOf(" ");
                    //int ls = richTextBox2.Text.LastIndexOf(" ");

                    int lineIndex = richTextBox2.GetLineFromCharIndex(richTextBox2.SelectionStart);
                    string[] split = beforetext.Split(indexchar);

                    string[] splitrev = split.Reverse().ToArray();

                    holds = splitrev;

                    //currentword = splitrev[0];

                    string seclas = holds[0].Replace("\n", " ");

                    int seclascursor = holds[0].LastIndexOf(" ");

                    //if (ls != -1)
                    //{
                    //lastword = richTextBox2.Text.Substring(richTextBox2.Text.Substring(0, richTextBox2.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);   
                    //}

                    int lastwordlen = seclas.Length;
                    string lwup = seclas.ToUpper();

                    if ((seclas1.Contains("*")) == false)
                    {

                        if (procwords.Contains(lwup))
                        {
                            laswor = seclas;
                            dotextstuff2(sender, e);

                        }

                        if ((procwords.Contains(lwup)) == false)
                        {
                            laswor = seclas;
                            dotextstuffblack2(sender, e);

                        }
                    }
                }
            }
        }


        private void richTextBox2_KeyDowns2

           (object sender, EventArgs e)
        {

            textBox9.Visible = false;
            textBox10.Visible = false;
            dataGridView5.Visible = true;

            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView3.ColumnHeadersVisible = false;
            this.dataGridView4.ColumnHeadersVisible = false;
            this.dataGridView5.ColumnHeadersVisible = false;
            this.dataGridView6.ColumnHeadersVisible = false;
            this.dataGridView7.ColumnHeadersVisible = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            //label18.Visible = true;
            label19.Visible = false;
            //label12.Visible = false;
            //label14.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            this.label17.Location = new System.Drawing.Point(268, 110);
            this.label17.Text = "Not Connected";
            this.label17.TextAlign = ContentAlignment.TopRight;
            this.label17.ForeColor = System.Drawing.Color.Black;
            contextMenuStrip1.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            contextMenuStrip2.Enabled = false;
            toolStripMenuItem2.Enabled = false;
            sqlcomm = "";

            quer = richTextBox2.Text;




            if (backgroundWorker5.IsBusy != true)
            {
                try
                {
                    backgroundWorker5.RunWorkerAsync();
                    label24.Visible = true;
                    busy = true;
                }
                catch (Exception ex)
                {


                }
            }


        }


        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {




            BeginInvoke((MethodInvoker)delegate
            {
                dataGridView5.DataSource = null;
                dataGridView6.DataSource = null;
                groupBox8.Text = "Results";
                textBox9.Visible = false;
            });

            {
                if (radioButton1.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", "; Trusted_Connection=True;");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.ins).ToString();
                }

                else if (radioButton2.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; User Id=", "; Password=", ";");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.u + textBox3.Text + connectionstring.p + textBox4.Text + connectionstring.ins).ToString();
                }

                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker != null)

                    try
                    {
                        using (SqlConnection cmd = new SqlConnection(connex))
                        {
                            try
                            {

                                {

                                    sqlcomm = sqlquery1 + " " + quer + " " + sqlquery2;


                                    SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd);
                                    cmd1.CommandTimeout = 0;
                                    SqlDataAdapter adapter = new SqlDataAdapter();

                                    static void OpenAndSetArithAbort(SqlConnection cmd)
                                    {

                                        using (SqlCommand cmd2 = cmd.CreateCommand())
                                        {
                                            cmd2.CommandType = CommandType.Text;
                                            cmd2.CommandText = "SET ARITHABORT ON";
                                            cmd.Open();
                                            cmd2.ExecuteNonQuery();
                                        }

                                        return;
                                    }


                                    OpenAndSetArithAbort(cmd);

                                    if (cmd1.Connection.State == ConnectionState.Open)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connected";
                                            this.label17.Location = new System.Drawing.Point(288, 112);
                                            this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                        }
                                     );
                                    }

                                    adapter.SelectCommand = cmd1;
                                    DataTable ds = new DataTable();
                                    adapter.Fill(ds);
                                    if (dta != null)
                                    {
                                        dta.Clear();
                                    }

                                    foreach (DataColumn dc in ds.Columns)
                                    {

                                        foreach (DataRow dr in ds.Rows)
                                        {

                                            {
                                                dta = dr.Table;
                                                dta.AcceptChanges();

                                                if (worker.CancellationPending == true)
                                                {

                                                    cmd.Close();
                                                    e.Result = null;
                                                    return;

                                                }

                                                if (worker.CancellationPending == false)

                                                {
                                                    e.Result = true;
                                                    return;

                                                }
                                            }
                                        }

                                    }

                                }


                                {

                                    sqlcomm = sqlquery1 + " " + quer + " " + sqlquery2;


                                    SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd);
                                    cmd1.CommandTimeout = 0;
                                    SqlDataAdapter adapter = new SqlDataAdapter();

                                    static void OpenAndSetArithAbort(SqlConnection cmd)
                                    {

                                        using (SqlCommand cmd2 = cmd.CreateCommand())
                                        {
                                            cmd2.CommandType = CommandType.Text;
                                            cmd2.CommandText = "SET ARITHABORT ON";
                                            cmd.Open();
                                            cmd2.ExecuteNonQuery();
                                        }

                                        return;
                                    }


                                    OpenAndSetArithAbort(cmd);

                                    if (cmd1.Connection.State == ConnectionState.Open)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connected";
                                            this.label17.Location = new System.Drawing.Point(288, 112);
                                            this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                        }
                                     );
                                    }

                                    adapter.SelectCommand = cmd1;
                                    DataTable ds = new DataTable();
                                    adapter.Fill(ds);
                                    if (dta != null)
                                    {
                                        dta.Clear();
                                    }

                                    foreach (DataColumn dc in ds.Columns)
                                    {

                                        foreach (DataRow dr in ds.Rows)
                                        {

                                            {
                                                dta = dr.Table;
                                                dta.AcceptChanges();

                                                if (worker.CancellationPending == true)
                                                {

                                                    cmd.Close();
                                                    e.Result = null;
                                                    return;

                                                }

                                                if (worker.CancellationPending == false)

                                                {
                                                    e.Result = true;
                                                    return;

                                                }
                                            }
                                        }

                                    }

                                }


                            }

                            catch (Exception ex)

                            {
                                if (worker.CancellationPending == true)

                                    return;

                                if (ex.Message != null)
                                {
                                    string msg = ex.Message;


                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        //MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                        dataGridView5.Rows.Clear();
                                        dataGridView6.Rows.Clear();
                                        dataGridView7.Rows.Clear();
                                        textBox9.Visible = true;
                                        textBox9.Text = msg;
                                        groupBox8.Text = "Error";
                                        label23.Visible = false;

                                    });
                                }
                            }
                            finally
                            {
                                cmd.Close();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = "Please enter valid connection details.";
                        //MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);

                        BeginInvoke((MethodInvoker)delegate
                        {
                            dataGridView5.Rows.Clear();
                            dataGridView6.Rows.Clear();
                            dataGridView7.Rows.Clear();
                            //textBox9.Visible = true;
                            //textBox9.Text = msg;
                            groupBox8.Text = "Error";
                            label23.Visible = false;
                        });
                    }

            }
            return;
        }


        public void HideHeaders2(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource is null)
            {
                dataGridView4.ColumnHeadersVisible = false;
                this.dataGridView5.ColumnHeadersVisible = false;
                this.dataGridView6.ColumnHeadersVisible = false;
                dataGridView4.ReadOnly = true;
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.ScrollBars = ScrollBars.None;
            }

        }

        async void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            {

                {
                    f5pressed = false;
                    ctp = "ctp4";
                    button3.Enabled = true;
                    button3.Text = "Results to Clipboard";
                    label23.Visible = false;
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    label23.Text = "Working...";
                    ctp = "ctp4";

                    //dataGridView4.Rows.Clear();

                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();
                    if (dta != null)
                    {
                        contextMenuStrip1.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        dta = dta.Copy();
                        dataGridView5.DataSource = null;
                        dataGridView5.Refresh();
                        dataGridView5.DataSource = dta;
                        dataGridView5.ScrollBars = ScrollBars.Both;
                        groupBox11.Text = "Results";
                        groupBox12.Text = "Results";


                        if (dta.Rows.Count < 1 || dta == null)
                        {
                            label24.Visible = true;
                            dataGridView5.ScrollBars = ScrollBars.None;
                            //textBox9.Visible = false;
                        }


                        if (dta.Rows.Count > 0)
                        {
                            label24.Visible = false;
                        }

                    }

                    if (dta is null)
                    {
                        label24.Visible = true;
                        this.dataGridView5.ColumnHeadersVisible = false;
                        this.dataGridView6.ColumnHeadersVisible = false;
                        button3.Enabled = false;
                    }

                    if (label24.Visible == true)
                    {
                        this.dataGridView5.ColumnHeadersVisible = false;
                        this.dataGridView6.ColumnHeadersVisible = false;
                        button3.Enabled = false;
                        contextMenuStrip1.Enabled = false;
                        toolStripMenuItem1.Enabled = false;
                        contextMenuStrip2.Enabled = false;
                        toolStripMenuItem2.Enabled = false;
                    }

                    busy = false;
                    richTextBox2.Enabled = true;
                }
            }
        }

        private void groupBox8_Enter2(object sender, EventArgs e)
        {

        }


        public void treeviewbuild2()
        {



        }

        private void getdbdetails2(object sender, EventArgs e)
        {

            lineIndex = richTextBox2.GetLineFromCharIndex(caretposition);

            int txtlen = richTextBox2.Text.Length;

            richTextBox2.SelectedText = "";

            caretposition = richTextBox2.SelectionStart;

            string tosplit = richTextBox2.Text.Replace("\n", " ");

            string[] rtbarray = tosplit.Split(" ");




            //{
            splits = 1;
            //}



            string beforetext = richTextBox2.Text.Substring(0, caretposition);

            string beforetextedited = beforetext.Replace("\n", " ");

            string aftertext = richTextBox2.Text.Substring(caretposition, (richTextBox2.Text.Length - caretposition));

            if (beforetextedited.LastIndexOf(" ") < 0)
            {
                lsp = 0;
            }

            else
            {
                lsp = beforetextedited.LastIndexOf(" ");
            }

            richTextBox2.Select(lsp, caretposition - lsp);

            string wrd = richTextBox2.SelectedText.ToString();


            if (beforetext.Contains("\n"))
            {
                containsreturn = true;
            }

            if (!beforetext.Contains("\n"))
            {
                containsreturn = false;
            }


            //lastspacebeforetext = beforetext.LastIndexOf(' ');

            //lineIndex = richTextBox2.GetLineFromCharIndex(caretposition);

            //splitint = beforetext.LastIndexOf(" ");

            //if (splitint > 0)
            //{

            //    string[] split = beforetext.Split(' ');

            //    int splitcount = split.Count();

            //    if (splitcount <= 2)
            //    {
            //        holds = split.ToArray();
            //    }

            //   if (splitcount > 2 && caretposition > lastspacebeforetext)
            //   {
            //        holds = split.Reverse().ToArray();
            //        splits = 0;

            //    }
            currentword = wrd.Replace('\n', ' ');

            if (listBox1.Visible == true)
            {
                currentlen = 0;
            }


            if (listBox1.Visible == false)
            {

                currentlen = currentword.Length;
            }

            currentcaretposition = richTextBox2.SelectionStart;

            richTextBox2.DeselectAll();



            //this.tablelist = new List<string>();
            //this.columnlist = new List<string>();


            //if (Keys.Control != 0 && e.KeyData == Keys.OemPeriod)

            //if (richTextBox2.SelectionStart >= 0 && richTextBox2.Text.LastIndexOf(' ') >= 0)
            //{

            //string lastWord = richTextBox2.Text.TrimEnd().Substring(richTextBox2.Text.TrimEnd().LastIndexOf(' ')).Trim();

            //TABLES

            Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", ";Trusted_Connection=True;");
            string cnxstr = (connectionstring.s + "DESKTOP-99C3KON" + connectionstring.d + "NORTHWIND" + connectionstring.ins).ToString();


            SqlConnection conn = new SqlConnection(cnxstr);


            string command = "select table_name FROM INFORMATION_SCHEMA.TABLES where table_name like '%" + currentword + "%'";
            SqlCommand cmd = new SqlCommand(command);
            cmd.Connection = conn;
            string result = command.ToString();
            conn.Open();

            //DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable ds = new DataTable();
            adapter.Fill(ds);


            //foreach (DataRow dr in ds.Rows)
            //{
            //    BeginInvoke((MethodInvoker)delegate
            //    {

            //        string l = dr[0].ToString();
            //        tablelist.Add(l);

            //    });

            //}
            //COLUMNS

            Form1 connectionstring2 = new Form1("Server=", "; Database=", "; username=", "; password=", ";Trusted_Connection=True;");
            string cnxstr2 = (connectionstring.s + "DESKTOP-99C3KON" + connectionstring2.d + "NORTHWIND" + connectionstring2.ins).ToString();


            SqlConnection conn2 = new SqlConnection(cnxstr2);


            string command2 = "select concat(table_name,'.',column_name) FROM INFORMATION_SCHEMA.COLUMNS where column_name like '%" + currentword.Replace(" ", "") + "%'";
            SqlCommand cmd2 = new SqlCommand(command2);
            cmd2.Connection = conn2;
            string result2 = command2.ToString();
            conn2.Open();

            //DataTable dt = new DataTable();

            SqlDataAdapter adapter2 = new SqlDataAdapter();
            adapter2.SelectCommand = cmd2;
            DataTable ds2 = new DataTable();
            adapter2.Fill(ds2);

            ListBox listBox = new ListBox();

            listBox1.Items.Clear();

            foreach (DataRow dr2 in ds2.Rows)
            {
                // BeginInvoke((MethodInvoker)delegate
                //{

                string l = dr2[0].ToString();
                //columnlist.Add(l);
                //contextMenuStrip4.Items.Add(l);
                listBox1.Items.Add(l);

                // });

            }


            listBox1.EndUpdate();
            listBox1.Refresh();


            if (listBox1.Items.Count == 0)
            {
                richTextBox2.SelectionStart = caretposition;
            }

            if (listBox1.Items.Count > 0)
            {
                autocompletebusy = true;

                richTextBox2.Select(lastspacebeforetext = beforetext.LastIndexOf(' ') + 1, currentlen + 1);

                string sl = richTextBox2.SelectedText;

                listBox1.Show();

                listBox1.Focus();

                //richTextBox2.Focus();

                int charpos = richTextBox2.SelectionStart;

                Point carpos = richTextBox2.GetPositionFromCharIndex(charpos);

                listBox1.Location = carpos;
                listBox1.Visible = true;
                listBox1.SetSelected(0, true);
            }


            autocomplete = false;
            autocompletebusy = false;





        }

        private void Lb_KeyDown2(object sender, KeyEventArgs e)
        {


            if (containsreturn == true)
            {
                addchar = "\n";
            }

            if (containsreturn == false)
            {
                addchar = "";
            }



            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {

                if (e.KeyCode == Keys.Down)
                {
                    if (listBox1.SelectedIndex < (listBox1.Items.Count - 1))
                        listBox1.SelectedIndex++;
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (listBox1.SelectedIndex > 0)
                        listBox1.SelectedIndex--;
                    e.Handled = true;
                }

            }

            //if 
            //(
            //    e.KeyData != Keys.Enter || e.KeyCode != Keys.Tab || 
            //    e.KeyCode != Keys.Up || e.KeyCode != Keys.Down)
            //{

            //    if (listBox1.Visible == true)
            //    {
            //        listBox1.Visible = false;
            //    }
            //}


            if (e.KeyData == Keys.Enter)
            {

                richTextBox2.GetLineFromCharIndex(lineIndex);


                if (listBox1.SelectedIndex != -1)
                {
                    string beforetext = richTextBox2.Text.Substring(0, caretposition);

                    string beforetext2 = beforetext.Replace("\n", " ");

                    lastspacebeforetext = beforetext2.LastIndexOf(' ');



                    if (listBox1.Visible == true)
                    {



                        richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                        richTextBox2.SelectionColor = Color.Black;

                        richTextBox2.SelectedText = listBox1.SelectedItem.ToString() + " " + addchar;

                        autocomplete = false;

                        richTextBox2.Focus();



                    }

                    listBox1.Hide();

                    listBox1.Visible = false;

                    autocompletebusy = false;
                    autocomplete = false;

                    richTextBox2.DeselectAll();
                    richTextBox2.Refresh();
                }
            }


            if (e.KeyCode == Keys.Left && listBox1.SelectedItem is not null)
            {



                string beforetext = richTextBox2.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');



                //if (listBox1.Visible == true)
                //{



                //    richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                //    richTextBox2.SelectedText = listBox1.SelectedItem.ToString() + " ";

                //    autocomplete = false;

                //    richTextBox2.Focus();



                //}



                if (listBox1.Visible == true)
                {
                    //richTextBox2.Select(lastspace, currentlen + 2);

                    //richTextBox2.SelectedText = "";

                    //string appendageleft = listBox1.SelectedItem.ToString().Split('.')[0];

                    //richTextBox2.AppendText(" " + appendageleft);

                    //listBox1.Hide();

                    //int sellength = listBox1.SelectedItem.ToString().Length;

                    //autocomplete = false;

                    //richTextBox2.Focus();

                    //richTextBox2.SelectionStart = lastspace + sellength + 1;


                    richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox2.SelectionColor = Color.Black;

                    string appendageleft = listBox1.SelectedItem.ToString().Split('.')[0];

                    richTextBox2.SelectedText = appendageleft + " " + addchar;

                    autocomplete = false;

                    richTextBox2.Focus();

                    listBox1.Hide();
                    //richTextBox2.SelectionStart = caretposition;

                    richTextBox2.Focus();
                    richTextBox2.DeselectAll();
                    richTextBox2.Refresh();


                }
            }


            if (e.KeyCode == Keys.Right && listBox1.SelectedItem is not null)
            {

                string beforetext = richTextBox2.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');

                int lastcharacter = beforetext.Length - 1;

                if (beforetext.Substring(0, lastcharacter) == "\n")
                {
                    newlineonened = true;
                }


                if (beforetext.Substring(0, lastcharacter) != "\n")
                {
                    newlineonened = false;
                }


                //if (listBox1.Visible == true)
                //{



                //    richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                //    richTextBox2.SelectedText = listBox1.SelectedItem.ToString() + " ";

                //    autocomplete = false;

                //    richTextBox2.Focus();



                //}



                if (listBox1.Visible == true)
                {
                    //richTextBox2.Select(lastspace, currentlen + 2);

                    //richTextBox2.SelectedText = "";

                    //string appendageleft = listBox1.SelectedItem.ToString().Split('.')[0];

                    //richTextBox2.AppendText(" " + appendageleft);

                    //listBox1.Hide();

                    //int sellength = listBox1.SelectedItem.ToString().Length;

                    //autocomplete = false;

                    //richTextBox2.Focus();

                    //richTextBox2.SelectionStart = lastspace + sellength + 1;


                    richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);


                    richTextBox2.SelectionColor = Color.Black;


                    string appendageright = listBox1.SelectedItem.ToString().Split('.')[1];

                    richTextBox2.SelectedText = appendageright + " " + addchar;

                    //richTextBox2.SelectionStart = caretposition;

                    autocomplete = false;

                    richTextBox2.Focus();

                    listBox1.Hide();
                    //richTextBox2.SelectionStart = caretposition;

                    richTextBox2.Focus();
                    richTextBox2.DeselectAll();
                    richTextBox2.Refresh();




                }
            }


            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                listBox1.Hide();
                richTextBox2.SelectionStart = caretposition;
                richTextBox2.DeselectAll();
                richTextBox2.Focus();
                richTextBox2.Refresh();

            }


        }



        private void dotextstuff3(object sender, EventArgs e)
        {
            //string lastword = richTextBox4.Text.Substring(richTextBox4.Text.Substring(0, richTextBox4.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);
            //int laswl = lastword.

            string findText = laswor;

            int index = 0;

            int len = laswor.Length;

            int positionOfcarett = caretposition;

            //do
            //{
            index = richTextBox4.Find(findText, index, RichTextBoxFinds.WholeWord);
            if (index > -1)
            {

                richTextBox4.Select(positionOfcarett, -findText.Length);
                richTextBox4.SelectionColor = Color.Blue;
                richTextBox4.DeselectAll();
                richTextBox4.SelectionLength = 0;
                richTextBox4.ForeColor = Color.Black;
                richTextBox4.SelectionStart = positionOfcarett;



                index++;
                //sqltextindex++;

            }




            //} while (index > -1);

            //richTextBox4.ForeColor = Color.Black;
        }



        private void dotextstuffblack3(object sender, EventArgs e)
        {
            //string lastword = richTextBox4.Text.Substring(richTextBox4.Text.Substring(0, richTextBox4.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);
            //int laswl = lastword.

            string findText = laswor;
            int index = 0;
            int len = laswor.Length;

            int lineIndex = richTextBox4.GetLineFromCharIndex(richTextBox4.SelectionStart);

            int positionOfcarett = caretposition;

            // do
            //{
            lineIndex = richTextBox4.GetFirstCharIndexOfCurrentLine();

            index = richTextBox4.Find(findText, index, RichTextBoxFinds.WholeWord);
            if (index > -1)
            {

                richTextBox4.Select(positionOfcarett, -findText.Length);
                richTextBox4.SelectionColor = Color.Black;
                richTextBox4.SelectionLength = 0;
                richTextBox4.ForeColor = Color.Black;
                richTextBox4.SelectionStart = richTextBox4.Text.Length;
                //richTextBox4.DeselectAll();
                richTextBox4.SelectionStart = positionOfcarett;


                index++;
                //sqltextindex++;

            }




            //} while (index > -1);

            //richTextBox4.ForeColor = Color.Black;
        }




        private void tabControl1_KeyPress3(object sender, KeyPressEventArgs e)
        {

        }



        private void richTextBox4_KeyDown3(object sender, KeyEventArgs e)
        {

            if (listBox2.Visible == true && e.KeyCode != Keys.Decimal || autocompletebusy == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Decimal)
            {
                if (autocomplete == false)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    getdbdetails3(sender, e);

                }
                else if (autocomplete == true)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    listBox2.Hide();
                    autocomplete = false;
                    //richTextBox4.DeselectAll();

                    if (listBox2.Items.Count > 0 && listBox2.Visible == false)
                    {
                        //richTextBox4.SelectedText = null;
                        richTextBox4.SelectionStart = currentcaretposition;

                    }
                }

            }


            if (e.KeyCode == Keys.F5 && busy == true)
            {
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F5 && busy == false)
            {
                busy = true;
                dataGridView6.DataSource = null;
                dataGridView7.DataSource = null;
                richTextBox2.Enabled = false;
                richTextBox4.Enabled = false;
                richTextBox5_KeyDowns2(sender, e);
                tabControl3.SelectedTab = tabPage9;


            }

            var prochar = new string[45];
            prochar[1] = ".";
            prochar[2] = "$";
            prochar[3] = "^";
            prochar[4] = "{";
            prochar[5] = "[";
            prochar[6] = "(";
            prochar[7] = "|";
            prochar[8] = ")";
            prochar[9] = "*";
            prochar[10] = "+";
            prochar[11] = "?";
            prochar[12] = "\\";
            prochar[13] = "]";
            prochar[14] = "]";
            prochar[15] = "{";
            prochar[16] = "}";
            prochar[17] = "-";
            prochar[18] = "=";
            prochar[19] = "_";
            prochar[20] = "+";
            prochar[21] = "!";
            prochar[22] = "&";
            prochar[23] = "£";
            prochar[24] = "$";
            prochar[25] = "%";
            prochar[26] = "^";
            prochar[27] = "&";
            prochar[28] = "(";
            prochar[29] = ")";
            prochar[30] = "//";
            prochar[31] = "*";
            prochar[32] = "-";
            prochar[33] = "+";
            prochar[34] = "@";
            prochar[35] = "~";
            prochar[36] = "'";
            prochar[37] = "#";
            prochar[38] = "?";
            prochar[39] = Environment.NewLine;
            prochar[40] = "<";
            prochar[41] = ">";




            if (caretposition == 0)
            {
                indexchar = "\n";
            }

            if (caretposition > 0)
            {
                indexchar = " ";
            }


            string rtbnl = richTextBox4.Text.Replace("\n", " ");
            //string rtbn2 = rtbnl.Replace('\\', ' ');
            int ls1 = rtbnl.LastIndexOf(indexchar);
            string[] split1 = rtbnl.Split(indexchar);
            string[] splitrev1 = split1.Reverse().ToArray();


            if (splitrev1.Length > 0)
            {

                holds = splitrev1.Skip(0).ToArray();
            }

            else
            {
                holds = splitrev1;
            }

            if (holds[0] == " ")
            {

            }

            string seclas1 = holds[0].Replace(Environment.NewLine, " ");

            if ((prochar.Contains(seclas1) == false))
            {

                if (e.KeyCode == Keys.Enter)
                {
                    richTextBox4.ScrollToCaret();
                }


                if ((

                   e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.F5) &&
                   richTextBox4.TextLength > 1 &&
                   f5pressed == false
                   )
                {

                    //InputSimulator ks = new InputSimulator();

                    //int len = richTextBox4.TextLength;

                    var procwords = new string[300];
                    procwords[1] = "ABSOLUTE";
                    procwords[2] = "EXEC";
                    procwords[3] = "OVERLAPS";
                    procwords[4] = "ACTION";
                    procwords[5] = "EXECUTE";
                    procwords[6] = "PAD";
                    procwords[7] = "ADA";
                    procwords[8] = "EXISTS";
                    procwords[9] = "PARTIAL";
                    procwords[10] = "ADD";
                    procwords[11] = "EXTERNAL";
                    procwords[12] = "PASCAL";
                    procwords[13] = "ALL";
                    procwords[14] = "EXTRACT";
                    procwords[15] = "POSITION";
                    procwords[16] = "ALLOCATE";
                    procwords[17] = "FALSE";
                    procwords[18] = "PRECISION";
                    procwords[19] = "ALTER";
                    procwords[20] = "FETCH";
                    procwords[21] = "PREPARE";
                    procwords[22] = "AND";
                    procwords[23] = "FIRST";
                    procwords[24] = "PRESERVE";
                    procwords[25] = "ANY";
                    procwords[26] = "FLOAT";
                    procwords[27] = "PRIMARY";
                    procwords[28] = "ARE";
                    procwords[29] = "FOR";
                    procwords[30] = "PRIOR";
                    procwords[31] = "AS";
                    procwords[32] = "FOREIGN";
                    procwords[33] = "PRIVILEGES";
                    procwords[34] = "ASC";
                    procwords[35] = "FORTRAN";
                    procwords[36] = "PROCEDURE";
                    procwords[37] = "ASSERTION";
                    procwords[38] = "FOUND";
                    procwords[39] = "PUBLIC";
                    procwords[40] = "AT";
                    procwords[41] = "FROM";
                    procwords[42] = "READ";
                    procwords[43] = "AUTHORIZATION";
                    procwords[44] = "FULL";
                    procwords[45] = "REAL";
                    procwords[46] = "AVG";
                    procwords[47] = "GET";
                    procwords[48] = "REFERENCES";
                    procwords[49] = "BEGIN";
                    procwords[50] = "GLOBAL";
                    procwords[51] = "RELATIVE";
                    procwords[52] = "BETWEEN";
                    procwords[53] = "GO";
                    procwords[54] = "RESTRICT";
                    procwords[55] = "BIT";
                    procwords[56] = "GOTO";
                    procwords[57] = "REVOKE";
                    procwords[58] = "BIT_LENGTH";
                    procwords[59] = "GRANT";
                    procwords[60] = "RIGHT";
                    procwords[61] = "BOTH";
                    procwords[62] = "GROUP";
                    procwords[63] = "ROLLBACK";
                    procwords[64] = "BY";
                    procwords[65] = "HAVING";
                    procwords[66] = "ROWS";
                    procwords[67] = "CASCADE";
                    procwords[68] = "HOUR";
                    procwords[69] = "SCHEMA";
                    procwords[70] = "CASCADED";
                    procwords[71] = "IDENTITY";
                    procwords[72] = "SCROLL";
                    procwords[73] = "CASE";
                    procwords[74] = "IMMEDIATE";
                    procwords[75] = "SECOND";
                    procwords[76] = "CAST";
                    procwords[77] = "IN";
                    procwords[78] = "SECTION";
                    procwords[79] = "CATALOG";
                    procwords[80] = "INCLUDE";
                    procwords[81] = "SELECT";
                    procwords[82] = "CHAR";
                    procwords[83] = "INDEX";
                    procwords[84] = "SESSION";
                    procwords[85] = "CHAR_LENGTH";
                    procwords[86] = "INDICATOR";
                    procwords[87] = "SESSION_USER";
                    procwords[88] = "CHARACTER";
                    procwords[89] = "INITIALLY";
                    procwords[90] = "SET";
                    procwords[91] = "CHARACTER_LENGTH";
                    procwords[92] = "INNER";
                    procwords[93] = "SIZE";
                    procwords[94] = "CHECK";
                    procwords[95] = "INPUT";
                    procwords[96] = "SMALLINT";
                    procwords[97] = "CLOSE";
                    procwords[98] = "INSENSITIVE";
                    procwords[99] = "SOME";
                    procwords[100] = "COALESCE";
                    procwords[101] = "INSERT";
                    procwords[102] = "SPACE";
                    procwords[103] = "COLLATE";
                    procwords[104] = "INT";
                    procwords[105] = "SQL";
                    procwords[106] = "COLLATION";
                    procwords[107] = "INTEGER";
                    procwords[108] = "SQLCA";
                    procwords[109] = "COLUMN";
                    procwords[110] = "INTERSECT";
                    procwords[111] = "SQLCODE";
                    procwords[112] = "COMMIT";
                    procwords[113] = "INTERVAL";
                    procwords[114] = "SQLERROR";
                    procwords[115] = "CONNECT";
                    procwords[116] = "INTO";
                    procwords[117] = "SQLSTATE";
                    procwords[118] = "CONNECTION";
                    procwords[119] = "IS";
                    procwords[120] = "SQLWARNING";
                    procwords[121] = "CONSTRAINT";
                    procwords[122] = "ISOLATION";
                    procwords[123] = "SUBSTRING";
                    procwords[124] = "CONSTRAINTS";
                    procwords[125] = "JOIN";
                    procwords[126] = "SUM";
                    procwords[127] = "CONTINUE";
                    procwords[128] = "KEY";
                    procwords[129] = "SYSTEM_USER";
                    procwords[130] = "CONVERT";
                    procwords[131] = "LANGUAGE";
                    procwords[132] = "TABLE";
                    procwords[133] = "CORRESPONDING";
                    procwords[134] = "LAST";
                    procwords[135] = "TEMPORARY";
                    procwords[136] = "COUNT";
                    procwords[137] = "LEADING";
                    procwords[138] = "THEN";
                    procwords[139] = "CREATE";
                    procwords[140] = "LEFT";
                    procwords[141] = "TIME";
                    procwords[142] = "CROSS";
                    procwords[143] = "LEVEL";
                    procwords[144] = "TIMESTAMP";
                    procwords[145] = "CURRENT";
                    procwords[146] = "LIKE";
                    procwords[147] = "TIMEZONE_HOUR";
                    procwords[148] = "CURRENT_DATE";
                    procwords[149] = "LOCAL";
                    procwords[150] = "TIMEZONE_MINUTE";
                    procwords[151] = "CURRENT_TIME";
                    procwords[152] = "LOWER";
                    procwords[153] = "TO";
                    procwords[154] = "CURRENT_TIMESTAMP";
                    procwords[155] = "MATCH";
                    procwords[156] = "TRAILING";
                    procwords[157] = "CURRENT_USER";
                    procwords[158] = "MAX";
                    procwords[159] = "TRANSACTION";
                    procwords[160] = "CURSOR";
                    procwords[161] = "MIN";
                    procwords[162] = "TRANSLATE";
                    procwords[163] = "DATE";
                    procwords[164] = "MINUTE";
                    procwords[165] = "TRANSLATION";
                    procwords[166] = "DAY";
                    procwords[167] = "MODULE";
                    procwords[168] = "TRIM";
                    procwords[169] = "DEALLOCATE";
                    procwords[170] = "MONTH";
                    procwords[171] = "TRUE";
                    procwords[172] = "DEC";
                    procwords[173] = "NAMES";
                    procwords[174] = "UNION";
                    procwords[175] = "DECIMAL";
                    procwords[176] = "NATIONAL";
                    procwords[177] = "UNIQUE";
                    procwords[178] = "DECLARE";
                    procwords[179] = "NATURAL";
                    procwords[180] = "UNKNOWN";
                    procwords[181] = "DEFAULT";
                    procwords[182] = "NCHAR";
                    procwords[183] = "UPDATE";
                    procwords[184] = "DEFERRABLE";
                    procwords[185] = "NEXT";
                    procwords[186] = "UPPER";
                    procwords[187] = "DEFERRED";
                    procwords[188] = "NO";
                    procwords[189] = "USAGE";
                    procwords[190] = "DELETE";
                    procwords[191] = "NONE";
                    procwords[192] = "USER";
                    procwords[193] = "DESC";
                    procwords[194] = "NOT";
                    procwords[195] = "USING";
                    procwords[196] = "DESCRIBE";
                    procwords[197] = "NULL";
                    procwords[198] = "VALUE";
                    procwords[199] = "DESCRIPTOR";
                    procwords[200] = "NULLIF";
                    procwords[201] = "VALUES";
                    procwords[202] = "DIAGNOSTICS";
                    procwords[203] = "NUMERIC";
                    procwords[204] = "VARCHAR";
                    procwords[205] = "DISCONNECT";
                    procwords[206] = "OCTET_LENGTH";
                    procwords[207] = "VARYING";
                    procwords[208] = "DISTINCT";
                    procwords[209] = "OF";
                    procwords[210] = "VIEW";
                    procwords[211] = "DOMAIN";
                    procwords[212] = "ON";
                    procwords[213] = "WHEN";
                    procwords[214] = "DOUBLE";
                    procwords[215] = "ONLY";
                    procwords[216] = "WHENEVER";
                    procwords[217] = "DROP";
                    procwords[218] = "OPEN";
                    procwords[219] = "WHERE";
                    procwords[220] = "ELSE";
                    procwords[221] = "OPTION";
                    procwords[222] = "WITH";
                    procwords[223] = "END";
                    procwords[224] = "OR";
                    procwords[225] = "WORK";
                    procwords[226] = "END-EXEC";
                    procwords[227] = "ORDER";
                    procwords[228] = "WRITE";
                    procwords[229] = "ESCAPE";
                    procwords[230] = "OUTER";
                    procwords[231] = "YEAR";
                    procwords[232] = "EXCEPT";
                    procwords[233] = "OUTPUT";
                    procwords[234] = "ZONE";
                    procwords[235] = "EXCEPTION";

                    //int startpos = richTextBox4.Text.LastIndexOf(" ")-1;
                    //int currentpos = richTextBox4.Text.Length;
                    caretposition = richTextBox4.SelectionStart;

                    int caretline = richTextBox4.GetFirstCharIndexOfCurrentLine();

                    if (caretposition == 0)
                    {
                        indexchar = "\n";
                    }

                    if (caretposition > 0)
                    {
                        indexchar = " ";
                    }

                    beforetext = richTextBox4.Text.Substring(caretline, caretposition - caretline);

                    //richTextBox4.Select(lastspacebeforetext = beforetext.LastIndexOf(' ') + 1, currentlen);

                    lastspacebeforetext = beforetext.LastIndexOf(indexchar);

                    //string rtbnl1 = richTextBox4.Text.Replace("\n", " ");
                    //int ls11 = rtbnl1.LastIndexOf(" ");
                    //int ls = richTextBox4.Text.LastIndexOf(" ");

                    int lineIndex = richTextBox4.GetLineFromCharIndex(richTextBox4.SelectionStart);
                    string[] split = beforetext.Split(indexchar);

                    string[] splitrev = split.Reverse().ToArray();

                    holds = splitrev;

                    //currentword = splitrev[0];

                    string seclas = holds[0].Replace("\n", " ");

                    int seclascursor = holds[0].LastIndexOf(" ");

                    //if (ls != -1)
                    //{
                    //lastword = richTextBox4.Text.Substring(richTextBox4.Text.Substring(0, richTextBox4.Text.LastIndexOf(" ")).LastIndexOf(" ") + 1);   
                    //}

                    int lastwordlen = seclas.Length;
                    string lwup = seclas.ToUpper();

                    if ((seclas1.Contains("*")) == false)
                    {

                        if (procwords.Contains(lwup))
                        {
                            laswor = seclas;
                            dotextstuff3(sender, e);

                        }

                        if ((procwords.Contains(lwup)) == false)
                        {
                            laswor = seclas;
                            dotextstuffblack3(sender, e);

                        }
                    }
                }
            }
        }


        private void richTextBox5_KeyDowns2

           (object sender, EventArgs e)
        {

            textBox9.Visible = false;
            textBox10.Visible = false;
            dataGridView6.Visible = true;

            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView3.ColumnHeadersVisible = false;
            this.dataGridView4.ColumnHeadersVisible = false;
            this.dataGridView5.ColumnHeadersVisible = false;
            this.dataGridView6.ColumnHeadersVisible = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            //label18.Visible = true;
            label19.Visible = false;
            //label12.Visible = false;
            //label14.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            this.label17.Location = new System.Drawing.Point(268, 110);
            this.label17.Text = "Not Connected";
            this.label17.TextAlign = ContentAlignment.TopRight;
            this.label17.ForeColor = System.Drawing.Color.Black;
            contextMenuStrip1.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            contextMenuStrip2.Enabled = false;
            toolStripMenuItem2.Enabled = false;
            sqlcomm = "";

            quer = richTextBox2.Text;





            if (backgroundWorker5.IsBusy != true)
            {
                try
                {
                    backgroundWorker6.RunWorkerAsync();
                    label24.Visible = true;
                    busy = true;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    MessageBox.Show(msg + Environment.NewLine + "An issue ocurred between BGWorker5 and BGWorker6");

                }
            }


        }


        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {




            BeginInvoke((MethodInvoker)delegate
            {
                quer2 = richTextBox4.Text;
                dataGridView6.DataSource = null;
                dataGridView7.DataSource = null;
                //dataGridView6.Visible = false;
                //dataGridView7.Visible = false;
                groupBox8.Text = "Results";
                textBox9.Visible = false;
                textBox10.Visible = false;
                label24.Visible = true;
                label30.Visible = true;
            });

            {
                if (radioButton1.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", "; Trusted_Connection=True;");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.ins).ToString();
                }

                else if (radioButton2.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; User Id=", "; Password=", ";");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.u + textBox3.Text + connectionstring.p + textBox4.Text + connectionstring.ins).ToString();
                }

                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker != null)

                {

                    try
                    {
                        using (SqlConnection cmd = new SqlConnection(connex))
                        {

                            sqlcomm = sqlquery1 + " " + quer + " " + sqlquery2;
                            //sqlcomm2 = sqlquery1 + " " + quer2 + Environment.NewLine + quer + " " + sqlquery2;

                            SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd);
                            // SqlCommand cmd2 = new SqlCommand(sqlcomm2, cmd);

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            static void OpenAndSetArithAbort(SqlConnection cmd)
                            {

                                using (SqlCommand cmd2 = cmd.CreateCommand())
                                {
                                    cmd2.CommandType = CommandType.Text;
                                    cmd2.CommandText = "SET ARITHABORT ON";
                                    cmd2.CommandTimeout = 0;
                                    cmd.Open();
                                    cmd2.ExecuteNonQuery();
                                }

                                return;
                            }

                            OpenAndSetArithAbort(cmd);

                            if (cmd.State == ConnectionState.Open)

                            {
                                BeginInvoke((MethodInvoker)delegate
                                {
                                    label17.Text = "Connected";
                                    this.label17.Location = new System.Drawing.Point(288, 112);
                                    this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                }
                             );


                                if (cmd == null)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connection Failed";
                                        this.label17.Location = new System.Drawing.Point(255, 112);
                                        this.label17.ForeColor = System.Drawing.Color.DarkRed;
                                    }
                                 );

                                }

                            }

                            

                            adapter.SelectCommand = cmd1;
                            DataTable ds = new DataTable();
                            adapter.Fill(ds);


                            if (dta != null)
                            {

                                if (dta.Rows.Count > 0)
                                {
                                    dta.Rows.Clear();
                                }
                            }


                            foreach (DataColumn dc in ds.Columns)
                            {

                                foreach (DataRow dr in ds.Rows)
                                {

                                    {
                                        
                                        dta = dr.Table;
                                        dta.AcceptChanges();

                                        e.Result = true;
                                        return;


                                    }
                                }

                                return;
                            }

                        }
                    }
                    catch (SqlException ex)

                    {

                        if (worker.CancellationPending == true)

                            return;

                        {
                            string msg = ex.Message;
                            BeginInvoke((MethodInvoker)delegate
                                            {
                                                //MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                                dataGridView6.Rows.Clear();
                                                dataGridView7.Rows.Clear();
                                                textBox9.Visible = true;
                                                errormessages = msg;
                                                groupBox11.Text = "Error";
                                                groupBox12.Text = "Error";
                                                label24.Visible = false;
                                                label25.Visible = false;
                                                label30.Visible = false;
                                                label31.Visible = false;
                                            });

                        }

                    }



                    finally
                    {
                        
                        secondsql(sender, e);
                        

                    }

                }
            }
        }


        //Command 2

        public void secondsql(Object sender, DoWorkEventArgs e)
        {


            BeginInvoke((MethodInvoker)delegate
            {
                quer2 = richTextBox4.Text;
                dataGridView6.DataSource = null;
                dataGridView7.DataSource = null;
                //dataGridView6.Visible = false;
                //dataGridView7.Visible = false;
                groupBox8.Text = "Results";
                textBox9.Visible = false;
                textBox10.Visible = false;
                label24.Visible = true;
                label30.Visible = true;
            });

            {
                if (radioButton1.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", "; Trusted_Connection=True;");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.ins).ToString();
                }

                else if (radioButton2.Checked == true)
                {
                    Form1 connectionstring = new Form1("Server=", "; Database=", "; User Id=", "; Password=", ";");
                    connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.u + textBox3.Text + connectionstring.p + textBox4.Text + connectionstring.ins).ToString();
                }

                BackgroundWorker worker = sender as BackgroundWorker;
                if (worker != null)

                {


                    try
                    {
                        using (SqlConnection cmd0 = new SqlConnection(connex))

                        {

                            //sqlcomm = sqlquery1 + " " + quer + " " + sqlquery2;
                            sqlcomm = sqlquery1 + " " + quer2 + Environment.NewLine + quer + " " + sqlquery2;

                            SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd0);
                            // SqlCommand cmd2 = new SqlCommand(sqlcomm2, cmd);

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            static void OpenAndSetArithAbort(SqlConnection cmd0)
                            {

                                using (SqlCommand cmd2 = cmd0.CreateCommand())
                                {
                                    cmd2.CommandType = CommandType.Text;
                                    cmd2.CommandText = "SET ARITHABORT ON";
                                    cmd2.CommandTimeout = 0;
                                    cmd0.Open();
                                    cmd2.ExecuteNonQuery();
                                }

                                return;
                            }

                            OpenAndSetArithAbort(cmd0);

                            if (cmd0.State == ConnectionState.Open)

                            {
                                BeginInvoke((MethodInvoker)delegate
                                {
                                    label17.Text = "Connected";
                                    this.label17.Location = new System.Drawing.Point(288, 112);
                                    this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                }
                             );


                                if (cmd0 == null)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connection Failed";
                                        this.label17.Location = new System.Drawing.Point(255, 112);
                                        this.label17.ForeColor = System.Drawing.Color.DarkRed;
                                    }
                                 );

                                }

                            }

                            adapter.SelectCommand = cmd1;
                            DataTable ds = new DataTable();
                            adapter.Fill(ds);



                            if (dta2 != null)
                            {

                                if (dta2.Rows.Count > 0)
                                {
                                    dta2.Rows.Clear();
                                }
                            }



                            foreach (DataColumn dc in ds.Columns)
                            {

                                foreach (DataRow dr in ds.Rows)
                                {

                                    {

                                        dta2 = dr.Table;
                                        dta2.AcceptChanges();

                                        e.Result = true;
                                        return;


                                    }
                                }

                                return;
                            }

                        }
                    }
                    catch (SqlException ex2)

                    {

                        if (worker.CancellationPending == true)

                            return;

                        {
                            //string msg2 = ex2.Message;
                            //BeginInvoke((MethodInvoker)delegate
                            //{
                            //    //MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                            //    dataGridView6.Rows.Clear();
                            //    dataGridView7.Rows.Clear();
                            //    textBox10.Visible = true;
                            //    errormessages += msg2;
                            //    groupBox11.Text = "Error";
                            //    groupBox12.Text = "Error";
                            //    label24.Visible = false;
                            //    label25.Visible = false;
                            //    label30.Visible = false;
                            //    label31.Visible = false;
                            //});

                        }

                    }


                    finally
                    {
                        thirdsql(null,null);

                    }



                }
            }
        }


            public void thirdsql(Object sender, EventArgs e)
            {


                BeginInvoke((MethodInvoker)delegate
                {
                    quer2 = richTextBox4.Text;

                    //dataGridView6.Visible = false;
                    //dataGridView7.Visible = false;
                    groupBox8.Text = "Results";
                    textBox9.Visible = false;
                    textBox10.Visible = false;
                    label24.Visible = true;
                    label30.Visible = true;
                });

                {
                    if (radioButton1.Checked == true)
                    {
                        Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", "; Trusted_Connection=True;");
                        connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.ins).ToString();
                    }

                    else if (radioButton2.Checked == true)
                    {
                        Form1 connectionstring = new Form1("Server=", "; Database=", "; User Id=", "; Password=", ";");
                        connex = (connectionstring.s + textBox1.Text + connectionstring.d + textBox2.Text + connectionstring.u + textBox3.Text + connectionstring.p + textBox4.Text + connectionstring.ins).ToString();
                    }


                        try
                        {
                            using (SqlConnection cmd0 = new SqlConnection(connex))

                            {

                                //sqlcomm = sqlquery1 + " " + quer + " " + sqlquery2;
                                sqlcomm = sqlquery1 + " " + quer2 + " " + sqlquery2;

                                SqlCommand cmd1 = new SqlCommand(sqlcomm, cmd0);
                                // SqlCommand cmd2 = new SqlCommand(sqlcomm2, cmd);

                                SqlDataAdapter adapter = new SqlDataAdapter();
                                static void OpenAndSetArithAbort(SqlConnection cmd0)
                                {

                                    using (SqlCommand cmd2 = cmd0.CreateCommand())
                                    {
                                        cmd2.CommandType = CommandType.Text;
                                        cmd2.CommandText = "SET ARITHABORT ON";
                                        cmd2.CommandTimeout = 0;
                                        cmd0.Open();
                                        cmd2.ExecuteNonQuery();
                                    }

                                    return;
                                }

                                OpenAndSetArithAbort(cmd0);

                                if (cmd0.State == ConnectionState.Open)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connected";
                                        this.label17.Location = new System.Drawing.Point(288, 112);
                                        this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                    }
                                 );


                                    if (cmd0 == null)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connection Failed";
                                            this.label17.Location = new System.Drawing.Point(255, 112);
                                            this.label17.ForeColor = System.Drawing.Color.DarkRed;
                                        }
                                     );

                                    }

                                }

                                adapter.SelectCommand = cmd1;
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);

                                foreach (DataColumn dc in ds.Columns)
                                {

                                    foreach (DataRow dr in ds.Rows)
                                    {

                                        {

                                            dta3 = dr.Table;
                                            dta3.AcceptChanges();

                                            //e.Result = true;
                                            return;


                                        }
                                    }

                                    //return;
                                }

                            }
                        }
                        catch (SqlException ex2)

                        {

                         
                            {
                                string msg2 = ex2.Message;
                                BeginInvoke((MethodInvoker)delegate
                                {
                                    //MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                    errormessages += Environment.NewLine+msg2;

                                });

                            }

                        }


                        finally
                        {
                            //cmd0.Close();

                        }



                    
                }



                //        catch (Exception ex)
                //        {
                //            string msg = ex.Message;
                //            errormessages = (msg + Environment.NewLine);
                //            BeginInvoke((MethodInvoker)delegate
                //                            {
                //                                //MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                //                                dataGridView6.Rows.Clear();
                //                                dataGridView7.Rows.Clear();
                //                                textBox9.Visible = true;
                //                                textBox9.Text = errormessages;
                //                                groupBox11.Text = "Error";
                //                                groupBox12.Text = "Error";
                //                                label24.Visible = false;
                //                                label25.Visible = false;
                //                                label30.Visible = false;
                //                                label31.Visible = false;
                //                            });


                //        }

                //    }
                //}

                //finally
                //{

                //}
                //}
            }
        //            try
        //            {

        //                adapter2.SelectCommand = cmd2;
        //                DataTable ds2 = new DataTable();
        //                adapter2.Fill(ds2);
        //                if (dta2 != null)
        //                {
        //                    dta2.Clear();
        //                }

        //                foreach (DataColumn dc in ds2.Columns)
        //                {

        //                    foreach (DataRow dr in ds2.Rows)
        //                    {

        //                        {
        //                            dta2 = dr.Table;
        //                            dta2.AcceptChanges();

        //                            if (worker.CancellationPending == true)
        //                            {

        //                                cmd.Close();
        //                                e.Result = null;
        //                                return;

        //                            }

        //                            if (worker.CancellationPending == false)

        //                            {
        //                                e.Result = true;
        //                                return;

        //                            }
        //                        }
        //                    }
        //                }

        //            }




        //            catch (Exception ex)

        //            {
        //                if (worker.CancellationPending == true)

        //                    return;

        //                if (ex.Message != null)
        //                {
        //                    errormessages = (errormessages + ex.Message);


        //                    BeginInvoke((MethodInvoker)delegate
        //                    {
        //                        //MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
        //                        dataGridView6.Rows.Clear();
        //                        dataGridView7.Rows.Clear();
        //                        textBox9.Visible = true;
        //                        textBox9.Text = errormessages;
        //                        textBox10.Visible = true;
        //                        textBox10.Text = errormessages;
        //                        groupBox11.Text = "Error";
        //                        groupBox12.Text = "Error";
        //                        label24.Visible = false;
        //                        label25.Visible = false;
        //                        label30.Visible = false;
        //                        label31.Visible = false;
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        cmd.Close();
        //        cmds.Close();
        //    }
        //} }





        //catch (Exception ex)
        //{
        //    string msg = "Please enter valid connection details.";
        //    //MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);

        //    BeginInvoke((MethodInvoker)delegate
        //    {
        //        dataGridView5.Rows.Clear();
        //        dataGridView6.Rows.Clear();
        //        dataGridView7.Rows.Clear();
        //    });
        //}









        public void HideHeaders3(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource is null)
            {
                dataGridView4.ColumnHeadersVisible = false;
                dataGridView4.ReadOnly = true;
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.ScrollBars = ScrollBars.None;
            }

        }

        async void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            {

                {

                    dataGridView6.DataBindings.Clear();
                    dataGridView7.DataBindings.Clear();

                    f5pressed = false;
                    ctp = "ctp4";
                    button3.Enabled = true;
                    button3.Text = "Results to Clipboard";
                    label23.Visible = false;
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    label23.Text = "Working...";
                    label24.Visible = false;
                    label30.Visible = false;
                    ctp = "ctp4";

                    //dataGridView4.Rows.Clear();

                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();
                    if (dta != null)
                    {

                        dta = dta.Copy();
                        dataGridView7.DataSource = null;
                        dataGridView7.Refresh();
                        dataGridView7.DataSource = dta;
                        dataGridView7.ScrollBars = ScrollBars.Both;
                        dataGridView7.Visible = true;


                        if (dta.Rows.Count < 1 && errormessages == null)
                        {
                            label24.Visible = true;
                            dataGridView7.ScrollBars = ScrollBars.None;
                            textBox9.Visible = false;
                            textBox9.Text = errormessages;
                            this.dataGridView7.ColumnHeadersVisible = false;
                            dataGridView7.DataSource = null;
                            dataGridView7.Refresh();

                        }


                        if (dta.Rows.Count > 0)
                        {
                            label24.Visible = false;
                            label25.Visible = false;
                            this.dataGridView7.ColumnHeadersVisible = true;
                        }



                        if (dta.Rows.Count < 1 && errormessages != null)
                        {
                            //label31.Visible = true;
                            this.dataGridView7.ColumnHeadersVisible = false;
                            button3.Enabled = false;
                            textBox9.Visible = true;
                            textBox9.Text = errormessages;
                            dataGridView7.DataSource = null;
                            dataGridView7.Refresh();
                        }

                       
                    }

                   
                        if (dta is null)
                        {

                        dataGridView7.Visible = false;
                        dataGridView7.DataSource = null;
                        dataGridView7.Refresh();

                        if (errormessages != "")
                        {
                            //label31.Visible = true;
                            this.dataGridView7.ColumnHeadersVisible = false;
                            button3.Enabled = false;
                            textBox9.Visible = true;
                            textBox9.Text = errormessages;

                        }

                        if (errormessages == null || errormessages == "")
                        {
                            label31.Visible = true;
                            label25.Visible=true;
                            this.dataGridView7.ColumnHeadersVisible = false;
                            button3.Enabled = false;
                            textBox9.Visible = false;
                            textBox10.Visible = false;
                            //textBox9.Text = errormessages;
                            dataGridView7.DataSource = null;
                            dataGridView7.Refresh();
                        }



                    }


                    if (dta2 != null)
                    {

                        dta2 = dta2.Copy();
                        dataGridView6.DataSource = null;
                        dataGridView6.Refresh();
                        dataGridView6.DataSource = dta2;
                        dataGridView6.ScrollBars = ScrollBars.Both;
                        dataGridView6.Visible = true;


                        if (dta2.Rows.Count < 1 && errormessages == null)
                        {
                            label30.Visible = true;
                            dataGridView6.ScrollBars = ScrollBars.None;
                            textBox10.Visible = false;
                            textBox10.Text = errormessages;
                            this.dataGridView6.ColumnHeadersVisible = false;
                            dataGridView6.DataSource = null;
                            dataGridView6.Refresh();

                        }


                        if (dta2.Rows.Count > 0)
                        {
                            label30.Visible = false;
                            label31.Visible = false;
                            this.dataGridView6.ColumnHeadersVisible = true;
                        }



                        if (dta2.Rows.Count < 1 && errormessages != null)
                        {
                            //label31.Visible = true;
                            this.dataGridView6.ColumnHeadersVisible = false;
                            button3.Enabled = false;
                            textBox10.Visible = true;
                            textBox10.Text = errormessages;
                            dataGridView6.DataSource = null;
                            dataGridView6.Refresh();
                        }

                        

                    }


                    if (dta2 is null)
                    {

                        dataGridView6.Visible = false;
                        dataGridView6.DataSource = null;
                        dataGridView6.Refresh();

                        if (errormessages != "")
                        {
                            //label31.Visible = true;
                            this.dataGridView6.ColumnHeadersVisible = false;
                            button3.Enabled = false;
                            textBox10.Visible = true;
                            textBox10.Text = errormessages;

                        }

                        if (errormessages == null || errormessages == "")
                        {
                            //label31.Visible = true;
                            this.dataGridView6.ColumnHeadersVisible = false;
                            button3.Enabled = false;
                            textBox10.Visible = false;
                            label31.Visible = true;
                            label25.Visible = true;
                            //textBox9.Text = errormessages;
                            dataGridView6.DataSource = null;
                            dataGridView6.Refresh();
                        }



                    }




                    busy = false;
                    richTextBox4.Enabled = true;
                    richTextBox2.Enabled = true;
                    errormessages = "";
                  

                }
            }
        }

        private void groupBox8_Enter3(object sender, EventArgs e)
        {

        }


        public void treeviewbuild3()
        {



        }

        private void getdbdetails3(object sender, EventArgs e)
        {

            lineIndex = richTextBox4.GetLineFromCharIndex(caretposition);

            int txtlen = richTextBox4.Text.Length;

            richTextBox4.SelectedText = "";

            caretposition = richTextBox4.SelectionStart;

            string tosplit = richTextBox4.Text.Replace("\n", " ");

            string[] rtbarray = tosplit.Split(" ");




            //{
            splits = 1;
            //}



            string beforetext = richTextBox4.Text.Substring(0, caretposition);

            string beforetextedited = beforetext.Replace("\n", " ");

            string aftertext = richTextBox4.Text.Substring(caretposition, (richTextBox4.Text.Length - caretposition));

            if (beforetextedited.LastIndexOf(" ") < 0)
            {
                lsp = 0;
            }

            else
            {
                lsp = beforetextedited.LastIndexOf(" ");
            }

            richTextBox4.Select(lsp, caretposition - lsp);

            string wrd = richTextBox4.SelectedText.ToString();


            if (beforetext.Contains("\n"))
            {
                containsreturn = true;
            }

            if (!beforetext.Contains("\n"))
            {
                containsreturn = false;
            }


            //lastspacebeforetext = beforetext.LastIndexOf(' ');

            //lineIndex = richTextBox4.GetLineFromCharIndex(caretposition);

            //splitint = beforetext.LastIndexOf(" ");

            //if (splitint > 0)
            //{

            //    string[] split = beforetext.Split(' ');

            //    int splitcount = split.Count();

            //    if (splitcount <= 2)
            //    {
            //        holds = split.ToArray();
            //    }

            //   if (splitcount > 2 && caretposition > lastspacebeforetext)
            //   {
            //        holds = split.Reverse().ToArray();
            //        splits = 0;

            //    }
            currentword = wrd.Replace('\n', ' ');

            if (listBox2.Visible == true)
            {
                currentlen = 0;
            }


            if (listBox2.Visible == false)
            {

                currentlen = currentword.Length;
            }

            currentcaretposition = richTextBox4.SelectionStart;

            richTextBox4.DeselectAll();



            //this.tablelist = new List<string>();
            //this.columnlist = new List<string>();


            //if (Keys.Control != 0 && e.KeyData == Keys.OemPeriod)

            //if (richTextBox4.SelectionStart >= 0 && richTextBox4.Text.LastIndexOf(' ') >= 0)
            //{

            //string lastWord = richTextBox4.Text.TrimEnd().Substring(richTextBox4.Text.TrimEnd().LastIndexOf(' ')).Trim();

            //TABLES

            Form1 connectionstring = new Form1("Server=", "; Database=", "; username=", "; password=", ";Trusted_Connection=True;");
            string cnxstr = (connectionstring.s + "DESKTOP-99C3KON" + connectionstring.d + "NORTHWIND" + connectionstring.ins).ToString();


            SqlConnection conn = new SqlConnection(cnxstr);


            string command = "select table_name FROM INFORMATION_SCHEMA.TABLES where table_name like '%" + currentword + "%'";
            SqlCommand cmd = new SqlCommand(command);
            cmd.Connection = conn;
            string result = command.ToString();
            conn.Open();

            //DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable ds = new DataTable();
            adapter.Fill(ds);


            //foreach (DataRow dr in ds.Rows)
            //{
            //    BeginInvoke((MethodInvoker)delegate
            //    {

            //        string l = dr[0].ToString();
            //        tablelist.Add(l);

            //    });

            //}
            //COLUMNS

            Form1 connectionstring2 = new Form1("Server=", "; Database=", "; username=", "; password=", ";Trusted_Connection=True;");
            string cnxstr2 = (connectionstring.s + "DESKTOP-99C3KON" + connectionstring2.d + "NORTHWIND" + connectionstring2.ins).ToString();


            SqlConnection conn2 = new SqlConnection(cnxstr2);


            string command2 = "select concat(table_name,'.',column_name) FROM INFORMATION_SCHEMA.COLUMNS where column_name like '%" + currentword.Replace(" ", "") + "%'";
            SqlCommand cmd2 = new SqlCommand(command2);
            cmd2.Connection = conn2;
            string result2 = command2.ToString();
            conn2.Open();

            //DataTable dt = new DataTable();

            SqlDataAdapter adapter2 = new SqlDataAdapter();
            adapter2.SelectCommand = cmd2;
            DataTable ds2 = new DataTable();
            adapter2.Fill(ds2);

            ListBox listBox = new ListBox();

            listBox2.Items.Clear();

            foreach (DataRow dr2 in ds2.Rows)
            {
                // BeginInvoke((MethodInvoker)delegate
                //{

                string l = dr2[0].ToString();
                //columnlist.Add(l);
                //contextMenuStrip4.Items.Add(l);
                listBox2.Items.Add(l);

                // });

            }


            listBox2.EndUpdate();
            listBox2.Refresh();


            if (listBox2.Items.Count == 0)
            {
                richTextBox4.SelectionStart = caretposition;
            }

            if (listBox2.Items.Count > 0)
            {
                autocompletebusy = true;

                richTextBox4.Select(lastspacebeforetext = beforetext.LastIndexOf(' ') + 1, currentlen + 1);

                string sl = richTextBox4.SelectedText;

                listBox2.Show();

                listBox2.Focus();

                //richTextBox4.Focus();

                int charpos = richTextBox4.SelectionStart;

                Point carpos = richTextBox4.GetPositionFromCharIndex(charpos);

                listBox2.Location = carpos;
                listBox2.Visible = true;
                listBox2.SetSelected(0, true);
            }


            autocomplete = false;
            autocompletebusy = false;





        }

        private void Lb_KeyDown3(object sender, KeyEventArgs e)
        {


            if (containsreturn == true)
            {
                addchar = "\n";
            }

            if (containsreturn == false)
            {
                addchar = "";
            }



            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {

                if (e.KeyCode == Keys.Down)
                {
                    if (listBox2.SelectedIndex < (listBox2.Items.Count - 1))
                        listBox2.SelectedIndex++;
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (listBox2.SelectedIndex > 0)
                        listBox2.SelectedIndex--;
                    e.Handled = true;
                }

            }

            //if 
            //(
            //    e.KeyData != Keys.Enter || e.KeyCode != Keys.Tab || 
            //    e.KeyCode != Keys.Up || e.KeyCode != Keys.Down)
            //{

            //    if (listBox2.Visible == true)
            //    {
            //        listBox2.Visible = false;
            //    }
            //}


            if (e.KeyData == Keys.Enter)
            {

                richTextBox4.GetLineFromCharIndex(lineIndex);


                if (listBox2.SelectedIndex != -1)
                {
                    string beforetext = richTextBox4.Text.Substring(0, caretposition);

                    string beforetext2 = beforetext.Replace("\n", " ");

                    lastspacebeforetext = beforetext2.LastIndexOf(' ');



                    if (listBox2.Visible == true)
                    {



                        richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                        richTextBox4.SelectionColor = Color.Black;

                        richTextBox4.SelectedText = listBox2.SelectedItem.ToString() + " " + addchar;

                        autocomplete = false;

                        richTextBox4.Focus();



                    }

                    listBox2.Hide();

                    listBox2.Visible = false;

                    autocompletebusy = false;
                    autocomplete = false;

                    richTextBox4.DeselectAll();
                    richTextBox4.Refresh();
                }
            }


            if (e.KeyCode == Keys.Left && listBox2.SelectedItem is not null)
            {



                string beforetext = richTextBox4.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');



                //if (listBox2.Visible == true)
                //{



                //    richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                //    richTextBox4.SelectedText = listBox2.SelectedItem.ToString() + " ";

                //    autocomplete = false;

                //    richTextBox4.Focus();



                //}



                if (listBox2.Visible == true)
                {
                    //richTextBox4.Select(lastspace, currentlen + 2);

                    //richTextBox4.SelectedText = "";

                    //string appendageleft = listBox2.SelectedItem.ToString().Split('.')[0];

                    //richTextBox4.AppendText(" " + appendageleft);

                    //listBox2.Hide();

                    //int sellength = listBox2.SelectedItem.ToString().Length;

                    //autocomplete = false;

                    //richTextBox4.Focus();

                    //richTextBox4.SelectionStart = lastspace + sellength + 1;


                    richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox4.SelectionColor = Color.Black;

                    string appendageleft = listBox2.SelectedItem.ToString().Split('.')[0];

                    richTextBox4.SelectedText = appendageleft + " " + addchar;

                    autocomplete = false;

                    richTextBox4.Focus();

                    listBox2.Hide();
                    //richTextBox4.SelectionStart = caretposition;

                    richTextBox4.Focus();
                    richTextBox4.DeselectAll();
                    richTextBox4.Refresh();


                }
            }


            if (e.KeyCode == Keys.Right && listBox2.SelectedItem is not null)
            {

                string beforetext = richTextBox4.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');

                int lastcharacter = beforetext.Length - 1;

                if (beforetext.Substring(0, lastcharacter) == "\n")
                {
                    newlineonened = true;
                }


                if (beforetext.Substring(0, lastcharacter) != "\n")
                {
                    newlineonened = false;
                }


                //if (listBox2.Visible == true)
                //{



                //    richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                //    richTextBox4.SelectedText = listBox2.SelectedItem.ToString() + " ";

                //    autocomplete = false;

                //    richTextBox4.Focus();



                //}



                if (listBox2.Visible == true)
                {
                    //richTextBox4.Select(lastspace, currentlen + 2);

                    //richTextBox4.SelectedText = "";

                    //string appendageleft = listBox2.SelectedItem.ToString().Split('.')[0];

                    //richTextBox4.AppendText(" " + appendageleft);

                    //listBox2.Hide();

                    //int sellength = listBox2.SelectedItem.ToString().Length;

                    //autocomplete = false;

                    //richTextBox4.Focus();

                    //richTextBox4.SelectionStart = lastspace + sellength + 1;


                    richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);


                    richTextBox4.SelectionColor = Color.Black;


                    string appendageright = listBox2.SelectedItem.ToString().Split('.')[1];

                    richTextBox4.SelectedText = appendageright + " " + addchar;

                    //richTextBox4.SelectionStart = caretposition;

                    autocomplete = false;

                    richTextBox4.Focus();

                    listBox2.Hide();
                    //richTextBox4.SelectionStart = caretposition;

                    richTextBox4.Focus();
                    richTextBox4.DeselectAll();
                    richTextBox4.Refresh();




                }
            }





            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                listBox2.Hide();
                richTextBox4.SelectionStart = caretposition;
                richTextBox4.DeselectAll();
                richTextBox4.Focus();
                richTextBox4.Refresh();

            }


        }


        private void lbhide(object sender, EventArgs e)
        {
            lb.Hide();
        }

        private void lb_click(object sender, EventArgs e)
        {

            richTextBox1.GetLineFromCharIndex(lineIndex);


            if (lb.SelectedIndex != -1)
            {
                string beforetext = richTextBox1.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');



                if (lb.Visible == true)
                {



                    richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox1.SelectionColor = Color.Black;

                    richTextBox1.SelectedText = lb.SelectedItem.ToString() + " " + addchar;

                    autocomplete = false;

                    richTextBox1.Focus();



                }

                lb.Hide();

                lb.Visible = false;

                autocompletebusy = false;
                autocomplete = false;

                richTextBox1.DeselectAll();
                richTextBox1.Refresh();
            }

        }



        private void lb_click2(object sender, EventArgs e)
        {

            richTextBox2.GetLineFromCharIndex(lineIndex);


            if (listBox1.SelectedIndex != -1)
            {
                string beforetext = richTextBox2.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');



                if (listBox1.Visible == true)
                {



                    richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox2.SelectionColor = Color.Black;

                    richTextBox2.SelectedText = listBox1.SelectedItem.ToString() + " " + addchar;

                    autocomplete = false;

                    richTextBox2.Focus();



                }

                listBox1.Hide();

                listBox1.Visible = false;

                autocompletebusy = false;
                autocomplete = false;

                richTextBox2.DeselectAll();
                richTextBox2.Refresh();
            }

        }


        private void lb_click3(object sender, EventArgs e)
        {

            richTextBox4.GetLineFromCharIndex(lineIndex);


            if (listBox2.SelectedIndex != -1)
            {
                string beforetext = richTextBox4.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');



                if (listBox2.Visible == true)
                {



                    richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox4.SelectionColor = Color.Black;

                    richTextBox4.SelectedText = listBox2.SelectedItem.ToString() + " " + addchar;

                    autocomplete = false;

                    richTextBox4.Focus();



                }

                listBox2.Hide();

                listBox2.Visible = false;

                autocompletebusy = false;
                autocomplete = false;

                richTextBox4.DeselectAll();
                richTextBox4.Refresh();
            }

        }


    }


    

}



    





