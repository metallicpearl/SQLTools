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
        }


        /// <summary>
        /// Non-SQL String declarations
        /// </summary>

        public string resultas;
        public DataAdapter dataAdap;
        public DataTable dta;
        public DataSet dsa;
        public string connex;
        public string sqlcomm;
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
        public bool relationshipsearchsuccess;
        public string? builtpath;
        public bool actualclick;
        public string holdingpath;
        

        /// <summary>
        /// SQL declarations
        /// </summary>

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
                o1.[name] [Referencing table],
                replace(fk.[name],(SUBSTRING(fk.[name], 1,
                CHARINDEX('_',fk.[name], CHARINDEX('_', fk.[name], 0) + 1))),'') [Referencing column],
                objref.[name] [Referenced table], 
                col1.[name] [Referenced column]

                FROM sys.objects o1
                    INNER JOIN sys.foreign_keys fk
                        ON o1.object_id = fk.parent_object_id
                    INNER JOIN sys.foreign_key_columns fkc
                        ON fk.object_id = fkc.constraint_object_id
	                join sys.objects objref on objref.object_id = fkc.referenced_object_id
	                join sys.objects sobj on sobj.object_id = fk.referenced_object_id
	                inner join sys.tables tab on tab.object_id = fkc.referenced_object_id
	                inner join sys.columns col1 on col1.column_id = fkc.referenced_column_id AND col1.object_id = tab.object_id
                where tab.[name] = @table";


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
                o1.[name][Referencing table],
                replace(fk.[name], (SUBSTRING(fk.[name], 1,
                CHARINDEX('_', fk.[name], CHARINDEX('_', fk.[name], 0) + 1))),'') [Referencing column],
                objref.[name][Referenced table], 
                col1.[name][Referenced column]

                FROM sys.objects o1
                    INNER JOIN sys.foreign_keys fk
                        ON o1.object_id = fk.parent_object_id
                    INNER JOIN sys.foreign_key_columns fkc
                        ON fk.object_id = fkc.constraint_object_id

                    join sys.objects objref on objref.object_id = fkc.referenced_object_id

                    join sys.objects sobj on sobj.object_id = fk.referenced_object_id

                    inner join sys.tables tab on tab.object_id = fkc.referenced_object_id

                    inner join sys.columns col1 on col1.column_id = fkc.referenced_column_id AND col1.object_id = tab.object_id
                where tab.[name] LIKE '%";

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
            this.label17.Location = new System.Drawing.Point(268, 110);
            this.label17.Text = "Not Connected";
            this.label17.TextAlign = ContentAlignment.TopRight;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView3.ColumnHeadersVisible = false;
            contextMenuStrip1.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            contextMenuStrip2.Enabled = false;
            toolStripMenuItem2.Enabled = false;
            sqlcomm = "";

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
                                        this.label17.Location = new System.Drawing.Point(288, 110);
                                        this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                    }
                                 );


                                    if (cmd == null)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connection Failed";
                                            this.label17.Location = new System.Drawing.Point(255, 110);
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
                    button3.Text = "Copy Results to Clipboard";
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
            this.label17.Location = new System.Drawing.Point(268, 110);
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
                                        this.label17.Location = new System.Drawing.Point(288, 110);
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
                button3.Text = "Copy Results to Clipboard";
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
            this.label17.Location = new System.Drawing.Point(268, 110);
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
                                        this.label17.Location = new System.Drawing.Point(288, 110);
                                        this.label17.ForeColor = System.Drawing.Color.DarkGreen;
                                    }
                                 );


                                    if (cmd == null)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connection Failed";
                                            this.label17.Location = new System.Drawing.Point(255, 110);
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
                button3.Text = "Copy Results to Clipboard";
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
                        builtpath = ("--START OF SEARCH--" + Environment.NewLine + textBox6.Text + " < [Initial Search Term]");

                    }


                    if (builtpath == null && dataGridView3 != null)
                    {
                        builtpath = ("--START OF SEARCH--"+Environment.NewLine+textBox6.Text + " < [Initial Search Term]"+Environment.NewLine + "Table: " + dataGridView3.SelectedCells[0].Value + " | Column: " + dataGridView3.SelectedCells[1].Value);

                    }

             


                    if (builtpath != null && dataGridView3.SelectedCells.Count != 0 && builtpath != "--START OF SEARCH--" + Environment.NewLine + textBox6.Text + " < [Initial Search Term]" + Environment.NewLine + "Table: " + dataGridView3.SelectedCells[0].Value + " | Column: " + dataGridView3.SelectedCells[1].Value)


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
                    actualclick =false;
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
                builtpath += Environment.NewLine+"--END OF SEARCH--";
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



        public void checkenter1 (object sender, KeyEventArgs e)
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
            radioButton7.Checked =false;
            searchmode = "exact";
        }

   
        private void differentiatesearch(object sender, EventArgs e)
        {
            builtpath = null;
            startAsyncButton_Click3(sender, e);
        }
    
    }

}



    





