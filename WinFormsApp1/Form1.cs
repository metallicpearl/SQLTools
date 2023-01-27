using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SqlPrettify;



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

            backgroundWorker7.DoWork += new DoWorkEventHandler(backgroundWorker7_DoWork);
            backgroundWorker7.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker7_RunWorkerCompleted);
            //backgroundWorker4.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker4_ProgressChanged);
            backgroundWorker7.WorkerSupportsCancellation = true;

            backgroundWorker8.DoWork += new DoWorkEventHandler(backgroundWorker8_DoWork);
            backgroundWorker8.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker8_RunWorkerCompleted);
            //backgroundWorker4.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker4_ProgressChanged);
            backgroundWorker8.WorkerSupportsCancellation = true;

            textBox9.Visible = false;
            textBox10.Visible = false;
            autocomplete = false;

            richTextBox4.Enabled = false;

            radioButton7.Checked = true;
            radioButton6.Checked = false;

            busy = false;


            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView2.AllowUserToResizeColumns = true;
            dataGridView3.AllowUserToResizeColumns = true;
            dataGridView4.AllowUserToResizeColumns = true;
            dataGridView5.AllowUserToResizeColumns = true;
            dataGridView6.AllowUserToResizeColumns = true;
            dataGridView7.AllowUserToResizeColumns = true;
            dataGridView8.AllowUserToResizeColumns = true;

            inedit = true;
            inedit2 = true;
            inedit3 = true;

            definitionmode = "Name";
            radioButton18.Checked = true;
            textBox15.Multiline = false;
            builtjoinsequence = 1;
            buildingjoins = false;
            checkBox2.Checked = true;
            checkBox2.Enabled = false;
            checkBox2.BackColor = Color.Transparent;
            comboBox1.Enabled = false;

            currenttab = 1;
            searchedfromgrid = false;
            lowmemorymode = false;


            void dataGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
            {
                if (e.Column.CellType == typeof(DataGridViewImageCell))
                {
                    dataGridView7.Columns.Remove(e.Column);
                }
            }


            checkforfile();


        }




        /// <summary>
        /// Non-SQL String declarations
        /// </summary>
        ///

        public bool containsspace;
        public bool hidelistbox;
        public bool outofrange;
        public bool lowmemorymode;
        public DataTable dtm1;
        public DataTable dtm2;
        public DataTable dtm3;
        public DataTable dtm4;
        public DataTable dtm5;
        public DataTable dtm6;
        public DataTable dtm7;
        public DataTable dtm8;
        public DataTable dtm9;
        public DataTable dtm10;
        public bool caretreset;
        public int curlin;
        public int comboxsel;
        public int stringpos;
        public string fulltext;
        public string fulltext2;
        public string[] formatspaces;
        public string[] splitspaces;
        public string searchtype;
        public string valuesearchstring;
        public string sqlversion;
        public bool withinbrackets;
        public string formatstring;
        public bool searchedfromgrid;
        public int currenttab;
        public string resultas;
        public DataAdapter dataAdap;
        public DataTable dta;
        public DataTable dta2;
        public DataTable dta3;
        public DataSet dsa;
        public DataTable initdat;
        public DataTable tablenames;
        public string connex;
        public string sqlcomm;
        public string sqlcomm2;
        public string ar;
        public string sqlcommarith;
        public string f3v;
        public string f4v;
        public string f5v;
        public string f6v;
        private static readonly AutoResetEvent event_1 = new AutoResetEvent(true);
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
        public string[] copiedrows;
        public DataTable copytable;
        public string copyrows;
        public string[] selectedrows;
        public string[] selectedcolumns;
        public int selcells;
        public int colindex;
        public int[] rowindex;
        public string tableselectionstring;
        public int gridnumber;
        public string errormessage = "";
        public bool datacleared;
        public string changederror = "";
        public string definitionsearch;
        public bool colouroff;
        public int ct1;
        public int ct2;
        public int ct3;
        public bool intis;
        public bool inedit;
        public bool inedit2;
        public bool inedit3;
        public bool tooltipshown;
        public string lastlineused;
        public string lastdefinitionsearched;
        public string builtjoinpath;
        public int builtjoinsequence;
        public bool buildingjoins;
        public string initialsearch;
        public string tablelimit;
        public bool colouring;

        public List<string> tablelist;
        public List<string> columnlist;
        public List<string> tablelist2;

        public string erorrmessage;
        public string workingmessage;
        public string definitionmode;
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
        c.COLUMN_NAME AS 'Column Name',
		c.DATA_TYPE AS 'Data Type',
		case when
		string_agg(
		case 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'FK' then 'Foreign Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'PK' then 'Primary Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'UQ' then 'NULL' 
		else null
		end, ', ')
		= 'Foreign Key, Primary Key' then 'Primary Key, Foreign Key' 
		else
		string_agg(
		case 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'FK' then 'Foreign Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'PK' then 'Primary Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'UQ' then 'NULL' 
		else null
		end, ', ')
		end
		[Constraint Type]
        FROM INFORMATION_SCHEMA.COLUMNS c
		left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE k ON k.COLUMN_NAME = c.COLUMN_NAME AND c.TABLE_NAME = k.TABLE_NAME
		left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t on t.CONSTRAINT_NAME = k.CONSTRAINT_NAME

        WHERE
        c.TABLE_NAME LIKE  '%";

        public string sql1legacy =
       @"
                
        SELECT 
        c.TABLE_NAME AS 'Table Name',
        c.COLUMN_NAME AS 'Column Name',
		c.DATA_TYPE AS 'Data Type'
        FROM INFORMATION_SCHEMA.COLUMNS c
		left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE k ON k.COLUMN_NAME = c.COLUMN_NAME AND c.TABLE_NAME = k.TABLE_NAME
		left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t on t.CONSTRAINT_NAME = k.CONSTRAINT_NAME

        WHERE
        c.TABLE_NAME LIKE  '%";


        public string sql2 =
              @"%' 
                AND 
                c.COLUMN_NAME LIKE '%";

        public string sql2legacy =
              @"%' 
                AND 
                c.COLUMN_NAME LIKE '%";


        public string sql3 =
              @"%' 
                and
				c.table_schema = 'dbo'
                GROUP BY c.COLUMN_NAME, c.TABLE_NAME, c.DATA_TYPE
                ORDER BY 
                c.Table_Name

                OPTION (RECOMPILE)
                ";

        public string sql3legacy =
          @"%' 
                and
				c.table_schema = 'dbo'
                GROUP BY c.COLUMN_NAME, c.TABLE_NAME, c.DATA_TYPE
                ORDER BY 
                c.Table_Name

                OPTION (RECOMPILE)
                ";


        public string sql4 =
              @"
                
        SELECT 
        c.TABLE_NAME AS 'Table Name',
        c.COLUMN_NAME AS 'Column Name',
		c.DATA_TYPE AS 'Data Type',
		case when
		string_agg(
		case 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'FK' then 'Foreign Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'PK' then 'Primary Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'UQ' then 'NULL' 
		else null
		end, ', ')
		= 'Foreign Key, Primary Key' then 'Primary Key, Foreign Key' 
		else
		string_agg(
		case 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'FK' then 'Foreign Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'PK' then 'Primary Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'UQ' then 'NULL' 
		else null
		end, ', ')
		end
		[Constraint Type]
        FROM INFORMATION_SCHEMA.COLUMNS c
		left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE k ON k.COLUMN_NAME = c.COLUMN_NAME AND c.TABLE_NAME = k.TABLE_NAME
		left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t on t.CONSTRAINT_NAME = k.CONSTRAINT_NAME

        WHERE
        c.COLUMN_NAME LIKE  '%";


        public string sql4legacy =
        @"
                
        SELECT 
        c.TABLE_NAME AS 'Table Name',
        c.COLUMN_NAME AS 'Column Name',
		c.DATA_TYPE AS 'Data Type'
        FROM INFORMATION_SCHEMA.COLUMNS c
		left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE k ON k.COLUMN_NAME = c.COLUMN_NAME AND c.TABLE_NAME = k.TABLE_NAME
		left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t on t.CONSTRAINT_NAME = k.CONSTRAINT_NAME

        WHERE
        c.COLUMN_NAME LIKE  '%";


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


        public string sql6c =
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
                        WHERE     TABLE_NAME = '"
                ;


        public string sql6d =

            @"'

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
							WHERE TABLE_SCHEMA = PARSENAME(@TableName, 2)
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



        public string sql6e =
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
                        WHERE     TABLE_NAME = '"
             ;


        public string sql6f =

            @"'

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
							WHERE TABLE_SCHEMA = PARSENAME(@TableName, 2)
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
  
	tab2.name AS [Referenced Table],
    col2.name AS [Referenced Column],
    tab1.name AS [Referencing Table],
    col1.name AS [Referencing Column]

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
        c.COLUMN_NAME AS 'Column Name',
		c.DATA_TYPE AS 'Data Type',
		case when
		string_agg(
		case 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'FK' then 'Foreign Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'PK' then 'Primary Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'UQ' then 'NULL' 
		else null
		end, ', ')
		= 'Foreign Key, Primary Key' then 'Primary Key, Foreign Key' 
		else
		string_agg(
		case 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'FK' then 'Foreign Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'PK' then 'Primary Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'UQ' then 'NULL' 
		else null
		end, ', ')
		end
		[Constraint Type]
        FROM INFORMATION_SCHEMA.COLUMNS c
		left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE k ON k.COLUMN_NAME = c.COLUMN_NAME AND c.TABLE_NAME = k.TABLE_NAME
		left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t on t.CONSTRAINT_NAME = k.CONSTRAINT_NAME

        WHERE
        c.TABLE_NAME = '";


        public string sql1blegacy =
@"
        SELECT 
        c.TABLE_NAME AS 'Table Name',
        c.COLUMN_NAME AS 'Column Name',
		c.DATA_TYPE AS 'Data Type'
        FROM INFORMATION_SCHEMA.COLUMNS c
		left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE k ON k.COLUMN_NAME = c.COLUMN_NAME AND c.TABLE_NAME = k.TABLE_NAME
		left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t on t.CONSTRAINT_NAME = k.CONSTRAINT_NAME

        WHERE
        c.TABLE_NAME = '";



        public string sql2b =
              @"' 
                AND 
                c.COLUMN_NAME = '";


        public string sql2blegacy =
        @"' 
                AND 
                c.COLUMN_NAME = '";


        public string sql3b =
              @"' 
               and
				c.table_schema = 'dbo'
                GROUP BY c.COLUMN_NAME, c.TABLE_NAME, c.DATA_TYPE
                ORDER BY 
                c.Table_Name

                OPTION (RECOMPILE)
                ";

        public string sql3blegacy =
      @"' 
               and
				c.table_schema = 'dbo'
                GROUP BY c.COLUMN_NAME, c.TABLE_NAME, c.DATA_TYPE
                ORDER BY 
                c.Table_Name

                OPTION (RECOMPILE)
                ";


        public string sql4b =
              @"
        SELECT 
        c.TABLE_NAME AS 'Table Name',
        c.COLUMN_NAME AS 'Column Name',
		c.DATA_TYPE AS 'Data Type',
		case when
		string_agg(
		case 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'FK' then 'Foreign Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'PK' then 'Primary Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'UQ' then 'NULL' 
		else null
		end, ', ')
		= 'Foreign Key, Primary Key' then 'Primary Key, Foreign Key' 
		else
		string_agg(
		case 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'FK' then 'Foreign Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'PK' then 'Primary Key' 
		when substring(k.constraint_name,1,charindex('_',k.constraint_name)-1) = 'UQ' then 'NULL' 
		else null
		end, ', ')
		end
		[Constraint Type]
        FROM INFORMATION_SCHEMA.COLUMNS c
		left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE k ON k.COLUMN_NAME = c.COLUMN_NAME AND c.TABLE_NAME = k.TABLE_NAME
		left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t on t.CONSTRAINT_NAME = k.CONSTRAINT_NAME

        WHERE
        c.COLUMN_NAME = '";


        public string sql4blegacy =
             @"
        SELECT 
        c.TABLE_NAME AS 'Table Name',
        c.COLUMN_NAME AS 'Column Name',
		c.DATA_TYPE AS 'Data Type'
        FROM INFORMATION_SCHEMA.COLUMNS c
		left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE k ON k.COLUMN_NAME = c.COLUMN_NAME AND c.TABLE_NAME = k.TABLE_NAME
		left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t on t.CONSTRAINT_NAME = k.CONSTRAINT_NAME

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
	tab2.name AS [Referenced Table],
    col2.name AS [Referenced Column],
    tab1.name AS [Referencing Table],
    col1.name AS [Referencing Column]

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

        public string sql9 =
            @"
    SELECT
    v.name [Name],
	case 

    when v.type = 'AF' then 'Aggregate Function'

    when v.type = 'IF' then 'Inline Table-Valued Function'

    when v.type = 'P' then 'Stored Procedure'

    when v.type = 'TF' then 'Table-Valued Function'

    when v.type = 'TR' then 'Trigger'

    when v.type = 'U' then 'User Table'

    when v.type = 'V' then 'View'

    when v.type = 'X' then 'Extended Stored Procedure'

	when v.type = 'FN' then 'Scalar Function'

    end[Type],

    ltrim(s.definition)[Definition]

    FROM

    sys.all_objects as v
    join

    sys.sql_modules s on s.object_id = v.object_id

    where
    v.schema_id = 1

   ";


        public string sql9b =
            @"
    SELECT
    v.name [Name],
	case 

    when v.type = 'AF' then 'Aggregate Function'

    when v.type = 'IF' then 'Inline Table-Valued Function'

    when v.type = 'P' then 'Stored Procedure'

    when v.type = 'TF' then 'Table-Valued Function'

    when v.type = 'TR' then 'Trigger'

    when v.type = 'U' then 'User Table'

    when v.type = 'V' then 'View'

    when v.type = 'X' then 'Extended Stored Procedure'

	when v.type = 'FN' then 'Scalar Function'

    end[Type],

    ltrim(s.definition)[Definition]

    FROM

    sys.all_objects as v
    join

    sys.sql_modules s on s.object_id = v.object_id

    where
    v.schema_id = 1

   ";



        public string sql10 =
    @"
 and

    definition is not null

    order by v.type asc

          ";



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



        public void workerbusy(object sender, EventArgs e)
        {
            string? msg = "A SQL Connection is already open in another tab. Please re-run this when that process has finished.";
            string? titl = "Cannot Start New SQL Process";
            MessageBox.Show(msg, titl, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void checkforfile()
        {

            try
            {
                // Open the text file using a stream reader.
                using (StreamReader? sr = new StreamReader("ConnectionDetails.txt"))
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
            catch (IOException)
            {
                string? msg = "The override file format is incorrect or the file is not in the application folder. The application will still work, but you will need to provide connection details to connect to the SQL server." + Environment.NewLine + Environment.NewLine + "'ConnectionDetails.txt' comma-separated format:" + Environment.NewLine + "'Server,Database,Username,Password,Authentication type'." + Environment.NewLine + Environment.NewLine + "If using 'Windows' as the authentication type, Username and Password are blank.";
                MessageBox.Show(msg, "Override File Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
            }

        }


        async void startAsyncButton_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            button8.Enabled = false;
            textBox11.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button10.Enabled = false;
            button9.Enabled = false;
            //this.label17.Location = new System.Drawing.Point(127, 111);
            label17.Text = "Not Connected";
            label17.TextAlign = ContentAlignment.TopRight;
            label17.ForeColor = System.Drawing.Color.Black;

            if (lowmemorymode == true)
            {
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView2.ColumnHeadersVisible = false;
                dataGridView3.ColumnHeadersVisible = false;
                dataGridView4.ColumnHeadersVisible = false;
                dataGridView5.ColumnHeadersVisible = false;
                dataGridView6.ColumnHeadersVisible = false;
                dataGridView7.ColumnHeadersVisible = false;
                dataGridView8.ColumnHeadersVisible = false;
            }

            //contextMenuStrip1.Enabled = false;
            //toolStripMenuItem1.Enabled = false;
            //toolStripMenuItem9.Enabled = false;
            //toolStripMenuItem10.Enabled = false;
            //toolStripMenuItem11.Enabled = false;
            //toolStripMenuItem12.Enabled = false;
            //contextMenuStrip2.Enabled = false;
            //toolStripMenuItem2.Enabled = false;
            //contextMenuStrip3.Enabled = false;
            //toolStripMenuItem3.Enabled = false;
            //CopyCell.Enabled = false;
            //CopyColumn.Enabled = false;
            //CopyRow.Enabled = false;




            sqlcomm = "";
            endpressed = false;

            if (dta != null)
            {
                dta.Clear();
            }


            if (busy == true)
            {
                workerbusy(sender, e);
                return;
            }

            if (busy != true)
            {
                try
                {
                    backgroundWorker1.RunWorkerAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            inedit = true;


        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                {

                   
                        if (dta is not null)
                        {
                            dta.Clear();
                        }

                        if (dta2 is not null)
                        {
                            dta2.Clear();
                        }

                        dta = null;
                        dta2 = null;
                    

                    BeginInvoke((MethodInvoker)delegate
                    {
                        if (lowmemorymode == true)
                        {
                            dataGridView1.DataSource = null;
                            dataGridView2.DataSource = null;
                            dataGridView3.DataSource = null;
                            dataGridView4.DataSource = null;
                            dataGridView5.DataSource = null;
                            dataGridView6.DataSource = null;
                            dataGridView7.DataSource = null;
                            dataGridView8.DataSource = null;
                        }
                        Text = "SQL Tools - WORKING...";
                        textBox11.Text = "Working...";
                        
                    });

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
                            SqlConnection cmd = new SqlConnection(connex); 

                            cmd.Open();
                            sqlversion = cmd.ServerVersion;
                            cmd.Close();

                            string verstring = sqlversion.Substring(0, sqlversion.IndexOf("."));
                            int version = Convert.ToInt32(verstring);

                           

                        
                          
                            try
                            {
                                if (radioButton7.Checked == true && (version >= 14))

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


                                if (radioButton6.Checked == true && (version >= 14))

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


                                {

                                    if (radioButton7.Checked == true && (version < 14))

                                    {

                                        if (radioButton3.Checked == true)
                                        {
                                            sqlcomm = (sql1legacy + textBox5.Text.ToString() + sql3legacy);
                                        }
                                        if (radioButton4.Checked == true)
                                        {
                                            sqlcomm = (sql4legacy + textBox7.Text.ToString() + sql3legacy);
                                        }
                                        if (radioButton5.Checked == true)
                                        {
                                            sqlcomm = (sql1legacy + textBox5.Text.ToString() + sql2legacy + textBox7.Text.ToString() + sql3legacy);
                                        }
                                    }


                                    if (radioButton6.Checked == true && (version < 14))

                                    {

                                        if (radioButton3.Checked == true)
                                        {
                                            sqlcomm = (sql1blegacy + textBox5.Text.ToString() + sql3blegacy);
                                        }
                                        if (radioButton4.Checked == true)
                                        {
                                            sqlcomm = (sql4blegacy + textBox7.Text.ToString() + sql3blegacy);
                                        }
                                        if (radioButton5.Checked == true)
                                        {
                                            sqlcomm = (sql1blegacy + textBox5.Text.ToString() + sql2blegacy + textBox7.Text.ToString() + sql3blegacy);
                                        }
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
                                        ////this.label17.Location = new System.Drawing.Point(288, 112);
                                        label17.ForeColor = System.Drawing.Color.DarkGreen;
                                        textBox11.Visible = true;
                                        textBox11.Text = "Working...";
                                    }
                                 );


                                    if (cmd == null)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connection Failed";
                                            ////this.label17.Location = new System.Drawing.Point(288, 112);
                                            label17.ForeColor = System.Drawing.Color.DarkRed;
                                        }
                                     );

                                    }

                                }
                                adapter.SelectCommand = cmd1;
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);

                                int ind = ds.Columns.IndexOf("RowVersion");
                                if (ind != -1)
                                {
                                    ds.Columns.RemoveAt(ind);
                                }

                                int ind2 = ds.Columns.IndexOf("TimeStamp");
                                if (ind2 != -1)
                                {
                                    ds.Columns.RemoveAt(ind2);
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
                                {
                                    return;
                                }

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
                        catch (Exception)
                        {
                            string msg = "Please enter valid connection details.";
                            MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                }
                return;
            }
        }


        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            textBox11.Visible = true;
            textBox11.Text = "Working...";
            button3.Enabled = false;
        }


        async void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {



            {

                BeginInvoke((MethodInvoker)delegate
                {
                    Text = "SQL Tools";
                });

                {
                    ctp = "ctp1";
                    button3.Enabled = true;
                    button3.Text = "Results to Clipboard";
                    //textBox11.Visible = false;
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    button8.Enabled = true;
                    ctp = "ctp1";


                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();




                    if (dta != null && dta.Rows.Count > 0)
                    {
                        contextMenuStrip1.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        toolStripMenuItem9.Enabled = true;
                        toolStripMenuItem10.Enabled = true;
                        toolStripMenuItem11.Enabled = true;
                        toolStripMenuItem12.Enabled = true;
                        dta = dta.Copy();

                        if (lowmemorymode == false)
                        {
                            dtm1 = dta.Copy();
                        }

                        if (lowmemorymode == false)
                        {
                            dataGridView1.DataSource = dtm1;

                        }

                        if (lowmemorymode == true)
                        {
                            dataGridView1.DataSource = dta;

                        }


                        dataGridView1.ColumnHeadersVisible = true;
                        textBox11.Visible = false;
                        textBox11.Text = "";

                       

                        string verstring = sqlversion.Substring(0, sqlversion.IndexOf("."));
                        int version = Convert.ToInt32(verstring);

                        if (version >= 14)

                        {
                            int keytype = dataGridView1.Columns.IndexOf(dataGridView1.Columns["Constraint Type"]);
                            int datatype = dataGridView1.Columns.IndexOf(dataGridView1.Columns["Data Type"]);
                            dataGridView1.Columns[datatype].SortMode = DataGridViewColumnSortMode.NotSortable;

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {

                                row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().ToUpper();

                                string? chk = row.Cells[keytype].Value.ToString();


                                if (chk == "Primary Key, Foreign Key")
                                {
                                    row.DefaultCellStyle.BackColor = SystemColors.ControlDark;
                                    row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().ToUpper() + " (Primary Key and Foreign Key)";
                                }

                                if (chk == "Primary Key")
                                {
                                    row.DefaultCellStyle.BackColor = SystemColors.ControlDark;
                                    row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().ToUpper() + " (Primary Key)";
                                }

                                if (row.Cells[keytype].Value.ToString() == "Foreign Key")
                                {
                                    row.DefaultCellStyle.BackColor = SystemColors.ControlLight;
                                    row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().ToUpper() + " (Foreign Key)";
                                }
                            }

                         

                            dataGridView1.Columns[keytype].Visible = false;

                        }

                        if (version < 14)
                        {
                            int datatype = dataGridView1.Columns.IndexOf(dataGridView1.Columns["Data Type"]);

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().ToUpper();
                            }
                        }

                        if (dta.Rows.Count < 1)
                        {
                            //textBox11.Visible = false;
                        }
                    }

                    if (dta is null || dta.Rows.Count == 0)
                    {
                        textBox11.Visible = true;
                        textBox11.Text = "No Results.";
                        dataGridView1.ColumnHeadersVisible = false;
                        button3.Enabled = false;
                    }

                    if (textBox11.Text == "Working..." || textBox11.Text != "")
                    {
                        //this.dataGridView1.ColumnHeadersVisible = false;
                        button3.Enabled = false;
                        //    contextMenuStrip1.Enabled = false;
                        //    toolStripMenuItem9.Enabled = false;
                        //    toolStripMenuItem10.Enabled = false;
                        //    toolStripMenuItem1.Enabled = false;
                        //    toolStripMenuItem10.Enabled = false;
                        //    toolStripMenuItem11.Enabled = false;
                        //    toolStripMenuItem12.Enabled = false;
                        //    contextMenuStrip2.Enabled = false;
                        //    toolStripMenuItem2.Enabled = false;
                    }

                }
            }

            busy = false;





        }


        /// <summary>
        /// Tab 2
        /// </summary>

        async void startAsyncButton_Click2(object sender, EventArgs e)

        {

            //if (lowmemorymode == true)
            //{
            //    this.dataGridView1.ColumnHeadersVisible = false;
            //    this.dataGridView2.ColumnHeadersVisible = false;
            //    this.dataGridView3.ColumnHeadersVisible = false;
            //}

            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button8.Enabled = false;
            // //this.label17.Location = new System.Drawing.Point(268, 112);
            label17.Text = "Not Connected";
            label17.TextAlign = ContentAlignment.TopRight;
            label17.ForeColor = System.Drawing.Color.Black;
            //contextMenuStrip1.Enabled = false;
            //toolStripMenuItem1.Enabled = false;
            //toolStripMenuItem9.Enabled = false;
            //toolStripMenuItem10.Enabled = false;
            //toolStripMenuItem11.Enabled = false;
            //toolStripMenuItem12.Enabled = false;
            //contextMenuStrip2.Enabled = false;
            //toolStripMenuItem2.Enabled = false;



            if (comboBox1.Items.Count > 0)
            {
                tablelimit = comboBox1.SelectedItem.ToString();
            }

            comboBox1.Enabled = false;
            checkBox1.Enabled = false;

            sqlcomm = "";

            if (dta != null)
            {
                dta.Clear();
            }

            if (busy == true)
            {
                workerbusy(sender, e);
                return;
            }

            if (busy != true)
            {
                try
                {

                    backgroundWorker2.RunWorkerAsync();
                    textBox12.Visible = true;
                    textBox12.Text = "Working...";
                    busy = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            {

               
                    if (dta is not null)
                    {
                        dta.Clear();
                    }

                    if (dta2 is not null)
                    {
                        dta2.Clear();
                    }

                    dta = null;
                    dta2 = null;


                if (radioButton6.Checked == true)
                {
                    searchtype = "Exact Match";
                }

                if (radioButton7.Checked == true)
                {
                    searchtype = "Partial Match";
                }

                valuesearchstring = textBox8.Text;

                BeginInvoke((MethodInvoker)delegate
                {
                    if (lowmemorymode == true)
                    {

                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        dataGridView3.DataSource = null;
                        dataGridView4.DataSource = null;
                        dataGridView5.DataSource = null;
                        dataGridView6.DataSource = null;
                        dataGridView7.DataSource = null;
                        dataGridView8.DataSource = null;

                    }

                    Text = "SQL Tools - WORKING...";
                });

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
                            try
                            {
                                if (checkBox1.Checked == false)
                                {

                                    if (radioButton6.Checked == true)
                                    {
                                        sqlcomm = (sql5b + textBox8.Text + sql6b);
                                    }

                                    if (radioButton7.Checked == true)
                                    {
                                        sqlcomm = (sql5 + textBox8.Text + sql6);
                                    }
                                }





                                if (checkBox1.Checked == true)
                                {

                                    if (radioButton6.Checked == true) //exact
                                    {
                                        sqlcomm = (sql5b + textBox8.Text + sql6c + tablelimit + sql6d);
                                    }

                                    if (radioButton7.Checked == true) //partial
                                    {
                                        sqlcomm = (sql5 + textBox8.Text + sql6e + tablelimit + sql6f);
                                    }
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
                                        //this.label17.Location = new System.Drawing.Point(288, 112);
                                        label17.ForeColor = System.Drawing.Color.DarkGreen;
                                        textBox12.Visible = true;
                                        textBox12.Text = "Working...";
                                    }
                                 );
                                }

                                adapter.SelectCommand = cmd1;
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);

                                int ind = ds.Columns.IndexOf("RowVersion");
                                if (ind != -1)
                                {
                                    ds.Columns.RemoveAt(ind);
                                }

                                int ind2 = ds.Columns.IndexOf("TimeStamp");
                                if (ind2 != -1)
                                {
                                    ds.Columns.RemoveAt(ind2);
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

                            catch (Exception ex)

                            {
                                if (worker.CancellationPending == true)
                                {
                                    return;
                                }

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
                    catch (Exception)
                    {
                        string msg = "Please enter valid connection details.";
                        MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
            return;
        }


        void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {


            button3.Enabled = false;

        }

        async void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            {
                BeginInvoke((MethodInvoker)delegate
                {
                    Text = "SQL Tools";
                });


                ctp = "ctp2";
                button3.Enabled = true;
                button3.Text = "Results to Clipboard";
                button2.Enabled = true;
                button1.Enabled = true;
                button4.Enabled = true;
                button8.Enabled = true;
                busy = false;

                
                checkBox1.Enabled = true;

                if (checkBox1.Checked == true)
                {
                    comboBox1.Enabled = true;
                }

                SqlConnection cmd = new SqlConnection();
                cmd.Close();
                if (dta != null && dta.Rows.Count > 0)
                {
                    dta = dta.Copy();
                    contextMenuStrip7.Enabled = true;

                    if (lowmemorymode == false)
                    {
                        dtm2 = dta.Copy();
                    }

                    if (lowmemorymode == false)
                    {
                        dataGridView2.DataSource = dtm2;

                    }

                    if (lowmemorymode == true)
                    {
                        dataGridView2.DataSource = dta;

                    }
                    dataGridView2.ColumnHeadersVisible = true;
                    textBox12.Visible = false;





                    if (dta.Rows.Count < 1)
                    {

                    }
                }

                if (dta is null || dta.Rows.Count == 0)
                {

                    dataGridView2.ColumnHeadersVisible = false;
                    button3.Enabled = false;
                    textBox12.Text = "No Results.";

                }

                if (textBox12.Text == "No Results.")
                {
                    dataGridView2.ColumnHeadersVisible = false;
                    button3.Enabled = false;
                    //    contextMenuStrip1.Enabled = false;
                    //    toolStripMenuItem1.Enabled = false;
                    //    toolStripMenuItem9.Enabled = false;
                    //    toolStripMenuItem10.Enabled = false;
                    //    toolStripMenuItem11.Enabled = false;
                    //    toolStripMenuItem12.Enabled = false;
                    //    contextMenuStrip2.Enabled = false;
                    //    toolStripMenuItem2.Enabled = false;
                }
            }

        }


        /// <summary>
        /// Tab 3
        /// </summary>

        async void startAsyncButton_Click3(object sender, EventArgs e)
        {

            if (lowmemorymode == true)
            {
                //this.dataGridView1.ColumnHeadersVisible = false;
                //this.dataGridView2.ColumnHeadersVisible = false;
                //this.dataGridView3.ColumnHeadersVisible = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                button8.Enabled = false;
                //textBox11.Text = "No Results.";
                //label14.Visible = false;
                button2.Enabled = false;
            }

            //this.label17.Location = new System.Drawing.Point(268, 112);
            label17.Text = "Not Connected";
            label17.TextAlign = ContentAlignment.TopRight;
            label17.ForeColor = System.Drawing.Color.Black;
            //contextMenuStrip1.Enabled = false;
            //toolStripMenuItem1.Enabled = false;
            //toolStripMenuItem9.Enabled = false;
            //toolStripMenuItem10.Enabled = false;
            //toolStripMenuItem11.Enabled = false;
            //toolStripMenuItem12.Enabled = false;
            //contextMenuStrip2.Enabled = false;
            //toolStripMenuItem2.Enabled = false;
            sqlcomm = "";




            //if ((initialsearch is null || initialsearch == "") || (textBox6.Text != "[No Search Term Entered]"))
            // {
            if (searchedfromgrid == false)
            {

                if ((textBox6.Text == "" || textBox6.Text == null))
                {
                    textBox6.Text = "[No Search Term Entered]";
                }

                initialsearch = textBox6.Text;
            }
            //BeginInvoke((MethodInvoker)delegate
            //{
            //    textBox6.Text = "";
            //});

            //}


            //MessageBox.Show(lastlineused);

            if (dta != null && dataGridView3.Rows.Count > 0)
            {

                int r = dataGridView3.CurrentCell.RowIndex;
                int c = dataGridView3.CurrentCell.ColumnIndex;


                if (builtpath is not null)
                {

                    char[] lastline = builtpath.ToString().ToCharArray();
                    lastline.Reverse();
                    string lastlineconverted = new string(lastline);
                    int spaceindex = lastlineconverted.LastIndexOf(Environment.NewLine);
                    int entirelength = builtpath.Length;
                    if (spaceindex > -1)
                    {
                        lastlineused = lastlineconverted.Substring(spaceindex, (entirelength - spaceindex));
                        
                    }



                    if (dataGridView3.SelectedRows.Count > 0)
                    {
                        int rowind = dataGridView3.SelectedRows[0].Index;
                        if (builtjoinpath == null)
                        {
                            builtjoinpath = "--START OF SQL STATEMENT--" + Environment.NewLine + "select * from [" + dataGridView3.Rows[rowind].Cells[0].Value + "] [" + builtjoinsequence + "]";
                            builtjoinsequence = builtjoinsequence + 1;
                        }
                    }

                    if (dataGridView3.SelectedRows.Count == 0)
                    {
                        dataGridView3.Rows[0].Selected = true;
                        int rowind = dataGridView3.SelectedRows[0].Index;
                        if (builtjoinpath == null)
                        {
                            builtjoinpath = "--START OF SQL STATEMENT--" + Environment.NewLine + "select * from [" + dataGridView3.Rows[rowind].Cells[0].Value + "] [" + builtjoinsequence + "]";
                            builtjoinsequence = builtjoinsequence + 1;
                        }
                    }


                }

        


                if (builtpath == null)
                {

                    if (dataGridView3.SelectedRows.Count > 0)
                    {
                        int rowind = dataGridView3.SelectedRows[0].Index;
                        if (builtjoinpath == null)
                        {
                            builtjoinpath = "--START OF SQL STATEMENT--" + Environment.NewLine + "select * from [" + dataGridView3.Rows[rowind].Cells[0].Value + "] [" + builtjoinsequence + "]";
                            builtjoinsequence = builtjoinsequence + 1;
                        }
                    }

                    if (dataGridView3.SelectedRows.Count == 0)
                    {
                        dataGridView3.Rows[0].Selected = true;
                        int rowind = dataGridView3.SelectedRows[0].Index;
                        if (builtjoinpath == null)
                        {
                            builtjoinpath = "--START OF SQL STATEMENT--" + Environment.NewLine + "select * from [" + dataGridView3.Rows[rowind].Cells[0].Value + "] [" + builtjoinsequence + "]";
                            builtjoinsequence = builtjoinsequence + 1;
                        }
                    }


                    builtpath = ("--START OF SEARCH--");

                    if (textBox6.Text == "" && builtpath == null)
                    {
                        builtpath += Environment.NewLine + "[No Search Term Entered]" + " < [Last Search Term]";
                    }

                    if (textBox6.Text != "" && builtpath == null)
                    {
                        builtpath += Environment.NewLine + "'" + initialsearch + "'" + " < [Last Search Term]";
                    }

                }


                if ((builtpath == null && dataGridView3 != null) || Clipboard.GetData == null)
                {
                    builtpath = ("--START OF SEARCH--" + Environment.NewLine + "'" + initialsearch + "'" + " < [Last Search Term]");
                }

                if (builtpath != null && dataGridView3.SelectedCells.Count != 0 && builtpath != "--START OF SEARCH--" + Environment.NewLine + "'" + textBox6.Text + "'" + "< [Last Search Term]" + Environment.NewLine + "Result: " + "[" + dataGridView3.Rows[r].Cells[0].Value + " > " + dataGridView3.Rows[r].Cells[2].Value + "]" + " (" + dataGridView3.Rows[r].Cells[1].Value + " > " + dataGridView3.Rows[r].Cells[3].Value + ")")


                {

                    char[] lastline = builtjoinpath.ToString().ToCharArray();
                    lastline.Reverse();
                    string lastlineconverted = new string(lastline);
                    int spaceindex = lastlineconverted.LastIndexOf(Environment.NewLine);
                    int entirelength = builtjoinpath.Length;
                    if (spaceindex > -1)
                    {
                        lastlineused = lastlineconverted.Substring(spaceindex, (entirelength - spaceindex));

                    }

                    if (builtjoinpath.Contains("left join [" + dataGridView3.Rows[r].Cells[2].Value + "] [" + builtjoinsequence + "] on [" + builtjoinsequence + "].[" + dataGridView3.Rows[r].Cells[3].Value + "]") == false)
                        {

                        builtjoinpath += Environment.NewLine + "left join [" + dataGridView3.Rows[r].Cells[2].Value + "] [" + builtjoinsequence + "] on [" + builtjoinsequence + "].[" + dataGridView3.Rows[r].Cells[3].Value + "]";
                        builtjoinpath += " = [" + (builtjoinsequence - 1) + "].[" + dataGridView3.Rows[r].Cells[1].Value + "]";
                        builtjoinsequence = builtjoinsequence + 1;
                    }
                  

              


                        if (dataGridView3.SelectedRows.Count > 0)
                        {
                            int rowind = dataGridView3.SelectedRows[0].Index;
                            if (builtjoinpath == null)
                            {
                                builtjoinpath = "--START OF SQL STATEMENT--" + Environment.NewLine + "select * from [" + dataGridView3.Rows[rowind].Cells[0].Value + "] [" + builtjoinsequence + "]";
                                builtjoinsequence = builtjoinsequence + 1;
                            }
                        }

                    


                    if (dataGridView3.Rows.Count > 0 && builtpath == "--START OF SEARCH--")
                    {
                        builtpath += Environment.NewLine + "'" + initialsearch + "'" + " < [Last Search Term]";
                    }

                    if (textBox6.Text != "" && lastlineused != (Environment.NewLine + "Result: " + "[" + dataGridView3.Rows[r].Cells[0].Value + " > " + dataGridView3.Rows[r].Cells[2].Value + "]" + " (" + dataGridView3.Rows[r].Cells[1].Value + " > " + dataGridView3.Rows[r].Cells[3].Value + ")"))
                    {

                        builtpath +=

                        //dataGridView3.SelectedRows[0].Cells.ToString();

                        Environment.NewLine + "Result: " + "[" + dataGridView3.Rows[r].Cells[0].Value + " > " + dataGridView3.Rows[r].Cells[2].Value + "]" + " (" + dataGridView3.Rows[r].Cells[1].Value + " > " + dataGridView3.Rows[r].Cells[3].Value + ")";
                    }
                }



                if (builtpath == (Environment.NewLine).ToString())
                {
                    Clipboard.Clear();
                    builtpath = "'" + textBox6.Text + "'";

                }



                if (dta.Rows.Count < 1)
                {
                    relationshipsearchsuccess = false;
                    //if (builtpath is null)
                    //{
                    //    actualclick = false;
                    //}

                }


                dta.Clear();
            }


            if (busy == true)
            {
                workerbusy(sender, e);
                return;
            }

            if (busy != true)
            {
                try
                {

                    backgroundWorker3.RunWorkerAsync();
                    textBox13.Visible = true;
                    textBox13.Text = "Working...";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }



        }
        void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {


            {
                {

                  
                        if (dta is not null)
                        {
                            dta.Clear();
                        }

                        if (dta2 is not null)
                        {
                            dta2.Clear();
                        }

                        dta = null;
                        dta2 = null;
                    


                    BeginInvoke((MethodInvoker)delegate
                    {

                        if (lowmemorymode == true)
                        {
                            dataGridView1.DataSource = null;
                            dataGridView2.DataSource = null;
                            dataGridView3.DataSource = null;
                            dataGridView4.DataSource = null;
                            dataGridView5.DataSource = null;
                            dataGridView6.DataSource = null;
                            dataGridView7.DataSource = null;
                            dataGridView8.DataSource = null;
                        }
                        Text = "SQL Tools - WORKING...";
                        button4.Enabled = false;
                    });

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
                                        //this.label17.Location = new System.Drawing.Point(288, 112);
                                        label17.ForeColor = System.Drawing.Color.DarkGreen;
                                    }
                                 );


                                    if (cmd == null)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connection Failed";
                                            //this.label17.Location = new System.Drawing.Point(255, 112);
                                            label17.ForeColor = System.Drawing.Color.DarkRed;
                                        }
                                     );

                                    }

                                }
                                adapter.SelectCommand = cmd1;
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);

                                int ind = ds.Columns.IndexOf("RowVersion");
                                if (ind != -1)
                                {
                                    ds.Columns.RemoveAt(ind);
                                }

                                int ind2 = ds.Columns.IndexOf("TimeStamp");
                                if (ind2 != -1)
                                {
                                    ds.Columns.RemoveAt(ind2);
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

                            catch (Exception ex)

                            {

                                if (worker.CancellationPending == true)
                                {
                                    return;
                                }

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
                        catch (Exception)
                        {
                            string msg = "Please enter valid connection details.";
                            MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                }
                return;
            }


        }
        void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            {
                BeginInvoke((MethodInvoker)delegate
                {
                    Text = "SQL Tools";
                });


                ctp = "ctp3";
                button3.Enabled = true;
                button3.Text = "Results to Clipboard";
                button2.Enabled = true;
                button1.Enabled = true;
                button4.Enabled = true;
                button8.Enabled = true;
                SqlConnection cmd = new SqlConnection();
                cmd.Close();




                if (dta != null)
                {
                    textBox13.Visible = false;
                    contextMenuStrip2.Enabled = true;
                    toolStripMenuItem2.Enabled = true;
                    toolStripMenuItem13.Enabled = true;
                    toolStripMenuItem14.Enabled = true;
                    toolStripMenuItem15.Enabled = true;
                    toolStripMenuItem16.Enabled = true;
                    dta = dta.Copy();

                    if (lowmemorymode == false)
                    {
                        dtm3 = dta.Copy();
                    }

                    if (lowmemorymode == false)
                    {
                        dataGridView3.DataSource = dtm3;
                    }

                    if (lowmemorymode == true)
                    {
                        dataGridView3.DataSource = dta;

                    }
                    dataGridView3.ColumnHeadersVisible = true;
                    relationshipsearchsuccess = true;
                    button7.Enabled = true;
                    button7.Text = "Results to Clipboard";
                    checkBox2.Enabled = true;
                    checkBox2_CheckedChanged(sender, e);


                }



                if (dta is null || dta.Rows.Count == 0)
                {
                    dataGridView3.ColumnHeadersVisible = false;
                    button3.Enabled = false;
                    relationshipsearchsuccess = false;
                    textBox13.Visible = true;
                    textBox13.Text = "No Results.";
                    

                    if (builtpath == "" || builtpath == null)
                    {
                        checkBox2.Enabled = false;
                        checkBox2.BackColor = Color.Transparent;
                        builtjoinsequence = 1;
                    }
                }

                if (textBox13.Text == "No Results.")
                {
                    dataGridView3.ColumnHeadersVisible = false;
                    button3.Enabled = false;
                    //contextMenuStrip1.Enabled = false;
                    //toolStripMenuItem1.Enabled = false;
                    //toolStripMenuItem9.Enabled = false;
                    //toolStripMenuItem10.Enabled = false;
                    //toolStripMenuItem11.Enabled = false;
                    //toolStripMenuItem12.Enabled = false;
                    //contextMenuStrip2.Enabled = false;
                    //toolStripMenuItem2.Enabled = false;



                }
                searchedfromgrid = false;

            }
            busy = false;

            dataGridView3.ClearSelection();

            if (textBox6.Text == "[No Search Term Entered]" && initialsearch is null)
            {
                textBox6.Text = "";
            }

            textBox6_Click(sender, e);

        }



        /// <summary>
        /// Menu functions
        /// </summary>



        public void clickmenu(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {


                int index = new int();

                if (dataGridView1.Columns[0].Name == "Table Name")
                {
                    index = 0;
                }

                if (dataGridView1.Columns[1].Name == "Table Name")
                {
                    index = 1;
                }

                object? holding = dataGridView1.SelectedCells[index].Value;
                if (holding != null)
                {
                    textBox6.Text = holding.ToString();
                    tabControl1.SelectedIndex = 2;
                    builtjoinpath = null;
                    builtpath = null;
                    startAsyncButton_Click3(sender, e);
                    actualclick = true;
                }
            }

            else
            {
                return;
            }
        }

        public void clickmenu2(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0 || dataGridView3.RowCount > 0)
            {


                searchedfromgrid = true;
                int rowindex = dataGridView3.CurrentCell.RowIndex;
                int colindex = dataGridView3.CurrentCell.ColumnIndex;

                radioButton6.Checked = true;

                if (dataGridView3.Columns[0].Name == "Referencing Table")
                {
                }

                if (dataGridView3.Columns[0].Name == "Referenced Table")
                {
                }

                object? holding = dataGridView3.Rows[rowindex].Cells[colindex].Value;
                if (holding != null)
                {
                    //builtpath += textBox6.Text;

                    if (colindex == 0 || colindex == 2)
                    {
                        textBox6.Text = holding.ToString();
                        tabControl1.SelectedIndex = 2;
                        startAsyncButton_Click3(sender, e);
                        actualclick = false;
                    }

                    if (colindex == 1 || colindex == 3)
                    {
                        object? holding2 = dataGridView3.Rows[rowindex].Cells[colindex - 1].Value;
                        textBox6.Text = holding2.ToString();
                        tabControl1.SelectedIndex = 2;
                        startAsyncButton_Click3(sender, e);
                        actualclick = false;
                    }



                }
            }

            else
            {
                return;
            }
        }



        public void clickmenu3(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {


                int index = new int();

                if (dataGridView1.Columns[0].Name == "Table Name")
                {
                    index = 0;
                }

                if (dataGridView1.Columns[1].Name == "Table Name")
                {
                    index = 1;
                }

                object? holding = dataGridView1.SelectedCells[index].Value;
                if (holding != null)
                {

                    textBox5.Text = holding.ToString();
                    tabControl1.SelectedIndex = 0;
                    radioButton3.Checked = true;
                    radioButton6.Checked = true;
                    Set_Search_Table(sender, e);
                    passtobgworker(sender, e);
                    actualclick = true;
                }
            }

            else
            {
                return;
            }
        }

        public void clickmenu4(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {


                int index = new int();

                if (dataGridView1.Columns[0].Name == "Column Name")
                {
                    index = 0;
                }

                if (dataGridView1.Columns[1].Name == "Column Name")
                {
                    index = 1;
                }

                object? holding = dataGridView1.SelectedCells[index].Value;
                if (holding != null)
                {

                    textBox7.Text = holding.ToString();
                    tabControl1.SelectedIndex = 0;
                    radioButton4.Checked = true;
                    radioButton6.Checked = true;
                    Set_Search_Column(sender, e);
                    passtobgworker(sender, e);
                    actualclick = true;
                }
            }

            else
            {
                return;
            }
        }



        /// <summary>
        /// Copy functions
        /// </summary>


        public void builtpathcopy(object sender, EventArgs e)
        {



            if (builtpath != null)
            {
                if (initialsearch == "")
                {
                    initialsearch = "[No Search Term Entered]";
                }

                if (builtpath.Contains("< [Last Search Term]") == false)// && dataGridView3.Rows.Count == 0)
                {
                    builtpath += Environment.NewLine + "'" + initialsearch + "'" + " < [Last Search Term]";
                }
                builtpath += Environment.NewLine + "--END OF SEARCH--";

                Clipboard.SetText(builtpath);

                if (builtjoinpath != null)
                {
                    builtjoinpath += Environment.NewLine + "--END OF SQL STATEMENT--";
                }
                if (checkBox2.Checked == true)
                {
                    builtpath += Environment.NewLine + Environment.NewLine + builtjoinpath;
                }


            }

            if (builtpath == null)
            {
                if (initialsearch == "" && searchedfromgrid == false)
                {
                    builtpath = "--START OF SEARCH--" + Environment.NewLine + "[No Search Term Entered]" + " < [Last Search Term]" + Environment.NewLine + "--END OF SEARCH--";
                }
                if (((textBox6.Text != "" || initialsearch != "") || (textBox6.Text != null || initialsearch != null)) && searchedfromgrid == false)
                {
                    builtpath = "--START OF SEARCH--" + Environment.NewLine + "'" + initialsearch + "'" + " < [Last Search Term]" + Environment.NewLine + "--END OF SEARCH--";
                }



                //button7.Enabled = false;
                //checkBox2.Enabled = false;
                //checkBox2.BackColor = Color.Transparent;
                //button6.Enabled = true;
                //button7.Text = "Copied to Clipboard";
                //builtjoinpath = null;
                //builtjoinsequence = 1;
            }




            Clipboard.SetText(builtpath);
            button7.Enabled = false;
            checkBox2.Enabled = false;
            checkBox2.BackColor = Color.Transparent;
            button6.Enabled = true;
            button7.Text = "Copied to Clipboard";
            builtpath = null;
            builtjoinpath = null;
            builtjoinsequence = 1;



        }






        void copyresults(object sender, EventArgs e)

        {


            if (dta is not null && tabControl1.SelectedTab == tabPage4)

            {
                if (string.Equals(ctp, "ctp4"))
                {

                    string? newline = System.Environment.NewLine;
                    StringBuilder? clipboard_string = new StringBuilder();




                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i == (row.Cells.Count - 1))
                            {
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + newline);
                            }
                            else
                            {
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + ",");
                            }
                        }
                    }
                    button3.Enabled = false;
                    button3.Text = "Results Copied";


                    if (clipboard_string != null)
                    {
                        Clipboard.SetText(clipboard_string.ToString());
                    }

                    if (clipboard_string == null)
                    {
                        return;
                    }



                    if (dta == null)
                    {
                        return;
                    }

                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }
            }




            if (dta is not null && tabControl1.SelectedTab == tabPage1)

            {
                if (string.Equals(ctp, "ctp1"))
                {

                    string? newline = System.Environment.NewLine;
                    StringBuilder? clipboard_string = new StringBuilder();

                    dataGridView1.Columns[3].Visible = false;



                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        for (int i = 0; i < row.Cells.Count - 1; i++)
                        {


                            if (i == (row.Cells.Count - 2))
                            {
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + newline);
                            }
                            else
                            {
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + ",");
                            }
                        }
                    }


                    button3.Enabled = false;
                    button3.Text = "Results Copied";


                    if (clipboard_string != null)
                    {
                        Clipboard.SetText(clipboard_string.ToString());
                    }

                    if (clipboard_string == null)
                    {
                        return;
                    }



                    if (dta == null)
                    {
                        return;
                    }

                }

                if (!(string.Equals(ctp, "ctp1")))
                {
                    return;
                }
            }




            if (dta is not null && tabControl1.SelectedTab == tabPage2)

            {
                if (string.Equals(ctp, "ctp2"))


                {
                    string? newline = System.Environment.NewLine;
                    StringBuilder? clipboard_string = new StringBuilder();

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i == (row.Cells.Count - 1))
                            {
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + newline);
                            }
                            else
                            {
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + ",");
                            }
                        }
                    }

                    button3.Enabled = false;
                    button3.Text = "Results Copied";

                    if (clipboard_string == null)
                    {
                        return;
                    }
                    if (clipboard_string != null)
                    {
                        Clipboard.SetText(clipboard_string.ToString());
                    }
                }

                if (dta == null)
                {
                    return;
                }

                if (!(string.Equals(ctp, "ctp2")))
                {
                    return;
                }
            }

            if (dta is not null && tabControl1.SelectedTab == tabPage3)

            {
                if (string.Equals(ctp, "ctp3"))

                {

                    string? newline = System.Environment.NewLine;
                    StringBuilder? clipboard_string = new StringBuilder();

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (i == (row.Cells.Count - 1))
                            {
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + newline);
                            }
                            else
                            {
                                clipboard_string.Append("[" + row.Cells[i].Value + "]" + ",");
                            }
                        }
                    }

                    button3.Enabled = false;
                    button3.Text = "Results Copied";

                    if (clipboard_string == null)
                    {
                        return;
                    }
                    if (clipboard_string != null)
                    {
                        Clipboard.SetText(clipboard_string.ToString());
                    }
                }

                if (dta == null)
                {
                    return;
                }


                if (!(string.Equals(ctp, "ctp3")))
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
            {
                Set_ReadOnly_For_SQL(sender, e);
            }
            else if
                (radioButton2.Checked == true)
            {
                Set_Editable_For_Windows(sender, e);
            }
        }


        void Search_Type(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                Set_Search_Table(sender, e);
            }
            else if
                (radioButton4.Checked == true)
            {
                Set_Search_Column(sender, e);
            }
            else if
                (radioButton5.Checked == true)
            {
                Set_Search_Both(sender, e);
            }
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
            builtjoinpath = null;
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

            string findText = laswor;

            int index = 0;
            if (laswor.Length > 0)
            {
                int len = laswor.Length;
            }

            int positionOfcarett = caretposition;


            index = richTextBox1.Find(findText, index, RichTextBoxFinds.WholeWord);
            if (index > -1)
            {
                colouring = true;
                richTextBox1.Select(positionOfcarett, -findText.Length);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.DeselectAll();
                richTextBox1.SelectionLength = 0;
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.SelectionStart = positionOfcarett;
                index++;
                colouring = false;

            }





        }



        private void dotextstuffblack(object sender, EventArgs e)
        {

            string findText = laswor;
            int index = 0;
            int len = laswor.Length;

            int lineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);

            int positionOfcarett = richTextBox1.SelectionStart;


            lineIndex = richTextBox1.GetFirstCharIndexOfCurrentLine();

            index = richTextBox1.Find(findText, index, RichTextBoxFinds.WholeWord);
            if (index > -1)
            {

                richTextBox1.Select(positionOfcarett, -findText.Length);
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionLength = 0;
                richTextBox1.ForeColor = Color.Black;
                //richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionStart =
                    positionOfcarett;

                index++;


            }


        }



        private void dotextstuffred(object sender, EventArgs e)
        {
            int lastchar;
            int nextchar;


            lastchar = richTextBox1.SelectionStart - 1;

            nextchar = lastchar + 1;

            decimal d = (decimal)ct1 / 2;

            string d1 = d.ToString();

            bool isint = StringReverse.IsInt(d1);

            inedit = isint;

            if (richTextBox1.Text.Length > 1 && richTextBox1.Text.Length >= lastchar && isint == false)
            {

                int currentcaretposition = richTextBox1.SelectionStart;

                string? chk = richTextBox1.Text.Substring(lastchar, 1);
                string stringoriginal = richTextBox1.Text.Substring(0, lastchar + 1);
                char[] stringarray = stringoriginal.ToString().ToCharArray();
                Array.Reverse(stringarray);
                string stringreverse = new string(stringarray);
                int stringreverselen = stringreverse.Length;
                richTextBox1.SelectionColor = Color.Black;
                if (richTextBox1.Text.Length == currentcaretposition)
                {
                    richTextBox1.SelectionStart = nextchar;

                }

            }

            if (richTextBox1.Text.Length > 1 && richTextBox1.Text.Length >= lastchar && isint == true)
            {
                if (lastchar > -1)
                {
                    string? chk = richTextBox1.Text.Substring(lastchar, 0);
                }
                richTextBox1.Select(lastchar, 0);
                richTextBox1.SelectionStart = nextchar;
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.ScrollToCaret();
                textbacktoblack(sender, e);
            }


        }



        private void dotextstuffred2(object sender, EventArgs e)
        {
            int lastchar;
            int nextchar;


            lastchar = richTextBox2.SelectionStart - 1;

            nextchar = lastchar + 1;

            decimal d = (decimal)ct2 / 2;

            string d1 = d.ToString();

            bool isint = StringReverse.IsInt(d1);

            inedit2 = isint;

            if (richTextBox2.Text.Length > 1 && richTextBox2.Text.Length >= lastchar && isint == false)
            {

                int currentcaretposition = richTextBox2.SelectionStart;

                string? chk = richTextBox2.Text.Substring(lastchar, 1);
                string stringoriginal = richTextBox2.Text.Substring(0, lastchar + 1);
                char[] stringarray = stringoriginal.ToString().ToCharArray();
                Array.Reverse(stringarray);
                string stringreverse = new string(stringarray);
                int stringreverselen = stringreverse.Length;
                richTextBox2.SelectionColor = Color.Black;
                if (richTextBox2.Text.Length == currentcaretposition)
                {
                    richTextBox2.SelectionStart = nextchar;

                }

            }

            if (richTextBox2.Text.Length > 1 && richTextBox2.Text.Length >= lastchar && isint == true)
            {
                if (lastchar > -1)
                {
                    string? chk = richTextBox2.Text.Substring(lastchar, 0);
                }
                richTextBox2.Select(lastchar, 0);
                richTextBox2.SelectionStart = nextchar;
                richTextBox2.SelectionColor = Color.Black;
                richTextBox2.ScrollToCaret();
                textbacktoblack2(sender, e);
            }


        }



        private void dotextstuffred3(object sender, EventArgs e)
        {
            int lastchar;
            int nextchar;


            lastchar = richTextBox4.SelectionStart - 1;

            nextchar = lastchar + 1;

            decimal d = (decimal)ct3 / 2;

            string d1 = d.ToString();

            bool isint = StringReverse.IsInt(d1);

            inedit3 = isint;

            if (richTextBox4.Text.Length > 1 && richTextBox4.Text.Length >= lastchar && isint == false)
            {

                int currentcaretposition = richTextBox4.SelectionStart;

                string? chk = richTextBox4.Text.Substring(lastchar, 1);
                string stringoriginal = richTextBox4.Text.Substring(0, lastchar + 1);
                char[] stringarray = stringoriginal.ToString().ToCharArray();
                Array.Reverse(stringarray);
                string stringreverse = new string(stringarray);
                int stringreverselen = stringreverse.Length;
                richTextBox4.SelectionColor = Color.Black;
                if (richTextBox4.Text.Length == currentcaretposition)
                {
                    richTextBox4.SelectionStart = nextchar;

                }

            }

            if (richTextBox4.Text.Length > 1 && richTextBox4.Text.Length >= lastchar && isint == true)
            {
                if (lastchar > -1)
                {
                    string? chk = richTextBox4.Text.Substring(lastchar, 0);
                }
                richTextBox4.Select(lastchar, 0);
                richTextBox4.SelectionStart = nextchar;
                richTextBox4.SelectionColor = Color.Black;
                richTextBox4.ScrollToCaret();
                textbacktoblack3(sender, e);
            }


        }


        private void textbacktoblack(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Black;
        }

        private void textbacktoblack2(object sender, EventArgs e)
        {
            richTextBox2.SelectionColor = Color.Black;
        }

        private void textbacktoblack3(object sender, EventArgs e)
        {
            richTextBox4.SelectionColor = Color.Black;
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void richTextBox1_KeyDownTest(object sender, KeyEventArgs e)
        {

        }


        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                //checkBox7.Checked = false;

            }



            if (e.KeyCode == Keys.Back)
            {

                if (richTextBox1.Text.Length > 0)
                {
                    string txt;

                    if ((richTextBox1.SelectionStart - 1) > 0)
                    {
                        txt = richTextBox1.Text.Substring(richTextBox1.SelectionStart - 1, 1);
                        if (txt == "'")
                        {
                            ct1 = ct1 - 1;
                        }
                    }
                }


            }

            if
             (autocompletebusy == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }


            if (e.KeyCode == Keys.Oem3)
            {
                ct1 = ct1 + 1;
                dotextstuffred(sender, e);
            }


            if (e.KeyCode == Keys.Decimal && checkBox7.Checked == true)
            {

                if (autocomplete == false)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

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

                workerbusy(sender, e);
                return;

            }

            if (e.KeyCode == Keys.F5 && busy == false)
            {

                dataGridView4.Refresh();
                richTextBox1.Enabled = false;
                richTextBox1_KeyDowns(sender, e);


            }

            string[]? prochar = new string[45];
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
                    //richTextBox1.ScrollToCaret();
                }


                if (

                   //e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.F5) &&
                   richTextBox1.TextLength > 1 &&
                   f5pressed == false && inedit == true
                   )
                {

                    //InputSimulator ks = new InputSimulator();

                    //int len = richTextBox1.TextLength;

                    string[]? procwords = new string[300];
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



            if (dta is not null)
            {
                if (dta.Rows.Count != 0)
                {

                    dta.Clear();
                    datacleared = true;
                }
            }
            if (dta2 is not null)
            {
                if (dta2.Rows.Count != 0)
                {
                    dta2.Clear();
                    datacleared = true;
                }
            }


            dataGridView4.Visible = true;

            if (lowmemorymode == true)
            {

                dataGridView1.ColumnHeadersVisible = false;
                dataGridView2.ColumnHeadersVisible = false;
                dataGridView3.ColumnHeadersVisible = false;
                dataGridView4.ColumnHeadersVisible = false;
                dataGridView5.ColumnHeadersVisible = false;
                dataGridView6.ColumnHeadersVisible = false;
            }
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            button8.Enabled = false;
            //label18.Visible = true;

            //textBox11.Text = "No Results.";
            //label14.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            //this.label17.Location = new System.Drawing.Point(268, 112);
            label17.Text = "Not Connected";
            label17.TextAlign = ContentAlignment.TopRight;
            label17.ForeColor = System.Drawing.Color.Black;
            //contextMenuStrip1.Enabled = false;
            //toolStripMenuItem1.Enabled = false;
            //toolStripMenuItem9.Enabled = false;
            //toolStripMenuItem10.Enabled = false;
            //toolStripMenuItem11.Enabled = false;
            //toolStripMenuItem12.Enabled = false;
            //contextMenuStrip2.Enabled = false;
            //toolStripMenuItem2.Enabled = false;
            sqlcomm = "";

            quer = richTextBox1.Text;


            if (busy == true)
            {
                workerbusy(sender, e);
                return;
            }

            if (busy != true)
            {
                try
                {
                    backgroundWorker4.RunWorkerAsync();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }







        }


        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {

          
                if (dta is not null)
                {
                    dta.Clear();
                }

                if (dta2 is not null)
                {
                    dta2.Clear();
                }

                dta = null;
                dta2 = null;
            


            BeginInvoke((MethodInvoker)delegate
            {

                if (lowmemorymode == true)
                {
                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = null;
                    dataGridView3.DataSource = null;
                    dataGridView4.DataSource = null;
                    dataGridView5.DataSource = null;
                    dataGridView6.DataSource = null;
                    dataGridView7.DataSource = null;
                    dataGridView8.DataSource = null;
                }
                Text = "SQL Tools - WORKING...";
            });

            busy = true;
            errormessage = "";
            changederror = "";


            BeginInvoke((MethodInvoker)delegate
            {
                if (lowmemorymode == true)
                {
                    dataGridView4.DataSource = null;
                }
                groupBox8.Text = "Results";
                textBox14.Text = "Working...";

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
                            try
                            {

                                {


                                    quer = Regex.Replace(quer, @"\r\n?|\n", Environment.NewLine);

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
                                            //this.label17.Location = new System.Drawing.Point(288, 112);
                                            label17.ForeColor = System.Drawing.Color.DarkGreen;
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

                                    int ind = ds.Columns.IndexOf("RowVersion");
                                    if (ind != -1)
                                    {
                                        ds.Columns.RemoveAt(ind);
                                    }

                                    int ind2 = ds.Columns.IndexOf("TimeStamp");
                                    if (ind2 != -1)
                                    {
                                        ds.Columns.RemoveAt(ind2);
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
                                string? msg = ex.Message;

                                if (worker.CancellationPending == true)
                                {
                                    return;
                                }

                                if (ex.Message != null)
                                {


                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        //MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                        dataGridView4.DataSource = null;
                                        dataGridView4.Rows.Clear();
                                        dataGridView4.Visible = false;
                                        //errortextbox.Visible = true;
                                        errormessage = Environment.NewLine + msg;
                                        // groupBox8.Text = "Error";


                                    });
                                }
                            }
                            finally
                            {
                                cmd.Close();
                            }

                        }
                    }
                    catch (Exception)
                    {
                        string msg = "Please enter valid connection details.";
                        //MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);

                        BeginInvoke((MethodInvoker)delegate
                        {
                            dataGridView4.Rows.Clear();
                            errormessage = msg;
                            //groupBox8.Text = "Error";
                        });
                    }
                }
            }
            return;
        }


        public void HideTabeHaders(object sender, EventArgs e)
        {

            currenttab = tabControl1.SelectedIndex;

            if (currenttab == 4)
            {
                groupBox6.Enabled = false;
            }

            if (currenttab != 4)
            {
                groupBox6.Enabled = true;
            }

            if (dataGridView1.DataSource is null)
            {

                if (lowmemorymode == true)

                {
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.AllowUserToAddRows = false;

                    textBox11.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    textBox14.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox16.Visible = true;

                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";

                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox16.Text = "";
                    textBox15.Text = "";
                    richTextBox1.Text = "";
                    richTextBox2.Text = "";
                    richTextBox4.Text = "";

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox2.BackColor = Color.Transparent;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    button3.Text = "Results to Clipboard";
                    button7.Text = "Results to Clipboard";
                    button6.Text = "Clear Clipboard";
                    button9.Text = "Results to Clipboard";
                    button10.Text = "Clear Clipboard";

                    groupBox5.Text = "Results";
                    groupBox4.Text = "Results";
                    groupBox3.Text = "Results";
                    groupBox10.Text = "Results";
                    groupBox8.Text = "Results";
                    groupBox11.Text = "Results";
                    groupBox12.Text = "Results";

                }

            }

            if (dataGridView2.DataSource is null)
            {
                if (lowmemorymode == true)
                {

                    dataGridView2.ColumnHeadersVisible = false;
                    dataGridView2.ColumnHeadersVisible = false;
                    dataGridView2.AllowUserToAddRows = false;
                    textBox11.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    textBox14.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox16.Visible = true;

                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";

                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox16.Text = "";

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox2.BackColor = Color.Transparent;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    button3.Text = "Results to Clipboard";
                    button7.Text = "Results to Clipboard";
                    button6.Text = "Clear Clipboard";
                    button9.Text = "Results to Clipboard";
                    button10.Text = "Clear Clipboard";
                }

            }



            if (dataGridView4.DataSource is null)
            {
                if (lowmemorymode == true)
                {
                    dataGridView4.ColumnHeadersVisible = false;
                    dataGridView4.ColumnHeadersVisible = false;
                    dataGridView4.AllowUserToAddRows = false;
                    textBox11.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    textBox14.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox16.Visible = true;

                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";

                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox16.Text = "";

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox2.BackColor = Color.Transparent;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    button3.Text = "Results to Clipboard";
                    button7.Text = "Results to Clipboard";
                    button6.Text = "Clear Clipboard";
                    button9.Text = "Results to Clipboard";
                    button10.Text = "Clear Clipboard";
                }
            }



            if (dataGridView6.DataSource is null)
            {
                if (lowmemorymode == true)
                {
                    dataGridView6.ColumnHeadersVisible = false;
                    dataGridView6.ColumnHeadersVisible = false;
                    dataGridView6.ReadOnly = true;
                    dataGridView6.AllowUserToAddRows = false;
                    textBox11.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    textBox14.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox16.Visible = true;

                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";

                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox16.Text = "";

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox2.BackColor = Color.Transparent;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    button3.Text = "Results to Clipboard";
                    button7.Text = "Results to Clipboard";
                    button6.Text = "Clear Clipboard";
                    button9.Text = "Results to Clipboard";
                    button10.Text = "Clear Clipboard";
                }

            }

            if (dataGridView7.DataSource is null)
            {
                if (lowmemorymode == true)
                {
                    dataGridView7.ColumnHeadersVisible = false;
                    dataGridView7.ColumnHeadersVisible = false;
                    dataGridView7.ReadOnly = true;
                    dataGridView7.AllowUserToAddRows = false;
                    textBox11.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    textBox14.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox16.Visible = true;

                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";

                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox16.Text = "";

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox2.BackColor = Color.Transparent;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    button3.Text = "Results to Clipboard";
                    button7.Text = "Results to Clipboard";
                    button6.Text = "Clear Clipboard";
                    button9.Text = "Results to Clipboard";
                    button10.Text = "Clear Clipboard";
                }

            }

            if (dataGridView8.DataSource is null)
            {
                if (lowmemorymode == true)
                {
                    dataGridView8.ColumnHeadersVisible = false;
                    dataGridView8.ColumnHeadersVisible = false;
                    dataGridView8.ReadOnly = true;
                    dataGridView8.AllowUserToAddRows = false;
                    textBox11.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    textBox14.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox16.Visible = true;

                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";

                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox16.Text = "";

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox2.BackColor = Color.Transparent;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    button3.Text = "Results to Clipboard";
                    button7.Text = "Results to Clipboard";
                    button6.Text = "Clear Clipboard";
                    button9.Text = "Results to Clipboard";
                    button10.Text = "Clear Clipboard";
                }

            }

            if (dataGridView3.DataSource is null)
            {
                if (lowmemorymode == true)
                {
                    dataGridView3.ColumnHeadersVisible = false;
                    dataGridView3.ColumnHeadersVisible = false;
                    dataGridView3.ReadOnly = true;
                    dataGridView3.AllowUserToAddRows = false;
                    textBox11.Visible = true;
                    textBox12.Visible = true;
                    textBox13.Visible = true;
                    textBox14.Visible = true;
                    textBox10.Visible = true;
                    textBox9.Visible = true;
                    textBox16.Visible = true;

                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";

                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox16.Text = "";

                    button3.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox2.BackColor = Color.Transparent;
                    button9.Enabled = false;
                    button10.Enabled = false;

                    button3.Text = "Results to Clipboard";
                    button7.Text = "Results to Clipboard";
                    button6.Text = "Clear Clipboard";
                    button9.Text = "Results to Clipboard";
                    button10.Text = "Clear Clipboard";

                }

            }
        }

        async void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            {

                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        Text = "SQL Tools";
                    });

                    if (lowmemorymode == true)
                    {

                        if (dataGridView6.Rows.Count > 0)
                        {

                            dataGridView6.Rows.Clear();

                            textBox9.Visible = true;
                            textBox10.Visible = true;
                            richTextBox2.Text = "";
                            richTextBox4.Text = "";
                        }

                        if (dataGridView7.Rows.Count > 0)
                        {

                            dataGridView7.Rows.Clear();

                            textBox9.Visible = true;
                            textBox10.Visible = true;
                            richTextBox2.Text = "";
                            richTextBox4.Text = "";
                        }
                    }


                    if (lowmemorymode == true)
                    {
                        textBox9.Visible = true;
                        textBox10.Visible = true;
                        textBox9.Text = "";
                        textBox10.Text = "";


                        dataGridView6.ColumnHeadersVisible = false;
                        dataGridView7.ColumnHeadersVisible = false;
                    }

                    f5pressed = false;
                    ctp = "ctp4";
                   // button3.Enabled = true;
                    ///button3.Text = "Results to Clipboard";
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    button8.Enabled = true;
                    ctp = "ctp4";

                    busy = false;

                    //dataGridView4.Rows.Clear();

                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();
                    if (dta != null)
                    {
                        dataGridView4.ScrollBars = ScrollBars.Both;
                        contextMenuStrip1.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        toolStripMenuItem9.Enabled = true;
                        toolStripMenuItem10.Enabled = true;
                        toolStripMenuItem11.Enabled = true;
                        toolStripMenuItem12.Enabled = true;
                        dta = dta.Copy();

                        dataGridView4.DataSource = null;
                        dataGridView4.Refresh();

                        if (lowmemorymode == false)
                        {
                            dtm4 = dta.Copy();
                        }

                        if (lowmemorymode == false)
                        {
                            dataGridView4.DataSource = dtm4;
                        }

                        if (lowmemorymode == true)
                        {


                            dataGridView4.DataSource = dta;

                        }

                        contextMenuStrip3.Enabled = true;
                        toolStripMenuItem3.Enabled = true;




                        if (dta.Rows.Count < 1 || dta == null)
                        {
                            dataGridView4.ScrollBars = ScrollBars.None;
                            textBox14.Visible = true;
                            textBox14.Text = "No Results." + changederror;
                            richTextBox1.Enabled = true;
                        }


                        if (dta.Rows.Count > 0)
                        {
                            dataGridView4.ColumnHeadersVisible = true;
                            contextMenuStrip3.Enabled = true;
                            toolStripMenuItem3.Enabled = true;
                            textBox14.Visible = false;
                            richTextBox1.Enabled = true;

                        }

                    }

                    if (dta is null)
                    {
                        if (lowmemorymode == true)
                        {
                            dataGridView4.ColumnHeadersVisible = false;
                            dataGridView5.ColumnHeadersVisible = false;
                            dataGridView6.ColumnHeadersVisible = false;
                        }
                        //button3.Enabled = false;
                        textBox14.Visible = true;
                        textBox14.Text = "No Results." + changederror;
                        richTextBox1.Enabled = true;
                    }

                    if (busy == true && dataGridView4.Visible == true)
                    {
                        if (lowmemorymode == true)
                        {
                            dataGridView4.ColumnHeadersVisible = false;
                            dataGridView5.ColumnHeadersVisible = false;
                            dataGridView6.ColumnHeadersVisible = false;
                        }
                        //button3.Enabled = false;
                        //    contextMenuStrip1.Enabled = false;
                        //    toolStripMenuItem1.Enabled = false;
                        //    toolStripMenuItem9.Enabled = false;
                        //    toolStripMenuItem10.Enabled = false;
                        //    toolStripMenuItem11.Enabled = false;
                        //    toolStripMenuItem12.Enabled = false;
                        //    contextMenuStrip2.Enabled = false;
                        //    toolStripMenuItem2.Enabled = false;
                    }


                    if (dta != null && datacleared == true && dta.Rows.Count == 0)
                    {
                        //errormessage += Environment.NewLine+"An error occurred - please check your query and syntax.";
                        textBox14.Text = "No Results.";
                        // datacleared = false;
                        dataGridView4.Visible = false;
                        dataGridView4.ScrollBars = ScrollBars.None;
                        dataGridView4.ColumnHeadersVisible = false;
                        busy = false;

                    }


                    if (dta != null && datacleared == false && dta.Rows.Count == 0)
                    {


                        dataGridView4.Visible = false;
                        dataGridView4.ScrollBars = ScrollBars.None;
                        dataGridView4.ColumnHeadersVisible = false;
                        textBox14.Visible = true;
                        textBox14.Text = "No Results.";
                        richTextBox1.Enabled = true;
                    }


                    busy = false;
                    richTextBox1.Enabled = true;
                }

                dataGridView6.ResumeLayout();

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


            int curposstart = richTextBox1.SelectionStart;

            if (richTextBox1.Text.Length == 0)
            {
                caretposition = 0;
            }
            string resulttxt = Regex.Replace(richTextBox1.Text, @"\r\n?|\n", Environment.NewLine);

            int currentline = richTextBox1.GetFirstCharIndexOfCurrentLine();

            if (currentline > 0)
            {
                curlin = curposstart;
                    //currentline;
            }

            else
            {
                curlin = richTextBox1.SelectionStart;
            }
            


            
            richTextBox1.ScrollToCaret();

            string tosplit = resulttxt.Replace("\r\n", " ");

            string[] rtbarray = tosplit.Split(" ");




            //{
            splits = 1;
            //}

            

            string beforetext = richTextBox1.Text.Substring(0, caretposition);

            string beforetextedited = beforetext.Replace("\n", " ");

            string[]? chars = new string[36];

            outofrange = false;

            chars[0] = "a";
            chars[1] = "b";
            chars[2] = "c";
            chars[3] = "d";
            chars[4] = "e";
            chars[5] = "f";
            chars[6] = "g";
            chars[7] = "h";
            chars[8] = "i";
            chars[9] = "j";
            chars[10] = "k";
            chars[11] = "l";
            chars[12] = "m";
            chars[13] = "n";
            chars[14] = "o";
            chars[15] = "p";
            chars[16] = "q";
            chars[17] = "r";
            chars[18] = "s";
            chars[19] = "t";
            chars[20] = "u";
            chars[21] = "v";
            chars[22] = "w";
            chars[23] = "x";
            chars[24] = "y";
            chars[25] = "z";
            chars[26] = "1";
            chars[27] = "2";
            chars[28] = "3";
            chars[29] = "4";
            chars[30] = "5";
            chars[31] = "6";
            chars[32] = "7";
            chars[33] = "8";
            chars[34] = "9";
            chars[35] = "0";

            try
            {
                bool a = String.IsNullOrEmpty(richTextBox1.Text.Substring(richTextBox1.SelectionStart, 1));
            }

            catch
            {
                outofrange = true;
            }

            finally
            {

                if (outofrange == false)
                {
                    //string a = richTextBox1.Text.Substring(richTextBox1.SelectionStart, 1);
                    //MessageBox.Show(a);

                    foreach (string c in chars)
                    {

                        if (c.ToLower() == richTextBox1.Text.Substring(richTextBox1.SelectionStart, 1).ToLower())
                        {
                            hidelistbox = true;
                        }

                        if (hidelistbox == false)
                        {

                            if (richTextBox1.Text.Substring(richTextBox1.SelectionStart, 1) == " ")
                            {
                                addchar = " ";
                            }

                            if (Regex.Replace(richTextBox1.Text.Substring(richTextBox1.SelectionStart, 1), @"\r\n?|\n", Environment.NewLine) == Environment.NewLine)
                            {
                                addchar = Environment.NewLine;
                            }

                        }
                    }
                }
            }

     
            
           
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




            if (!beforetext.Contains("\n"))
            {
                containsreturn = false;
            }

            if (beforetext.Contains("\n") || (beforetext == " "))
            {
                containsreturn = true;
            }


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


            try

            {
                //TABLES




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


                SqlConnection conn = new SqlConnection(connex);


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

                int ind = ds.Columns.IndexOf("RowVersion");
                if (ind != -1)
                {
                    ds.Columns.RemoveAt(ind);
                }

                int ind2 = ds.Columns.IndexOf("TimeStamp");
                if (ind2 != -1)
                {
                    ds.Columns.RemoveAt(ind2);
                }

                //COLUMNS

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



                SqlConnection conn2 = new SqlConnection(connex);


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
                    richTextBox1.SelectionStart = curposstart;
                }

                if (lb.Items.Count > 0 && hidelistbox == false)// && label17.Text == "Connected")
                {
                    autocompletebusy = true;

                    richTextBox1.Select(lastspacebeforetext = beforetext.LastIndexOf(' ')+1, currentlen+1);

                    string sl = richTextBox1.SelectedText;

                    lb.Show();

                    lb.Focus();

                    //richTextBox1.Focus();

                    int charpos =
                        curlin;
                        //richTextBox1.SelectionStart;

                    Point carpos = richTextBox1.GetPositionFromCharIndex(charpos);

                    lb.Location = carpos;

                    richTextBox1.ScrollToCaret();

                    lb.Location = carpos;
                    lb.Visible = true;
                    lb.SetSelected(0, true);
                }

                if (hidelistbox == true)
                {
                    richTextBox1.SelectionStart = richTextBox1.SelectionStart+currentlen;
                    hidelistbox = false;
                }
            }

            catch (Exception)
            {
                richTextBox1.Select(caretposition, 1);
                MessageBox.Show("Suggestions failed to initialise.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            autocomplete = false;
            autocompletebusy = false;

            //curlin = 0;
            


        }

        private void Lb_KeyDown(object sender, KeyEventArgs e)
        {

            //listBox1.Visible = false;
            //listBox2.Visible = false;

                //int curpos = richTextBox1.SelectionStart;


            //if (containsreturn == false)
            //{
            //    addchar = " ";

            //}

            //else if (containsreturn == true)
            //{
            //    addchar = " " + Environment.NewLine;
                
            //}

           



            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {

                if (e.KeyCode == Keys.Down)
                {
                    if (lb.SelectedIndex < (lb.Items.Count - 1))
                    {
                        lb.SelectedIndex++;
                    }

                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (lb.SelectedIndex > 0)
                    {
                        lb.SelectedIndex--;
                    }

                    e.Handled = true;
                }

            }




            if (e.KeyData == Keys.Enter)
            {

                richTextBox1.GetLineFromCharIndex(lineIndex);


                //if (lb.SelectedIndex != -1)




                caretposition = curlin;

                string beforetext = richTextBox1.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');
                {
                    //string beforetext = richTextBox1.Text.Substring(0, caretposition);

                    //string beforetext2 = beforetext.Replace("\n", " ");

                    //lastspacebeforetext = beforetext2.LastIndexOf(' ');



                    if (lb.Visible == true)
                    {



                        richTextBox1.Select(lastspacebeforetext = (beforetext2).LastIndexOf(' ') + 1, currentlen);

                        richTextBox1.SelectionColor = Color.Black;

                        richTextBox1.SelectedText = lb.SelectedItem.ToString() + addchar;

                        

                        autocomplete = false;

                        richTextBox1.Focus();



                    }

                        lb.Hide();
                    //richTextBox1.SelectionStart = richTextBox1.SelectionStart;

                    lb.Visible = false;

                        autocompletebusy = false;
                        autocomplete = false;

                    
                    //richTextBox1.Focus();
                    richTextBox1.DeselectAll();
                        richTextBox1.Refresh();

                        

                }
            }


            if (e.KeyCode == Keys.Left && lb.SelectedItem is not null)
            {
                //caretposition = 0;

                caretposition = curlin;

                string beforetext = richTextBox1.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');






                if (lb.Visible == true)
                {


                    richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox1.SelectionColor = Color.Black;

                    string appendageleft = lb.SelectedItem.ToString().Split('.')[0];

                    richTextBox1.SelectedText = appendageleft  + addchar;

                    autocomplete = false;

                    richTextBox1.Focus();

                    lb.Hide();
                    //richTextBox1.SelectionStart = richTextBox1.SelectionStart - 1;
                    //richTextBox1.SelectionStart = caretposition;

                    richTextBox1.Focus();
                    richTextBox1.DeselectAll();
                    richTextBox1.Refresh();


                }
            }


            if (e.KeyCode == Keys.Right && lb.SelectedItem is not null)
            {
                //caretposition = 0;

                caretposition = curlin;

                string beforetext = richTextBox1.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');

                //string beforetext = richTextBox1.Text.Substring(0, caretposition);

                //string beforetext2 = beforetext.Replace("\n", " ");

                //lastspacebeforetext = beforetext2.LastIndexOf(' ');

                //int lastcharacter = beforetext.Length - 1;
                //if (beforetext.Length > 0)
                //{

                //    if (beforetext.Substring(0, lastcharacter) == "\n")
                //    {
                //        newlineonened = true;
                //    }


                //    if (beforetext.Substring(0, lastcharacter) != "\n")
                //    {
                //        newlineonened = false;
                //    }

                //}



                if (lb.Visible == true)
                {


                    richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);


                    richTextBox1.SelectionColor = Color.Black;


                    string appendageright = lb.SelectedItem.ToString().Split('.')[1];

                    richTextBox1.SelectedText = appendageright  + addchar;

                    //richTextBox1.SelectionStart = caretposition;

                    autocomplete = false;

                    

                    richTextBox1.Focus();

                    lb.Hide();
                    //richTextBox1.SelectionStart = richTextBox1.SelectionStart - 1;

                    richTextBox1.Focus();
                    richTextBox1.DeselectAll();
                    richTextBox1.Refresh();

        




                }
            }


            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                lb.Hide();
                richTextBox1.SelectionStart = curlin;
                richTextBox1.DeselectAll();
                richTextBox1.Focus();
                richTextBox1.Refresh();

            }

            




            //richTextBox1.ScrollToCaret();

            

            //curlin = 0;
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
                colouring = true;
                richTextBox2.Select(positionOfcarett, -findText.Length);
                richTextBox2.SelectionColor = Color.Blue;
                richTextBox2.DeselectAll();
                richTextBox2.SelectionLength = 0;
                richTextBox2.ForeColor = Color.Black;
                richTextBox2.SelectionStart = positionOfcarett;
                colouring = false;


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
                //richTextBox2.SelectionStart = richTextBox2.Text.Length;
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
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                //checkBox7.Checked = false;
            }


            if (e.KeyCode == Keys.Back)
            {

                if (richTextBox2.Text.Length > 0)
                {
                    string txt;

                    if ((richTextBox2.SelectionStart - 1) > 0)
                    {
                        txt = richTextBox2.Text.Substring(richTextBox2.SelectionStart - 1, 1);
                        if (txt == "'")
                        {
                            ct2 = ct2 - 1;
                        }
                    }
                }


            }

            if
             (autocompletebusy == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }


            if (e.KeyCode == Keys.Oem3)
            {
                ct2 = ct2 + 1;
                dotextstuffred2(sender, e);
            }


            textBox9.Text = "";
            textBox10.Text = "";


            int len = richTextBox2.TextLength;

            if (e.KeyCode == Keys.Back)
            {
                len = len - 2;
            }

            if (len > -1)
            {
                richTextBox4.Enabled = true;

            }

            if (len <= -1)
            {
                richTextBox4.Enabled = false;
            }

            lb.Visible = false;
            listBox2.Visible = false;

            if (listBox1.Visible == true && e.KeyCode != Keys.Decimal || autocompletebusy == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Decimal)
            {
                if (autocomplete == false && checkBox7.Checked == true)
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
                workerbusy(sender, e);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F5 && busy == false)
            {

                dataGridView6.DataSource = null;
                dataGridView7.DataSource = null;
                //richTextBox2.Enabled = false;
                richTextBox4_KeyDown3(sender, e);
                //tabControl3.SelectedTab = tabPage9;
            }

            string[]? prochar = new string[45];
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
                    //richTextBox2.ScrollToCaret();
                }


                if (

                   //e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.F5) &&
                   richTextBox2.TextLength > 1 &&
                   f5pressed == false && inedit2 == true
                   )
                {

                    //InputSimulator ks = new InputSimulator();

                    //int len = richTextBox2.TextLength;

                    string[]? procwords = new string[300];
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

            if (lowmemorymode == true)
            {
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView2.ColumnHeadersVisible = false;
                dataGridView3.ColumnHeadersVisible = false;
                dataGridView4.ColumnHeadersVisible = false;
                dataGridView5.ColumnHeadersVisible = false;
                dataGridView6.ColumnHeadersVisible = false;
                dataGridView7.ColumnHeadersVisible = false;
                dataGridView8.ColumnHeadersVisible = false;
            }

            //button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
            button8.Enabled = false;
            //label18.Visible = true;

            //textBox11.Text = "No Results.";
            //label14.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            //this.label17.Location = new System.Drawing.Point(268, 110);
            label17.Text = "Not Connected";
            label17.TextAlign = ContentAlignment.TopRight;
            label17.ForeColor = System.Drawing.Color.Black;
            //contextMenuStrip1.Enabled = false;
            //toolStripMenuItem1.Enabled = false;
            //toolStripMenuItem9.Enabled = false;
            //toolStripMenuItem10.Enabled = false;
            //toolStripMenuItem11.Enabled = false;
            //toolStripMenuItem12.Enabled = false;
            //contextMenuStrip2.Enabled = false;
            //toolStripMenuItem2.Enabled = false;
            sqlcomm = "";

            quer = richTextBox2.Text;





            if (busy == true)
            {
                workerbusy(sender, e);
                return;
            }

            if (busy != true)
            {
                try
                {
                    backgroundWorker5.RunWorkerAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }




        }


        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
           
                if (dta is not null)
                {
                    dta.Clear();
                }

                if (dta2 is not null)
                {
                    dta2.Clear();
                }

                dta = null;
                dta2 = null;
            


            BeginInvoke((MethodInvoker)delegate
            {
                {

                    if (lowmemorymode == true)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        dataGridView3.DataSource = null;
                        dataGridView4.DataSource = null;
                        dataGridView5.DataSource = null;
                        dataGridView6.DataSource = null;
                        dataGridView7.DataSource = null;
                        dataGridView8.DataSource = null;
                    }
                }
                Text = "SQL Tools - WORKING...";
            });
            //errormessage = "";
            //changederror = "";

            if (busy == true)
            {
                workerbusy(sender, e);
                return;
            }

            if (busy != true)
            {
                try
                {
                    backgroundWorker1.RunWorkerAsync();
                    busy = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            BeginInvoke((MethodInvoker)delegate
            {

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
                {
                    try
                    {
                        using (SqlConnection cmd = new SqlConnection(connex))
                        {
                            try
                            {

                                {
                                    quer = Regex.Replace(quer, @"\r\n?|\n", Environment.NewLine);

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
                                            //this.label17.Location = new System.Drawing.Point(288, 112);
                                            label17.ForeColor = System.Drawing.Color.DarkGreen;
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



                                    int ind = ds.Columns.IndexOf("RowVersion");
                                    if (ind != -1)
                                    {
                                        ds.Columns.RemoveAt(ind);
                                    }

                                    int ind2 = ds.Columns.IndexOf("TimeStamp");
                                    if (ind2 != -1)
                                    {
                                        ds.Columns.RemoveAt(ind2);
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
                                            datacleared = false;
                                        }

                                    }

                                }


                                {
                                    quer = Regex.Replace(quer, @"\r\n?|\n", Environment.NewLine);

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
                                            //this.label17.Location = new System.Drawing.Point(288, 112);
                                            label17.ForeColor = System.Drawing.Color.DarkGreen;
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

                                    int ind = ds.Columns.IndexOf("RowVersion");
                                    if (ind != -1)
                                    {
                                        ds.Columns.RemoveAt(ind);
                                    }

                                    int ind2 = ds.Columns.IndexOf("TimeStamp");
                                    if (ind2 != -1)
                                    {
                                        ds.Columns.RemoveAt(ind2);
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
                                            datacleared = false;
                                        }

                                    }

                                }


                            }

                            catch (Exception ex)

                            {
                                if (worker.CancellationPending == true)
                                {
                                    return;
                                }

                                if (ex.Message != null)
                                {

                                    string msg = ex.Message;

                                    safesqlexceptionhandler(sender, e);
                                }
                            }
                            finally
                            {
                                cmd.Close();
                            }

                        }
                    }
                    catch (Exception)
                    {
                        errormessage = Environment.NewLine + "Please enter valid connection details.";
                        //MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);

                        BeginInvoke((MethodInvoker)delegate
                        {
                            dataGridView5.Rows.Clear();
                            dataGridView6.Rows.Clear();
                            dataGridView7.Rows.Clear();
                            //textBox9.Visible = true;
                            //textBox9.Text = msg;
                            //groupBox8.Text = "Error";
                            datacleared = false;
                        });
                    }
                }
            }
            return;
        }


        public void HideHeaders2(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource is null)
            {

                if (lowmemorymode == true)
                {
                    dataGridView4.ColumnHeadersVisible = false;
                    dataGridView5.ColumnHeadersVisible = false;
                    dataGridView6.ColumnHeadersVisible = false;
                }
                dataGridView4.ReadOnly = true;
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.ScrollBars = ScrollBars.None;
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                richTextBox4.Text = "";
            }

        }

        async void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            {

                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        Text = "SQL Tools";
                    });


                    f5pressed = false;
                    ctp = "ctp4";
                    //button3.Enabled = true;
                    //button3.Text = "Results to Clipboard";

                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    button8.Enabled = true;

                    ctp = "ctp4";
                    busy = false;

                    //dataGridView4.Rows.Clear();


                    dataGridView5.DataSource = null;
                    dataGridView6.DataSource = null;

                    textBox14.Visible = true;
                    textBox14.Text = "";


                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();
                    if (dta != null)
                    {
                        contextMenuStrip1.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        toolStripMenuItem9.Enabled = true;
                        toolStripMenuItem10.Enabled = true;
                        toolStripMenuItem11.Enabled = true;
                        toolStripMenuItem12.Enabled = true;
                        dataGridView5.ScrollBars = ScrollBars.Both;
                        dta = dta.Copy();

                        dataGridView5.DataSource = null;
                        dataGridView5.Refresh();

                        if (lowmemorymode == false)
                        {
                            dtm5 = dta.Copy();
                        }

                        if (lowmemorymode == false)
                        {
                            dataGridView5.DataSource = dtm5;
                        }

                        if (lowmemorymode == true)
                        {


                            dataGridView5.DataSource = dta;

                        }




                        groupBox11.Text = "Results";
                        groupBox12.Text = "Results";


                        if (dta.Rows.Count < 1 || dta == null)
                        {

                            dataGridView5.ScrollBars = ScrollBars.None;
                            //textBox10.Visible = false;
                            textBox10.Visible = true;
                            textBox10.Text = Environment.NewLine + changederror;
                        }


                        if (dta.Rows.Count > 0)
                        {
                            textBox10.Visible = false;

                        }

                    }

                    if (dta is null)
                    {

                        dataGridView5.ColumnHeadersVisible = false;
                        dataGridView6.ColumnHeadersVisible = false;
                        //button3.Enabled = false;
                        textBox10.Visible = true;
                        textBox10.Text = Environment.NewLine + changederror;
                    }

                    if (busy == true)
                    {
                        dataGridView5.ColumnHeadersVisible = false;
                        dataGridView6.ColumnHeadersVisible = false;
                        //button3.Enabled = false;
                        //contextMenuStrip1.Enabled = false;
                        //toolStripMenuItem1.Enabled = false;
                        //contextMenuStrip2.Enabled = false;no
                        //toolStripMenuItem2.Enabled = false;
                    }

                    busy = false;
                    richTextBox2.Enabled = true;
                }
            }
            busy = false;
            errormessage = "";
        }

        private void groupBox8_Enter2(object sender, EventArgs e)
        {

        }


        public void treeviewbuild2()
        {



        }

        private void getdbdetails2(object sender, EventArgs e)
        {
            int curposstart = richTextBox2.SelectionStart;

            if (richTextBox2.Text.Length == 0)
            {
                caretposition = 0;
            }

            string resulttxt = Regex.Replace(richTextBox2.Text, @"\r\n?|\n", Environment.NewLine);

            int currentline = richTextBox2.GetFirstCharIndexOfCurrentLine();

            if (currentline > 0)
            {
                curlin = curposstart;
            }

            else
            {
                curlin = richTextBox2.SelectionStart;
            }


            richTextBox2.ScrollToCaret();

            string tosplit = resulttxt.Replace("\r\n", " ");

            string[] rtbarray = tosplit.Split(" ");


            //richTextBox2.SelectedText = "";

            //caretposition = richTextBox2.SelectionStart;

            //string tosplit = richTextBox2.Text.Replace("\n", " ");

            //string[] rtbarray = tosplit.Split(" ");




            //{
            splits = 1;
            //}

            string[]? chars = new string[36];

            outofrange = false;

            chars[0] = "a";
            chars[1] = "b";
            chars[2] = "c";
            chars[3] = "d";
            chars[4] = "e";
            chars[5] = "f";
            chars[6] = "g";
            chars[7] = "h";
            chars[8] = "i";
            chars[9] = "j";
            chars[10] = "k";
            chars[11] = "l";
            chars[12] = "m";
            chars[13] = "n";
            chars[14] = "o";
            chars[15] = "p";
            chars[16] = "q";
            chars[17] = "r";
            chars[18] = "s";
            chars[19] = "t";
            chars[20] = "u";
            chars[21] = "v";
            chars[22] = "w";
            chars[23] = "x";
            chars[24] = "y";
            chars[25] = "z";
            chars[26] = "1";
            chars[27] = "2";
            chars[28] = "3";
            chars[29] = "4";
            chars[30] = "5";
            chars[31] = "6";
            chars[32] = "7";
            chars[33] = "8";
            chars[34] = "9";
            chars[35] = "0";

            try
            {
                bool b = String.IsNullOrEmpty(richTextBox2.Text.Substring(richTextBox2.SelectionStart, 1));
            }

            catch
            {
                outofrange = true;
            }

            finally
            {

                if (outofrange == false)
                {
                    //string a = richTextBox2.Text.Substring(richTextBox2.SelectionStart, 1);
                    //MessageBox.Show(a);

                    foreach (string c in chars)
                    {

                        if (c.ToLower() == richTextBox2.Text.Substring(richTextBox2.SelectionStart, 1).ToLower())
                        {
                            hidelistbox = true;
                        }

                        if (hidelistbox == false)
                        {

                            if (richTextBox2.Text.Substring(richTextBox2.SelectionStart, 1) == " ")
                            {
                                addchar = " ";
                            }

                            if (Regex.Replace(richTextBox2.Text.Substring(richTextBox2.SelectionStart, 1), @"\r\n?|\n", Environment.NewLine) == Environment.NewLine)
                            {
                                addchar = Environment.NewLine;
                            }

                        }
                    }
                }
            }


            string beforetext = richTextBox2.Text.Substring(0, caretposition);

            string beforetextedited = beforetext.Replace("\n", " ");

            string aftertext = richTextBox2.Text.Substring(caretposition, (richTextBox2.Text.Length - caretposition));

            string a = aftertext;

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


            //if (beforetext.Contains("\n"))
            //{
            //    containsreturn = true;
            //}

            if (!beforetext.Contains("\n")) //aftertext??
            {
                containsreturn = false;
            }

            if (beforetext.Contains("\n"))
            {
                containsreturn = true;
            }


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



            try
            {
                //TABLES


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




                SqlConnection conn = new SqlConnection(connex);


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

                int ind = ds.Columns.IndexOf("RowVersion");
                if (ind != -1)
                {
                    ds.Columns.RemoveAt(ind);
                }

                int ind2 = ds.Columns.IndexOf("TimeStamp");
                if (ind2 != -1)
                {
                    ds.Columns.RemoveAt(ind2);
                }


                //COLUMNS


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




                SqlConnection conn2 = new SqlConnection(connex);


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
                    richTextBox2.SelectionStart = curposstart;
                }

                if (listBox1.Items.Count > 0 && hidelistbox == false)
                {
                    autocompletebusy = true;

                    richTextBox2.Select(lastspacebeforetext = beforetext.LastIndexOf(' ') + 1, currentlen + 1);

                    string sl = richTextBox2.SelectedText;

                    listBox1.Show();

                    listBox1.Focus();

                    //richTextBox2.Focus();

                    //int charpos = richTextBox2.SelectionStart;

                    //Point carpos = richTextBox2.GetPositionFromCharIndex(charpos);

                    int charpos =
                     curlin;
                    //richTextBox1.SelectionStart;

                    Point carpos = richTextBox2.GetPositionFromCharIndex(charpos);

                    listBox1.Location = carpos;

                    richTextBox2.ScrollToCaret();


                    listBox1.Location = carpos;
                    listBox1.Visible = true;
                    listBox1.SetSelected(0, true);
                }

                if (hidelistbox == true)
                {
                    richTextBox2.SelectionStart = richTextBox2.SelectionStart + currentlen;
                    hidelistbox = false;
                }

            }

            catch (Exception)
            {
                richTextBox2.Select(caretposition, 1);
                MessageBox.Show("Suggestions failed to initialise.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            autocomplete = false;
            autocompletebusy = false;





        }

        private void Lb_KeyDown2(object sender, KeyEventArgs e)
        {


            if (containsreturn == true)
            {
                addchar = " " + Environment.NewLine;
            }

            if (containsreturn == false)
            {
                addchar = " ";
            }



            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {

                if (e.KeyCode == Keys.Down)
                {
                    if (listBox1.SelectedIndex < (listBox1.Items.Count - 1))
                    {
                        listBox1.SelectedIndex++;
                    }

                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (listBox1.SelectedIndex > 0)
                    {
                        listBox1.SelectedIndex--;
                    }

                    e.Handled = true;
                }

            }



            if (e.KeyData == Keys.Enter)
            {

                richTextBox2.GetLineFromCharIndex(lineIndex);


                //if (listBox1.SelectedIndex != -1)
                {

                    caretposition = curlin;

                    string beforetext = richTextBox2.Text.Substring(0, caretposition);

                    string beforetext2 = beforetext.Replace("\n", " ");

                    lastspacebeforetext = beforetext2.LastIndexOf(' ');

                    //string beforetext = richTextBox2.Text.Substring(0, caretposition);

                    //string beforetext2 = beforetext.Replace("\n", " ");

                    //lastspacebeforetext = beforetext2.LastIndexOf(' ');



                    if (listBox1.Visible == true)
                    {



                        richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                        richTextBox2.SelectionColor = Color.Black;

                        richTextBox2.SelectedText = listBox1.SelectedItem.ToString() + addchar;

                        autocomplete = false;

                        richTextBox2.Focus();



                    }

                    listBox1.Hide();
                    richTextBox2.SelectionStart = richTextBox2.SelectionStart - 1;

                    listBox1.Visible = false;

                    autocompletebusy = false;
                    autocomplete = false;

                    richTextBox2.DeselectAll();
                    richTextBox2.Refresh();
                }
            }


            if (e.KeyCode == Keys.Left && listBox1.SelectedItem is not null)
            {



                caretposition = curlin;

                string beforetext = richTextBox2.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');





                //string beforetext = richTextBox2.Text.Substring(0, caretposition);

                //string beforetext2 = beforetext.Replace("\n", " ");

                //lastspacebeforetext = beforetext2.LastIndexOf(' ');






                if (listBox1.Visible == true)
                {



                    richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox2.SelectionColor = Color.Black;

                    string appendageleft = listBox1.SelectedItem.ToString().Split('.')[0];

                    richTextBox2.SelectedText = appendageleft + addchar;

                    autocomplete = false;

                    richTextBox2.Focus();

                    listBox1.Hide();
                    richTextBox2.SelectionStart = richTextBox2.SelectionStart - 1;

                    //richTextBox2.SelectionStart = caretposition;

                    richTextBox2.Focus();
                    richTextBox2.DeselectAll();
                    richTextBox2.Refresh();


                }
            }


            if (e.KeyCode == Keys.Right && listBox1.SelectedItem is not null)
            {

                caretposition = curlin;

                string beforetext = richTextBox2.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');

                //string beforetext = richTextBox2.Text.Substring(0, caretposition);

                //string beforetext2 = beforetext.Replace("\n", " ");

                //lastspacebeforetext = beforetext2.LastIndexOf(' ');

                //int lastcharacter = beforetext.Length - 1;

                //if (beforetext.Length > 0)
                //{

                //    if (beforetext.Substring(0, lastcharacter) == "\n")
                //    {
                //        newlineonened = true;
                //    }


                //    if (beforetext.Substring(0, lastcharacter) != "\n")
                //    {
                //        newlineonened = false;
                //    }

                //}




                if (listBox1.Visible == true)
                {


                    richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);


                    richTextBox2.SelectionColor = Color.Black;


                    string appendageright = listBox1.SelectedItem.ToString().Split('.')[1];

                    richTextBox2.SelectedText = appendageright + addchar;

                    //richTextBox2.SelectionStart = caretposition;

                    autocomplete = false;

                    richTextBox2.Focus();

                    listBox1.Hide();
                    richTextBox2.SelectionStart = richTextBox2.SelectionStart - 1;

                    //richTextBox2.SelectionStart = caretposition;

                    richTextBox2.Focus();
                    richTextBox2.DeselectAll();
                    richTextBox2.Refresh();




                }
            }


            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                listBox1.Hide();
                richTextBox2.SelectionStart = curlin;
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
                colouring = true;
                richTextBox4.Select(positionOfcarett, -findText.Length);
                richTextBox4.SelectionColor = Color.Blue;
                richTextBox4.DeselectAll();
                richTextBox4.SelectionLength = 0;
                richTextBox4.ForeColor = Color.Black;
                richTextBox4.SelectionStart = positionOfcarett;
                colouring = false;


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
                //richTextBox4.SelectionStart = richTextBox4.Text.Length;
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

            //if (colouring == true)
            //{
            //    e.Handled = true;
            //    string hold = e.ToString();
            //    richTextBox4.Text = richTextBox4 + hold;
            //}


            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                //checkBox7.Checked = false;
            }


            if (e.KeyCode == Keys.Back)
            {

                if (richTextBox4.Text.Length > 0)
                {
                    string txt;

                    if ((richTextBox4.SelectionStart - 1) > 0)
                    {
                        txt = richTextBox4.Text.Substring(richTextBox4.SelectionStart - 1, 1);
                        if (txt == "'")
                        {
                            ct3 = ct3 - 1;
                        }
                    }
                }


            }

            if
             (autocompletebusy == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }


            if (e.KeyCode == Keys.Oem3)
            {
                ct3 = ct3 + 1;
                dotextstuffred3(sender, e);
            }

            listBox1.Visible = false;
            lb.Visible = false;

            if (listBox2.Visible == true && e.KeyCode != Keys.Decimal || autocompletebusy == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                //checkBox7.Checked = false;
            }

            if (e.KeyCode == Keys.Decimal)
            {
                if (autocomplete == false && checkBox7.Checked == true)
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
                workerbusy(sender, e);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F5 && busy == false)
            {

                dataGridView6.DataSource = null;
                dataGridView7.DataSource = null;
                richTextBox2.Enabled = false;
                richTextBox4.Enabled = false;
                richTextBox5_KeyDowns2(sender, e);
                tabControl3.SelectedTab = tabPage10;


            }

            string[]? prochar = new string[45];
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
                    //richTextBox4.ScrollToCaret();

                }


                if (

                   //e.KeyCode != Keys.Space || //e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.F5) &&
                   richTextBox4.TextLength > 1 &&
                   f5pressed == false && inedit3 == true
                   )
                {

                    //InputSimulator ks = new InputSimulator();

                    //int len = richTextBox4.TextLength;

                    string[]? procwords = new string[300];
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
                            colouring = true;
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


        private void richTextBox5_KeyDowns2(object sender, EventArgs e)

        {



            textBox9.Visible = false;
            textBox10.Visible = false;
            //dataGridView6.Visible = true;

            if (dta is not null)
            {
                if (dta.Rows.Count != 0)
                {

                    dta.Clear();
                    datacleared = true;
                }
            }
            if (dta2 is not null)
            {
                if (dta2.Rows.Count != 0)
                {
                    dta2.Clear();
                    datacleared = true;
                }
            }

            if (lowmemorymode == true)
            {

                dataGridView1.ColumnHeadersVisible = false;
                dataGridView2.ColumnHeadersVisible = false;
                dataGridView3.ColumnHeadersVisible = false;
                dataGridView4.ColumnHeadersVisible = false;
                dataGridView5.ColumnHeadersVisible = false;
                dataGridView6.ColumnHeadersVisible = false;
                dataGridView7.ColumnHeadersVisible = false;
                dataGridView8.ColumnHeadersVisible = false;
            }

            dataGridView6.Rows.Clear();
            dataGridView7.Rows.Clear();

            //button3.Enabled = false;
            // button4.Enabled = false;
            // button1.Enabled = false;
            // button8.Enabled = false;

            //textBox11.Text = "No Results.";
            //label14.Visible = false;
            button2.Enabled = false;
            button1.Enabled = false;
            //this.label17.Location = new System.Drawing.Point(288, 110);
            label17.Text = "Not Connected";
            label17.TextAlign = ContentAlignment.TopRight;
            label17.ForeColor = System.Drawing.Color.Black;
            //contextMenuStrip1.Enabled = false;
            //toolStripMenuItem1.Enabled = false;
            //toolStripMenuItem9.Enabled = false;
            //toolStripMenuItem10.Enabled = false;
            //toolStripMenuItem11.Enabled = false;
            //toolStripMenuItem12.Enabled = false;
            //contextMenuStrip2.Enabled = false;
            //toolStripMenuItem2.Enabled = false;
            sqlcomm = "";

            quer = richTextBox2.Text;


            if (busy == true)
            {
                workerbusy(sender, e);
                //return;
            }

            if (busy != true)
            {
                try
                {
                    backgroundWorker6.RunWorkerAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }



        }


        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
           
                if (dta is not null)
                {
                    dta.Clear();
                }

                if (dta2 is not null)
                {
                    dta2.Clear();
                }

                dta = null;
                dta2 = null;
            

            BeginInvoke((MethodInvoker)delegate
            {
                {

                    if (lowmemorymode == true)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        dataGridView3.DataSource = null;
                        dataGridView4.DataSource = null;
                        dataGridView5.DataSource = null;
                        dataGridView6.DataSource = null;
                        dataGridView7.DataSource = null;
                        dataGridView8.DataSource = null;
                    }
                }
                Text = "SQL Tools - WORKING...";
            });
            //busy = true;
            //errormessage = "";
            //changederror = "";

            if (dta is not null)
            {
                dta.Dispose();
            }
            if (dta2 is not null)
            {
                dta2.Dispose();
            }
            if (dta3 is not null)
            {
                dta3.Dispose();
            }



            BeginInvoke((MethodInvoker)delegate
            {
                //dataGridView6.Enabled = false;
                //dataGridView6.SuspendLayout();
                dataGridView6.ReadOnly = true;
                quer2 = richTextBox4.Text;
                dataGridView6.DataSource = null;
                dataGridView7.DataSource = null;
                //dataGridView6.Visible = false;
                //dataGridView7.Visible = false;
                groupBox8.Text = "Results";
                textBox9.Visible = false;
                textBox10.Visible = false;

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
                            quer = Regex.Replace(quer, @"\r\n?|\n", Environment.NewLine);

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
                                    //this.label17.Location = new System.Drawing.Point(288, 112);
                                    label17.ForeColor = System.Drawing.Color.DarkGreen;
                                }
                             );


                                if (cmd == null)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connection Failed";
                                        //this.label17.Location = new System.Drawing.Point(255, 112);
                                        label17.ForeColor = System.Drawing.Color.DarkRed;
                                    }
                                 );

                                }

                            }



                            adapter.SelectCommand = cmd1;



                            DataTable ds = new DataTable();
                            adapter.Fill(ds);
                            cmd.Close();

                            int ind = ds.Columns.IndexOf("RowVersion");
                            if (ind != -1)
                            {
                                ds.Columns.RemoveAt(ind);
                            }

                            int ind2 = ds.Columns.IndexOf("TimeStamp");
                            if (ind2 != -1)
                            {
                                ds.Columns.RemoveAt(ind2);
                            }


                            if (dta != null)
                            {

                                dta.Clear();




                                if (dta.Rows.Count > 0)
                                {
                                    dta.Rows.Clear();

                                }

                                dta = null;
                            }




                            if (dta == null)
                            {
                                BeginInvoke((MethodInvoker)delegate
                                {


                                });
                            }




                            foreach (DataColumn dc in ds.Columns)
                            {



                                foreach (DataRow dr in ds.Rows)
                                {


                                    {

                                        dta = dr.Table;
                                        dta.AcceptChanges();

                                        e.Result = true;
                                        datacleared = false;
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
                        {
                            return;
                        }

                        if (errormessage != null)


                        {

                            string? msg = ex.Message;


                            safesqlexceptionhandler(sender, e);

                            busy = false;

                        }

                    }



                    finally
                    {

                        dataGridView5.Rows.Clear();
                        dataGridView6.Rows.Clear();
                        dataGridView7.Rows.Clear();
                        secondsql(sender, e);


                    }

                }
            }
        }


        //Command 2

        public void secondsql(object sender, DoWorkEventArgs e)
        {
            //errormessage = "";
            //changederror = "";


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
                textBox9.Text = "";
                textBox10.Text = "";

                if (dta == null)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {

                    });
                }

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
                            quer = Regex.Replace(quer, @"\r\n?|\n", Environment.NewLine);
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
                                    //this.label17.Location = new System.Drawing.Point(288, 112);
                                    label17.ForeColor = System.Drawing.Color.DarkGreen;
                                }
                             );


                                if (cmd0 == null)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connection Failed";
                                        //this.label17.Location = new System.Drawing.Point(255, 112);
                                        label17.ForeColor = System.Drawing.Color.DarkRed;
                                    }
                                 );

                                }

                            }

                            adapter.SelectCommand = cmd1;
                            DataTable ds = new DataTable();
                            adapter.Fill(ds);


                            if (dta2 == null)
                            {
                                BeginInvoke((MethodInvoker)delegate
                                {

                                });
                            }


                            if (dta2 != null)
                            {
                                dta2.Clear();

                                if (dta2.Rows.Count > 0)
                                {
                                    dta2.Rows.Clear();
                                }
                            }

                            int ind = ds.Columns.IndexOf("RowVersion");
                            if (ind != -1)
                            {
                                ds.Columns.RemoveAt(ind);
                            }

                            int ind2 = ds.Columns.IndexOf("TimeStamp");
                            if (ind2 != -1)
                            {
                                ds.Columns.RemoveAt(ind2);
                            }
                            foreach (DataColumn dc in ds.Columns)
                            {

                                foreach (DataRow dr in ds.Rows)
                                {

                                    {

                                        dta2 = dr.Table;
                                        dta2.AcceptChanges();

                                        e.Result = true;
                                        datacleared = false;
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
                        {
                            return;
                        }

                        if (errormessage != null)

                        {


                            errormessage = Environment.NewLine + ex2.Message;


                            safesqlexceptionhandler(sender, e);

                        }

                    }


                    finally
                    {
                        dataGridView5.Rows.Clear();
                        dataGridView6.Rows.Clear();
                        dataGridView7.Rows.Clear();

                        dataGridView6.DataSource = null;
                        dataGridView7.DataSource = null;


                        thirdsql(null, null);

                    }



                }
            }
        }


        public void thirdsql(object sender, EventArgs e)
        {

            textBox9.Text = "";
            textBox10.Text = "";

            //errormessage = "";
            //changederror = "";

            BeginInvoke((MethodInvoker)delegate
            {
                quer2 = richTextBox4.Text;

                //dataGridView6.Visible = false;
                //dataGridView7.Visible = false;
                groupBox12.Text = "Results";
                groupBox11.Text = "Results";
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox9.Text = "";
                textBox10.Text = "";

                if (dta != null)
                {


                }
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
                        quer = Regex.Replace(quer, @"\r\n?|\n", Environment.NewLine);
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
                                //this.label17.Location = new System.Drawing.Point(288, 112);
                                label17.ForeColor = System.Drawing.Color.DarkGreen;
                            }
                         );


                            if (cmd0 == null)

                            {
                                BeginInvoke((MethodInvoker)delegate
                                {
                                    label17.Text = "Connection Failed";
                                    //this.label17.Location = new System.Drawing.Point(255, 112);
                                    label17.ForeColor = System.Drawing.Color.DarkRed;
                                }
                             );

                            }

                        }

                        adapter.SelectCommand = cmd1;
                        DataTable ds = new DataTable();
                        adapter.Fill(ds);



                        int ind = ds.Columns.IndexOf("RowVersion");
                        if (ind != -1)
                        {
                            ds.Columns.RemoveAt(ind);
                        }

                        int ind2 = ds.Columns.IndexOf("TimeStamp");
                        if (ind2 != -1)
                        {
                            ds.Columns.RemoveAt(ind2);
                        }

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
                                datacleared = false;
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

                            if (msg2 != errormessage)
                            {
                                errormessage = Environment.NewLine + msg2;
                            }


                            safesqlexceptionhandler(sender, e);


                        });

                    }

                }






                finally
                {
                    if (busy == true)
                    {
                        workerbusy(sender, e);

                    }
                    dataGridView5.Rows.Clear();
                    dataGridView6.Rows.Clear();
                    dataGridView7.Rows.Clear();

                }




            }

        }



        public void HideHeaders3(object sender, EventArgs e)
        {
            if (dataGridView4.DataSource is null)
            {
                if (lowmemorymode == true)
                {
                    dataGridView4.ColumnHeadersVisible = false;
                }
                dataGridView4.ReadOnly = true;
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.ScrollBars = ScrollBars.None;
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                richTextBox4.Text = "";
            }

        }

        async void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            {

                {

                    BeginInvoke((MethodInvoker)delegate
                    {
                        Text = "SQL Tools";
                    });

                    if (lowmemorymode == true)
                    {
                    }

                    if (lowmemorymode == true)
                    {
                    }

                    //dataGridView5.DataSource = null;
                    //dataGridView6.DataSource = null;

                    dataGridView6.Rows.Clear();
                    dataGridView7.Rows.Clear();

                    if (lowmemorymode == true)
                    {
                        dataGridView6.ColumnHeadersVisible = false;
                        dataGridView7.ColumnHeadersVisible = false;
                    }

                    f5pressed = false;
                    ctp = "ctp4";
                    //button3.Enabled = true;
                    //button3.Text = "Results to Clipboard";
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    button8.Enabled = true;

                    if (lowmemorymode == true)
                    {
                        textBox14.Visible = true;
                    }
                    textBox14.Text = "";

                    busy = false;

                    if (dataGridView6 == null)
                    {

                        contextMenuStrip5.Enabled = false;
                    }

                    if (dataGridView7 == null)
                    {

                        contextMenuStrip4.Enabled = false;
                    }


                    ctp = "ctp4";

                    //dataGridView4.Rows.Clear();

                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();
                    if (dta != null)
                    {


                        dta = dta.Copy();

                        if (lowmemorymode == false)
                        {
                            dtm6 = dta.Copy();
                        }

                        dataGridView6.DataBindings.Clear();
                        dataGridView7.DataBindings.Clear();





                        dataGridView7.DataSource = null;

                        if (lowmemorymode == true)
                        {
                            dataGridView7.Refresh();
                            dataGridView7.DataSource = dta;
                        }

                        if (lowmemorymode == false)
                        {
                            dataGridView7.Refresh();
                            dataGridView7.DataSource = dtm6;
                        }

                        //dataGridView7.ScrollBars = ScrollBars.Both;
                        dataGridView7.Visible = true;
                        contextMenuStrip4.Enabled = true;
                        toolStripMenuItem3.Enabled = true;
                        toolStripMenuItem3.Visible = true;



                        if (dta.Rows.Count < 1 & errormessage == null)
                        {
                            datacleared = false;

                            dataGridView7.ScrollBars = ScrollBars.None;
                            textBox9.Visible = true;
                            textBox9.Text = "No Results" + changederror;
                            dataGridView7.ColumnHeadersVisible = false;

                            if (lowmemorymode == true)
                            {
                                dataGridView7.DataSource = null;
                                dataGridView7.Refresh();
                            }

                        }


                        if (dta.Rows.Count > 0)
                        {

                            dataGridView7.ColumnHeadersVisible = true;
                            textBox9.Visible = false;
                            //dataGridView7.Visible = true;
                        }



                        if (dta.Rows.Count < 1 & errormessage != "")
                        {
                            //label31.Visible = true;
                            dataGridView7.ColumnHeadersVisible = false;
                            //button3.Enabled = false;
                            textBox9.Visible = true;
                            textBox9.Text = "No Results.";

                            dataGridView7.DataSource = null;
                            dataGridView7.Refresh();
                            datacleared = true;



                            textBox9.Visible = false;
                            textBox9.Text = Environment.NewLine + errormessage;


                        }


                    }


                    if (dta is null)
                    {

                        dataGridView7.Visible = false;
                        dataGridView7.DataSource = null;
                        dataGridView7.Refresh();
                        dta2 = null;

                        if (errormessage != "")
                        {
                            //label31.Visible = true;
                            dataGridView7.ColumnHeadersVisible = false;
                            //button3.Enabled = false;
                            textBox9.Visible = true;
                            textBox9.Text = "No Results." + changederror;
                            textBox10.Visible = true;
                            textBox10.Text = "No Results." + changederror;

                        }

                        if (errormessage == null || errormessage == "")
                        {

                            dataGridView7.ColumnHeadersVisible = false;
                            button3.Enabled = false;
                            textBox9.Visible = true;
                            textBox10.Visible = true;
                            dataGridView7.DataSource = null;
                            dataGridView7.Refresh();
                            textBox9.Visible = true;
                            textBox9.Text = "No Results." + changederror;
                            textBox10.Visible = true;
                            textBox10.Text = "No Results." + changederror;
                        }



                    }


                    if (dta2 != null)
                    {

                        dataGridView6.ScrollBars = ScrollBars.Both;
                        dta2 = dta2.Copy();

                        if (lowmemorymode == false)
                        {
                            dtm7 = dta2.Copy();
                        }

                        dataGridView6.DataSource = null;
                        dataGridView6.Refresh();

                        if (lowmemorymode == true)
                        {
                            dataGridView6.DataSource = dta2;
                        }

                        if (lowmemorymode == false)
                        {
                            dataGridView6.DataSource = dtm7;
                        }

                        dataGridView6.Visible = true;


                        if (dta2.Rows.Count < 1 & errormessage == "")
                        {
                            datacleared = false;

                            dataGridView6.ScrollBars = ScrollBars.None;
                            textBox10.Visible = true;
                            textBox10.Text = "No Results.";
                            dataGridView6.ColumnHeadersVisible = false;
                            dataGridView6.DataSource = null;
                            dataGridView6.Refresh();

                        }


                        if (dta2.Rows.Count > 0)
                        {

                            dataGridView6.ColumnHeadersVisible = true;
                        }



                        if (dta2.Rows.Count < 1 & errormessage != "")
                        {
                            datacleared = true;
                            dataGridView6.ColumnHeadersVisible = false;
                            //button3.Enabled = false;
                            textBox10.Visible = true;
                            textBox10.Text = "No Results." + changederror;
                            dataGridView6.DataSource = null;
                            dataGridView6.Refresh();
                        }



                    }


                    if (dta2 is null || dta is null)
                    {

                        dataGridView6.Visible = false;
                        dataGridView7.Visible = false;
                        dataGridView6.DataSource = null;
                        dataGridView7.DataSource = null;


                        dataGridView6.Refresh();
                        dataGridView7.Refresh();

                        if (errormessage != "")
                        {
                            //label31.Visible = true;
                            dataGridView6.ColumnHeadersVisible = false;
                           // button3.Enabled = false;
                            textBox10.Visible = true;
                            textBox10.Text = "No Results." + changederror;

                        }

                        if (errormessage == null || errormessage == "")
                        {
                            //label31.Visible = true;
                            dataGridView6.ColumnHeadersVisible = false;
                            //button3.Enabled = false;
                            textBox9.Visible = true;
                            textBox9.Text = "No Results.";
                            textBox10.Visible = true;
                            textBox10.Text = "No Results.";
                            dataGridView6.DataSource = null;
                            dataGridView6.Refresh();
                        }



                    }





                    richTextBox4.Enabled = true;
                    richTextBox2.Enabled = true;
                    errormessage = "";

                    if (datacleared == true)
                    {
                        dataGridView6.Visible = false;
                        dataGridView7.Visible = false;


                        textBox10.Visible = true;
                        textBox9.Visible = true;
                        textBox9.Text = "No Results." + changederror;
                        textBox10.Text = "No Results." + changederror;
                        datacleared = false;
                        busy = false;
                    }

                    if (lowmemorymode == true)
                    {

                        dataGridView6.DataSource = dta2;
                    }


                    if (lowmemorymode == false)
                    {

                        dataGridView6.DataSource = dtm7;
                    }

                    //dataGridView6.ReadOnly = false;


                }
            }
            busy = false;
        }

        private void groupBox8_Enter3(object sender, EventArgs e)
        {

        }


        public void treeviewbuild3()
        {



        }

        private void getdbdetails3(object sender, EventArgs e)
        {
            int curposstart = richTextBox4.SelectionStart;

            if (richTextBox4.Text.Length == 0)
            {
                caretposition = 0;
            }


            string resulttxt = Regex.Replace(richTextBox4.Text, @"\r\n?|\n", Environment.NewLine);

            int currentline = richTextBox4.GetFirstCharIndexOfCurrentLine();

            if (currentline > 0)
            {
                curlin = curposstart;
            }

            else
            {
                curlin = richTextBox4.SelectionStart;
            }


            richTextBox4.ScrollToCaret();

            string tosplit = resulttxt.Replace("\r\n", " ");

            string[] rtbarray = tosplit.Split(" ");


            //lineIndex = richTextBox4.GetLineFromCharIndex(caretposition);

            //int txtlen = richTextBox4.Text.Length;

            //richTextBox4.SelectedText = "";

            //caretposition = richTextBox4.SelectionStart;

            //string tosplit = richTextBox4.Text.Replace("\n", " ");

            //string[] rtbarray = tosplit.Split(" ");




            //{
            splits = 1;
            //}

            string[]? chars = new string[36];

            outofrange = false;

            chars[0] = "a";
            chars[1] = "b";
            chars[2] = "c";
            chars[3] = "d";
            chars[4] = "e";
            chars[5] = "f";
            chars[6] = "g";
            chars[7] = "h";
            chars[8] = "i";
            chars[9] = "j";
            chars[10] = "k";
            chars[11] = "l";
            chars[12] = "m";
            chars[13] = "n";
            chars[14] = "o";
            chars[15] = "p";
            chars[16] = "q";
            chars[17] = "r";
            chars[18] = "s";
            chars[19] = "t";
            chars[20] = "u";
            chars[21] = "v";
            chars[22] = "w";
            chars[23] = "x";
            chars[24] = "y";
            chars[25] = "z";
            chars[26] = "1";
            chars[27] = "2";
            chars[28] = "3";
            chars[29] = "4";
            chars[30] = "5";
            chars[31] = "6";
            chars[32] = "7";
            chars[33] = "8";
            chars[34] = "9";
            chars[35] = "0";

            try
            {
                bool a = String.IsNullOrEmpty(richTextBox4.Text.Substring(richTextBox4.SelectionStart, 1));
            }

            catch
            {
                outofrange = true;
            }

            finally
            {

                if (outofrange == false)
                {
                    //string a = richTextBox4.Text.Substring(richTextBox4.SelectionStart, 1);
                    //MessageBox.Show(a);

                    foreach (string c in chars)
                    {

                        if (c.ToLower() == richTextBox4.Text.Substring(richTextBox4.SelectionStart, 1).ToLower())
                        {
                            hidelistbox = true;
                        }

                        if (hidelistbox == false)
                        {

                            if (richTextBox4.Text.Substring(richTextBox4.SelectionStart, 1) == " ")
                            {
                                addchar = " ";
                            }

                            if (Regex.Replace(richTextBox4.Text.Substring(richTextBox4.SelectionStart, 1), @"\r\n?|\n", Environment.NewLine) == Environment.NewLine)
                            {
                                addchar = Environment.NewLine;
                            }

                        }
                    }
                }
            }


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



            if (!beforetext.Contains("\n"))
            {
                containsreturn = false;
            }

            if (beforetext.Contains("\n"))
            {
                containsreturn = true;
            }


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



            try
            {
                //TABLES


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




                SqlConnection conn = new SqlConnection(connex);


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

                int ind = ds.Columns.IndexOf("RowVersion");
                if (ind != -1)
                {
                    ds.Columns.RemoveAt(ind);
                }

                int ind2 = ds.Columns.IndexOf("TimeStamp");
                if (ind2 != -1)
                {
                    ds.Columns.RemoveAt(ind2);
                }


                //COLUMNS


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




                SqlConnection conn2 = new SqlConnection(connex);


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

                    listBox2.Items.Add(l);

                    // });

                }


                listBox2.EndUpdate();
                listBox2.Refresh();


                if (listBox2.Items.Count == 0)
                {
                    richTextBox4.SelectionStart = curposstart;
                }

                if (listBox2.Items.Count > 0 && hidelistbox == false)
                {
                    autocompletebusy = true;

                    richTextBox4.Select(lastspacebeforetext = beforetext.LastIndexOf(' ') + 1, currentlen + 1);

                    string sl = richTextBox4.SelectedText;

                    listBox2.Show();

                    listBox2.Focus();



                    //int charpos = richTextBox4.SelectionStart;

                    //Point carpos = richTextBox4.GetPositionFromCharIndex(charpos);

                    int charpos =
                     curlin;
                    //richTextBox1.SelectionStart;

                    Point carpos = richTextBox4.GetPositionFromCharIndex(charpos);

                    listBox2.Location = carpos;

                    richTextBox4.ScrollToCaret();


                    listBox2.Location = carpos;
                    listBox2.Visible = true;
                    listBox2.SetSelected(0, true);
                }

                if (hidelistbox == true)
                {
                    richTextBox4.SelectionStart = richTextBox4.SelectionStart + currentlen;
                    hidelistbox = false;
                }

            }

            catch (Exception)
            {
                richTextBox4.Select(caretposition, 1);
                MessageBox.Show("Suggestions failed to initialise.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            autocomplete = false;
            autocompletebusy = false;





        }

        private void Lb_KeyDown3(object sender, KeyEventArgs e)
        {


            if (containsreturn == true)
            {
                addchar = " " + Environment.NewLine;
            }

            if (containsreturn == false)
            {
                addchar = " ";
            }



            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {

                if (e.KeyCode == Keys.Down)
                {
                    if (listBox2.SelectedIndex < (listBox2.Items.Count - 1))
                    {
                        listBox2.SelectedIndex++;
                    }

                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    if (listBox2.SelectedIndex > 0)
                    {
                        listBox2.SelectedIndex--;
                    }

                    e.Handled = true;
                }

            }




            if (e.KeyData == Keys.Enter)
            {

                richTextBox4.GetLineFromCharIndex(lineIndex);


                if (listBox2.SelectedIndex != -1)
                {
                    caretposition = curlin;

                    string beforetext = richTextBox4.Text.Substring(0, caretposition);

                    string beforetext2 = beforetext.Replace("\n", " ");

                    lastspacebeforetext = beforetext2.LastIndexOf(' ');

                    //string beforetext = richTextBox4.Text.Substring(0, caretposition);

                    //string beforetext2 = beforetext.Replace("\n", " ");

                    //lastspacebeforetext = beforetext2.LastIndexOf(' ');



                    if (listBox2.Visible == true)
                    {



                        richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                        richTextBox4.SelectionColor = Color.Black;

                        richTextBox4.SelectedText = listBox2.SelectedItem.ToString() + addchar;

                        autocomplete = false;

                        richTextBox4.Focus();



                    }

                    listBox2.Hide();
                    richTextBox4.SelectionStart = richTextBox4.SelectionStart - 1;


                    listBox2.Visible = false;

                    autocompletebusy = false;
                    autocomplete = false;

                    richTextBox4.DeselectAll();
                    richTextBox4.Refresh();
                }
            }


            if (e.KeyCode == Keys.Left && listBox2.SelectedItem is not null)
            {

                caretposition = curlin;

                string beforetext = richTextBox4.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');



                //string beforetext = richTextBox4.Text.Substring(0, caretposition);

                //string beforetext2 = beforetext.Replace("\n", " ");

                //lastspacebeforetext = beforetext2.LastIndexOf(' ');






                if (listBox2.Visible == true)
                {


                    richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

                    richTextBox4.SelectionColor = Color.Black;

                    string appendageleft = listBox2.SelectedItem.ToString().Split('.')[0];

                    richTextBox4.SelectedText = appendageleft + addchar;

                    autocomplete = false;

                    richTextBox4.Focus();

                    listBox2.Hide();
                    richTextBox4.SelectionStart = richTextBox4.SelectionStart - 1;

                    //richTextBox4.SelectionStart = caretposition;

                    richTextBox4.Focus();
                    richTextBox4.DeselectAll();
                    richTextBox4.Refresh();


                }
            }


            if (e.KeyCode == Keys.Right && listBox2.SelectedItem is not null)
            {
                caretposition = curlin;

                string beforetext = richTextBox4.Text.Substring(0, caretposition);

                string beforetext2 = beforetext.Replace("\n", " ");

                lastspacebeforetext = beforetext2.LastIndexOf(' ');

                //string beforetext = richTextBox4.Text.Substring(0, caretposition);

                //string beforetext2 = beforetext.Replace("\n", " ");

                //lastspacebeforetext = beforetext2.LastIndexOf(' ');

                //int lastcharacter = beforetext.Length - 1;
                //if (beforetext.Length > 0)

                //{
                //    if (beforetext.Substring(0, lastcharacter) == "\n")
                //    {
                //        newlineonened = true;
                //    }


                //    if (beforetext.Substring(0, lastcharacter) != "\n")
                //    {
                //        newlineonened = false;
                //    }

                //}

                //if (beforetext.Length == 0)
                //{
                //    newlineonened = true;

            

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

                    //string line = "\n";
                    //string noline = "";   

                    string appendageright = listBox2.SelectedItem.ToString().Split('.')[1];

                   
                        richTextBox4.SelectedText = appendageright + addchar;
                        newlineonened = false;
                    

                    //richTextBox4.SelectionStart = caretposition;

                    autocomplete = false;

                    richTextBox4.Focus();

                    listBox2.Hide();
                    richTextBox4.SelectionStart = richTextBox4.SelectionStart - 1;

                    //richTextBox4.SelectionStart = caretposition;

                    richTextBox4.Focus();
                    richTextBox4.DeselectAll();
                    richTextBox4.Refresh();




                }
            }




            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Escape)
            {
                listBox2.Hide();
                richTextBox4.SelectionStart = curlin;
                richTextBox4.DeselectAll();
                richTextBox4.Focus();
                richTextBox4.Refresh();

            }


        }


        private void lbhide(object sender, EventArgs e)
        {
            lb.Hide();

            if (caretreset == false)
            {
                richTextBox1.SelectionStart = curlin;
                caretreset = true;
            }
        }

        private void lb_click(object sender, EventArgs e)
        {

            //richTextBox1.GetLineFromCharIndex(lineIndex);


            //if (lb.SelectedIndex != -1)
            //{
            //    string beforetext = richTextBox1.Text.Substring(0, caretposition);

            //    string beforetext2 = beforetext.Replace("\n", " ");

            //    lastspacebeforetext = beforetext2.LastIndexOf(' ');



            //    if (lb.Visible == true)
            //    {



            //        richTextBox1.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

            //        richTextBox1.SelectionColor = Color.Black;

            //        richTextBox1.SelectedText = lb.SelectedItem.ToString() + " " + addchar;

            //        autocomplete = false;

            //        richTextBox1.Focus();



            //    }

            //    lb.Hide();

            //    lb.Visible = false;

            //    autocompletebusy = false;
            //    autocomplete = false;

            //    richTextBox1.DeselectAll();
            //    richTextBox1.Refresh();
            //}

        }



        private void lb_click2(object sender, EventArgs e)
        {

            //richTextBox2.GetLineFromCharIndex(lineIndex);


            //if (listBox1.SelectedIndex != -1)
            //{
            //    string beforetext = richTextBox2.Text.Substring(0, caretposition);

            //    string beforetext2 = beforetext.Replace("\n", " ");

            //    lastspacebeforetext = beforetext2.LastIndexOf(' ');



            //    if (listBox1.Visible == true)
            //    {



            //        richTextBox2.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

            //        richTextBox2.SelectionColor = Color.Black;

            //        richTextBox2.SelectedText = listBox1.SelectedItem.ToString() + " " + addchar;

            //        autocomplete = false;

            //        richTextBox2.Focus();



            //    }

            //    listBox1.Hide();

            //    listBox1.Visible = false;

            //    autocompletebusy = false;
            //    autocomplete = false;

            //    richTextBox2.DeselectAll();
            //    richTextBox2.Refresh();
            //}

        }


        private void lb_click3(object sender, EventArgs e)
        {

            //richTextBox4.GetLineFromCharIndex(lineIndex);


            //if (listBox2.SelectedIndex != -1)
            //{
            //    string beforetext = richTextBox4.Text.Substring(0, caretposition);

            //    string beforetext2 = beforetext.Replace("\n", " ");

            //    lastspacebeforetext = beforetext2.LastIndexOf(' ');



            //    if (listBox2.Visible == true)
            //    {



            //        richTextBox4.Select(lastspacebeforetext = beforetext2.LastIndexOf(' ') + 1, currentlen);

            //        richTextBox4.SelectionColor = Color.Black;

            //        richTextBox4.SelectedText = listBox2.SelectedItem.ToString() + " " + addchar;

            //        autocomplete = false;

            //        richTextBox4.Focus();



            //    }

            //    listBox2.Hide();

            //    listBox2.Visible = false;

            //    autocompletebusy = false;
            //    autocomplete = false;

            //    richTextBox4.DeselectAll();
            //    richTextBox4.Refresh();
            //}

        }

        void copyresultsRow(object sender, EventArgs e)

        {
            if (dta is not null && tabControl3.SelectedTab == tabPage9)

            {



                if (string.Equals(ctp, "ctp4"))
                {
                    if (dataGridView7.Rows.Count > 0)
                    {

                        DataTable dtc = ((DataTable)dataGridView7.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView7.DataSource).Clone(); //holding table with the same structure as above
                        DataTable dtd = ((DataTable)dataGridView7.DataSource).Clone(); //reverse-order table for the above


                        foreach (DataGridViewCell c in dataGridView7.SelectedCells)
                        {
                            int ind = c.RowIndex;
                            dataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView7.Rows[ind].Selected = true;
                        }



                        int numrows = dataGridView7.SelectedRows.Count;

                        int[] selectedrows = new int[numrows];

                        foreach (DataGridViewRow d in dataGridView7.SelectedRows)
                        {
                            int i = d.Index;
                            DataRow dd = dtc.Rows[i];
                            dtd.ImportRow(dd);
                        }

                        dtd.AcceptChanges();

                        string? newline = System.Environment.NewLine;
                        StringBuilder? clipboard_string = new StringBuilder();


                        for (int r = dtd.Rows.Count - 1; r >= 0; r--)
                        {
                            DataRow? row = dtd.Rows[r];
                            dtr.ImportRow(row);
                        }

                        dtr.AcceptChanges();


                        copyrows = string.Join(Environment.NewLine, dtd.Rows.OfType<DataRow>().Select(x => string.Join(",", x.ItemArray)));


                        clipboard_string.Append(copyrows);

                        //button3.Enabled = false;
                        //button3.Text = "Results Copied";



                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString());
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }
                    }
                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }





                dataGridView7.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }


            if (dta is not null && tabControl3.SelectedTab == tabPage10)

            {



                if (string.Equals(ctp, "ctp4"))
                {
                    if (dataGridView6.Rows.Count != 0)

                    {
                        DataTable dtc = ((DataTable)dataGridView6.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView6.DataSource).Clone(); //holding table with the same structure as above
                        DataTable dtd = ((DataTable)dataGridView6.DataSource).Clone(); //reverse-order table for the above


                        foreach (DataGridViewCell c in dataGridView6.SelectedCells)
                        {
                            int ind = c.RowIndex;
                            dataGridView6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView6.Rows[ind].Selected = true;
                        }



                        int numrows = dataGridView6.SelectedRows.Count;

                        int[] selectedrows = new int[numrows];

                        foreach (DataGridViewRow d in dataGridView6.SelectedRows)
                        {
                            int i = d.Index;
                            DataRow dd = dtc.Rows[i];
                            dtd.ImportRow(dd);
                        }

                        dtd.AcceptChanges();

                        string? newline = System.Environment.NewLine;
                        StringBuilder? clipboard_string = new StringBuilder();


                        for (int r = dtd.Rows.Count - 1; r >= 0; r--)
                        {
                            DataRow? row = dtd.Rows[r];
                            dtr.ImportRow(row);
                        }

                        dtr.AcceptChanges();


                        copyrows = string.Join(Environment.NewLine, dtd.Rows.OfType<DataRow>().Select(x => string.Join(",", x.ItemArray)));


                        clipboard_string.Append(copyrows);

                        //button3.Enabled = false;
                        //button3.Text = "Results Copied";



                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString());
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }
                    }
                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }





                dataGridView6.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }


            if (dta is not null && tabControl2.SelectedTab == tabPage5)

            {



                if (string.Equals(ctp, "ctp4"))
                {
                    if (dataGridView4.Rows.Count > 0)
                    {

                        DataTable dtc = ((DataTable)dataGridView4.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView4.DataSource).Clone(); //holding table with the same structure as above
                        DataTable dtd = ((DataTable)dataGridView4.DataSource).Clone(); //reverse-order table for the above


                        foreach (DataGridViewCell c in dataGridView4.SelectedCells)
                        {
                            int ind = c.RowIndex;
                            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView4.Rows[ind].Selected = true;
                        }



                        int numrows = dataGridView4.SelectedRows.Count;

                        int[] selectedrows = new int[numrows];

                        foreach (DataGridViewRow d in dataGridView4.SelectedRows)
                        {
                            int i = d.Index;
                            DataRow dd = dtc.Rows[i];
                            dtd.ImportRow(dd);
                        }

                        dtd.AcceptChanges();

                        string? newline = System.Environment.NewLine;
                        StringBuilder? clipboard_string = new StringBuilder();


                        for (int r = dtd.Rows.Count - 1; r >= 0; r--)
                        {
                            DataRow? row = dtd.Rows[r];
                            dtr.ImportRow(row);
                        }

                        dtr.AcceptChanges();


                        copyrows = string.Join(Environment.NewLine, dtd.Rows.OfType<DataRow>().Select(x => string.Join(",", x.ItemArray)));


                        clipboard_string.Append(copyrows);

                        //button3.Enabled = false;
                        //button3.Text = "Results Copied";



                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString());
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }
                    }
                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }





                dataGridView4.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }

            dataGridView7.SelectionMode = DataGridViewSelectionMode.CellSelect;


            dataGridView6.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }





        void copyresultsCell(object sender, EventArgs e)

        {

            if (dta is not null && tabControl3.SelectedTab == tabPage9)

            {
                if (string.Equals(ctp, "ctp4"))
                {
                    if (dataGridView7.Rows.Count > 0)
                    {
                        DataTable dtc = ((DataTable)dataGridView7.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView7.DataSource).Clone(); //holding table with the same structure as above
                        DataTable dtd = ((DataTable)dataGridView7.DataSource).Clone(); //reverse-order table for the above

                        int numcel = dataGridView7.SelectedCells.Count;

                        int[] selectedcells = new int[numcel];


                        StringBuilder? clipboard_string = new StringBuilder();

                        string[] hold = new string[numcel];

                        int num = 0;

                        foreach (DataGridViewCell d in dataGridView7.SelectedCells)
                        {

                            object? val = d.Value;
                            //var i = d.ColumnIndex;
                            //var j = d.RowIndex;

                            string? fullstring = string.Concat(val, ',');

                            hold[num] = fullstring;

                            num++;

                        }

                        string[] hold2 = new string[numcel];
                        hold2 = hold.Reverse().ToArray();

                        foreach (string s in hold2)
                        {
                            clipboard_string.Append(s);
                        }



                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString().Substring(0, clipboard_string.ToString().Length - 1));
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }
                    }
                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }

                dataGridView7.ClearSelection();
            }


            if (dta is not null && tabControl3.SelectedTab == tabPage10)

            {
                if (string.Equals(ctp, "ctp4"))
                {

                    if (dataGridView6.Rows.Count > 0)
                    {

                        DataTable dtc = ((DataTable)dataGridView6.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView6.DataSource).Clone(); //holding table with the same structure as above
                        DataTable dtd = ((DataTable)dataGridView6.DataSource).Clone(); //reverse-order table for the above

                        int numcel = dataGridView6.SelectedCells.Count;

                        int[] selectedcells = new int[numcel];


                        StringBuilder? clipboard_string = new StringBuilder();

                        string[] hold = new string[numcel];

                        int num = 0;

                        foreach (DataGridViewCell d in dataGridView6.SelectedCells)
                        {

                            object? val = d.Value;
                            //var i = d.ColumnIndex;
                            //var j = d.RowIndex;

                            string? fullstring = string.Concat(val, ',');

                            hold[num] = fullstring;

                            num++;

                        }

                        string[] hold2 = new string[numcel];
                        hold2 = hold.Reverse().ToArray();

                        foreach (string s in hold2)
                        {
                            clipboard_string.Append(s);
                        }



                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString().Substring(0, clipboard_string.ToString().Length - 1));
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }
                    }
                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }

                dataGridView6.ClearSelection();
            }


            if (dta is not null && tabControl2.SelectedTab == tabPage5)

            {
                if (string.Equals(ctp, "ctp4"))
                {
                    if (dataGridView4.Rows.Count > 0)
                    {

                        DataTable dtc = ((DataTable)dataGridView4.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView4.DataSource).Clone(); //holding table with the same structure as above
                        DataTable dtd = ((DataTable)dataGridView4.DataSource).Clone(); //reverse-order table for the above

                        int numcel = dataGridView4.SelectedCells.Count;

                        int[] selectedcells = new int[numcel];


                        StringBuilder? clipboard_string = new StringBuilder();

                        string[] hold = new string[numcel];

                        int num = 0;

                        foreach (DataGridViewCell d in dataGridView4.SelectedCells)
                        {

                            object? val = d.Value;
                            //var i = d.ColumnIndex;
                            //var j = d.RowIndex;

                            string? fullstring = string.Concat(val, ',');

                            hold[num] = fullstring;

                            num++;

                        }

                        string[] hold2 = new string[numcel];
                        hold2 = hold.Reverse().ToArray();

                        foreach (string s in hold2)
                        {
                            clipboard_string.Append(s);
                        }



                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString().Substring(0, clipboard_string.ToString().Length - 1));
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }
                    }
                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }

                dataGridView4.ClearSelection();
            }

            dataGridView7.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView6.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }


        void copyresultsColumn(object sender, EventArgs e)

        {



            if (dta is not null && tabControl3.SelectedTab == tabPage9)

            {
                if (string.Equals(ctp, "ctp4"))
                {

                    //DataTable dtc = new DataTable();
                    DataTable dtd = new DataTable();
                    //DataTable dtr = new DataTable();

                    int rowcount = dataGridView7.Rows.Count;
                    int columncount = dataGridView7.Columns.Count;
                    int[] selectedrows = new int[rowcount];
                    int[] allcolumns = new int[columncount];
                    int[] selectedcolumns = new int[1000];

                    if (dataGridView7.Rows.Count > 0)
                    {

                        DataTable dtc = ((DataTable)dataGridView7.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView7.DataSource).Clone(); //holding table with the same structure as above

                        List<int> ts = new List<int>();
                        List<int> tr = new List<int>();
                        List<string> allcolnames = new List<string>();
                        List<string> colnames = new List<string>();



                        foreach (DataGridViewCell c in dataGridView7.SelectedCells)
                        {
                            int ind = c.ColumnIndex;
                            string name = dtc.Columns[ind].ColumnName;

                            colnames.Add(name);
                        }


                        foreach (DataGridViewColumn dc in dataGridView7.SelectedColumns)
                        {
                            int id = dc.Index;
                            string s = dtc.Columns[id].ColumnName;
                            colnames.Add(s);
                        }


                        foreach (DataGridViewColumn dcs in dataGridView7.Columns)
                        {
                            int ids = dcs.Index;
                            string t = dcs.Name;
                            allcolnames.Add(t);
                        }




                        List<string> colnamestodelete = allcolnames.Except(colnames).ToList();

                        foreach (string s in colnamestodelete)
                        {
                            dtc.Columns.RemoveAt(dtc.Columns.IndexOf(s));
                        }

                        dtc.AcceptChanges();


                        copyrows = string.Join(Environment.NewLine, dtc.Rows.OfType<DataRow>().Select(x => string.Join(",", x.ItemArray)));

                        StringBuilder? clipboard_string = new StringBuilder();



                        clipboard_string.Append(copyrows);


                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString());
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }

                    }

                    if (!(string.Equals(ctp, "ctp4")))
                    {
                        return;
                    }

                }
            }

            if (dta is not null && tabControl3.SelectedTab == tabPage10)

            {
                if (string.Equals(ctp, "ctp4"))
                {

                    //DataTable dtc = new DataTable();
                    DataTable dtd = new DataTable();
                    //DataTable dtr = new DataTable();

                    int rowcount = dataGridView6.Rows.Count;
                    int columncount = dataGridView6.Columns.Count;
                    int[] selectedrows = new int[rowcount];
                    int[] allcolumns = new int[columncount];
                    int[] selectedcolumns = new int[1000];

                    if (dataGridView6.Columns.Count > 0)
                    {

                        DataTable dtc = ((DataTable)dataGridView6.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView6.DataSource).Clone(); //holding table with the same structure as above

                        List<int> ts = new List<int>();
                        List<int> tr = new List<int>();
                        List<string> allcolnames = new List<string>();
                        List<string> colnames = new List<string>();



                        foreach (DataGridViewCell c in dataGridView6.SelectedCells)
                        {
                            int ind = c.ColumnIndex;
                            string name = dtc.Columns[ind].ColumnName;

                            colnames.Add(name);
                        }


                        foreach (DataGridViewColumn dc in dataGridView6.SelectedColumns)
                        {
                            int id = dc.Index;
                            string s = dtc.Columns[id].ColumnName;
                            colnames.Add(s);
                        }


                        foreach (DataGridViewColumn dcs in dataGridView6.Columns)
                        {
                            int ids = dcs.Index;
                            string t = dcs.Name;
                            allcolnames.Add(t);
                        }




                        List<string> colnamestodelete = allcolnames.Except(colnames).ToList();

                        foreach (string s in colnamestodelete)
                        {
                            dtc.Columns.RemoveAt(dtc.Columns.IndexOf(s));
                        }

                        dtc.AcceptChanges();


                        copyrows = string.Join(Environment.NewLine, dtc.Rows.OfType<DataRow>().Select(x => string.Join(",", x.ItemArray)));

                        StringBuilder? clipboard_string = new StringBuilder();



                        clipboard_string.Append(copyrows);


                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString());
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }
                    }
                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }


            }

            if (dta is not null && tabControl2.SelectedTab == tabPage5)

            {
                if (string.Equals(ctp, "ctp4"))
                {

                    //DataTable dtc = new DataTable();
                    DataTable dtd = new DataTable();
                    //DataTable dtr = new DataTable();

                    int rowcount = dataGridView4.Rows.Count;
                    int columncount = dataGridView4.Columns.Count;
                    int[] selectedrows = new int[rowcount];
                    int[] allcolumns = new int[columncount];
                    int[] selectedcolumns = new int[1000];

                    if (dataGridView4.Rows.Count > 0)
                    {

                        DataTable dtc = ((DataTable)dataGridView4.DataSource).Copy(); //original copy of datagridview data
                        DataTable dtr = ((DataTable)dataGridView4.DataSource).Clone(); //holding table with the same structure as above

                        List<int> ts = new List<int>();
                        List<int> tr = new List<int>();
                        List<string> allcolnames = new List<string>();
                        List<string> colnames = new List<string>();



                        foreach (DataGridViewCell c in dataGridView4.SelectedCells)
                        {
                            int ind = c.ColumnIndex;
                            string name = dtc.Columns[ind].ColumnName;

                            colnames.Add(name);
                        }


                        foreach (DataGridViewColumn dc in dataGridView4.SelectedColumns)
                        {
                            int id = dc.Index;
                            string s = dtc.Columns[id].ColumnName;
                            colnames.Add(s);
                        }


                        foreach (DataGridViewColumn dcs in dataGridView4.Columns)
                        {
                            int ids = dcs.Index;
                            string t = dcs.Name;
                            allcolnames.Add(t);
                        }




                        List<string> colnamestodelete = allcolnames.Except(colnames).ToList();

                        foreach (string s in colnamestodelete)
                        {
                            dtc.Columns.RemoveAt(dtc.Columns.IndexOf(s));
                        }

                        dtc.AcceptChanges();


                        copyrows = string.Join(Environment.NewLine, dtc.Rows.OfType<DataRow>().Select(x => string.Join(",", x.ItemArray)));

                        StringBuilder? clipboard_string = new StringBuilder();



                        clipboard_string.Append(copyrows);


                        if (clipboard_string.Length > 0)
                        {
                            Clipboard.SetText(clipboard_string.ToString());
                        }

                        if (clipboard_string == null)
                        {
                            return;
                        }



                        if (dta == null)
                        {
                            return;
                        }
                    }
                }

                if (!(string.Equals(ctp, "ctp4")))
                {
                    return;
                }


            }



            dataGridView7.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView6.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.CellSelect;


        }

        void safesqlexceptionhandler(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {

                dataGridView6.Rows.Clear();
                dataGridView7.Rows.Clear();

                string? errorrepl = "";

                if (errormessage is not null)
                {
                    changederror = errormessage.Replace("Incorrect syntax near the keyword 'Rollback'.", "An error occurred - please check your query and syntax.");
                }

                if (errormessage is null)
                {
                    changederror = "";
                }


                textBox9.Visible = true;
                textBox9.Text = errorrepl;
                textBox10.Visible = true;
                textBox10.Text = errorrepl;
                //groupBox11.Text = "Error";
                //groupBox12.Text = "Error";



                datacleared = false;
                dataGridView6.Visible = false;
                dataGridView7.Visible = false;



            });
        }

        private void ClearClipboard(object sender, EventArgs e)
        {
            Clipboard.Clear();
            button6.Enabled = false;

            //if (dataGridView3.Rows.Count > 0 && dataGridView3.Visible == true)
            //{ 
            //     button7.Enabled = true;
            //     button7.Text = "Search Term History to Clipboard";
            //}

            //if (dataGridView3.Rows.Count < 1 || dataGridView3.Visible == false)
            //{
            button7.Enabled = false;
            checkBox2.Enabled = false;
            checkBox2.BackColor = Color.Transparent;
            button7.Text = "Results to Clipboard";
            //}

        }

        private void SelectDistinctValues(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {

                int colindex = new int();
                int tabindex = new int();

                if (dataGridView1.Columns[0].Name == "Column Name")
                {
                    colindex = 0;
                    tabindex = 1;
                }
                if (dataGridView1.Columns[1].Name == "Column Name")
                {
                    colindex = 1;
                    tabindex = 0;
                }
                object? holding = dataGridView1.SelectedCells[colindex].Value;
                object? holding2 = dataGridView1.SelectedCells[tabindex].Value;
                if (holding != null)
                {

                    richTextBox1.Text = ("select distinct(" + holding.ToString() + ") from " + holding2.ToString());
                    tabControl1.SelectedIndex = 4;
                    tabControl2.SelectedIndex = 0;
                    richTextBox1_KeyDowns(sender, e);

                }
            }

            else
            {
                return;
            }
        }

        private void SelectAllForTable(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {


                int tabindex = new int();

                if (dataGridView1.Columns[0].Name == "Column Name")
                {

                    tabindex = 1;
                }
                if (dataGridView1.Columns[1].Name == "Column Name")
                {

                    tabindex = 0;
                }
                object? holding2 = dataGridView1.SelectedCells[tabindex].Value;
                if (holding2 != null)
                {

                    richTextBox1.Text = ("select * from " + holding2.ToString());
                    tabControl1.SelectedIndex = 4;
                    tabControl2.SelectedIndex = 0;
                    richTextBox1_KeyDowns(sender, e);

                }
            }

            else
            {
                return;
            }
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Sorted(object sender, EventArgs e)


        {


            int keytype = dataGridView1.Columns.IndexOf(dataGridView1.Columns["Constraint Type"]);
            int datatype = dataGridView1.Columns.IndexOf(dataGridView1.Columns["Data Type"]);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().Replace(" (Primary Key)", "");

                row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().Replace(" (Foreign Key)", "");

                row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().ToUpper();

                string? chk = row.Cells[keytype].Value.ToString();

                if (chk == "Primary Key")
                {
                    row.DefaultCellStyle.BackColor = SystemColors.ControlDark;
                    row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().ToUpper() + " (Primary Key)";
                }

                if (row.Cells[keytype].Value.ToString() == "Foreign Key")
                {
                    row.DefaultCellStyle.BackColor = SystemColors.ControlLight;
                    row.Cells[datatype].Value = row.Cells[datatype].Value.ToString().ToUpper() + " (Foreign Key)";
                }
            }



            dataGridView1.Columns[keytype].Visible = false;
            dataGridView1.Columns[datatype].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }


        async void startAsyncButton_DefClick(object sender, EventArgs e)
        {
            //button3.Enabled = false;
            //button4.Enabled = false;
            //button1.Enabled = false;
            //textBox16.Visible = true;
            //button1.Enabled = false;
            //button2.Enabled = false;
            //button8.Enabled = false;
            //button9.Enabled = false;
            //button10.Enabled = false;
            //this.label17.Location = new System.Drawing.Point(127, 111);
            label17.Text = "Not Connected";
            label17.TextAlign = ContentAlignment.TopRight;
            label17.ForeColor = System.Drawing.Color.Black;
            if (lowmemorymode == true)
            {
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView2.ColumnHeadersVisible = false;
                dataGridView3.ColumnHeadersVisible = false;
                dataGridView4.ColumnHeadersVisible = false;
                dataGridView5.ColumnHeadersVisible = false;
                dataGridView6.ColumnHeadersVisible = false;
                dataGridView7.ColumnHeadersVisible = false;
                dataGridView8.ColumnHeadersVisible = false;
            }
            //CopyCell.Enabled = false;
            //CopyColumn.Enabled = false;
            //CopyRow.Enabled = false;
            button9.Text = "Results to Clipboard";

            sqlcomm = "";
            endpressed = false;

            if (dta != null)
            {
                dta.Clear();
            }


            if (busy == true)
            {
                workerbusy(sender, e);
                return;
            }

            if (busy != true)
            {
                try
                {
                    backgroundWorker7.RunWorkerAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }



        }


        private void backgroundWorker7_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                {
                  
                        if (dta is not null)
                        {
                            dta.Clear();
                        }

                        if (dta2 is not null)
                        {
                            dta2.Clear();
                        }

                        dta = null;
                        dta2 = null;
                    


                    BeginInvoke((MethodInvoker)delegate
                    {

                        if (lowmemorymode == true)
                        {
                            dataGridView1.DataSource = null;
                            dataGridView2.DataSource = null;
                            dataGridView3.DataSource = null;
                            dataGridView4.DataSource = null;
                            dataGridView5.DataSource = null;
                            dataGridView6.DataSource = null;
                            dataGridView7.DataSource = null;
                            dataGridView8.DataSource = null;
                        }
                        Text = "SQL Tools - WORKING...";
                        button8.Enabled = false;    
                    });

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
                            SqlConnection cmd = new SqlConnection(connex);

                            if (definitionmode == "Name")
                            {

                                BeginInvoke((MethodInvoker)delegate
                                {
                                    copyalldefnames.Enabled = false;

                                });
                                if (textBox15.Text == "")
                                {


                                    if (radioButton16.Checked == true)

                                    {
                                        definitionsearch = "and v.type in ('IF', 'P', 'AF', 'TR', 'TF', 'V', 'X', 'U', 'FN')";
                                    }

                                    if (radioButton10.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'AF'";
                                    }

                                    if (radioButton15.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'X'";
                                    }

                                    if (radioButton11.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'IF'";
                                    }

                                    if (radioButton12.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'P'";
                                    }

                                    if (radioButton13.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TF'";
                                    }

                                    if (radioButton9.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TR'";
                                    }

                                    if (radioButton8.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'U'";
                                    }

                                    if (radioButton14.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'V'";
                                    }

                                    if (radioButton17.Checked == true)
                                    {
                                        definitionsearch = "and v.type = 'FN'";
                                    }
                                }


                                if (textBox15.Text != "" && radioButton6.Checked == true)
                                {


                                    if (radioButton16.Checked == true)

                                    {
                                        definitionsearch = "and v.type in ('IF', 'P', 'AF', 'TR', 'TF', 'V', 'X', 'U', 'FN') and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton10.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'AF' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton15.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'X' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton11.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'IF' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton12.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'P' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton13.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TF' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton9.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TR' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton8.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'U' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton14.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'V' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton17.Checked == true)
                                    {
                                        definitionsearch = "and v.type = 'FN' and v.[name] = '" + textBox15.Text + "'";
                                    }

                                }

                                if (textBox15.Text != "" && radioButton7.Checked == true)
                                {


                                    if (radioButton16.Checked == true)

                                    {
                                        definitionsearch = "and v.type in ('IF', 'P', 'AF', 'TR', 'TF', 'V', 'X', 'U', 'FN') and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton10.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'AF' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton15.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'X' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton11.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'IF' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton12.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'P' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton13.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TF' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton9.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TR' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton8.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'U' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton14.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'V' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton17.Checked == true)
                                    {
                                        definitionsearch = "and v.type = 'FN' and v.[name] like '%" + textBox15.Text + "%'";
                                    }

                                }
                            }

                            if (definitionmode == "Definition")
                            {
                                BeginInvoke((MethodInvoker)delegate
                                {

                                    copyalldefnames.Enabled = true;

                                    lastdefinitionsearched = textBox15.Text;

                                });

                                if (textBox15.Text == "")
                                {


                                    if (radioButton16.Checked == true)

                                    {
                                        definitionsearch = "and v.type in ('IF', 'P', 'AF', 'TR', 'TF', 'V', 'X', 'U', 'FN')";
                                    }

                                    if (radioButton10.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'AF'";
                                    }

                                    if (radioButton15.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'X'";
                                    }

                                    if (radioButton11.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'IF'";
                                    }

                                    if (radioButton12.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'P'";
                                    }

                                    if (radioButton13.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TF'";
                                    }

                                    if (radioButton9.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TR'";
                                    }

                                    if (radioButton8.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'U'";
                                    }

                                    if (radioButton14.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'V'";
                                    }

                                    if (radioButton17.Checked == true)
                                    {
                                        definitionsearch = "and v.type = 'FN'";
                                    }
                                }


                                if (textBox15.Text != "" && radioButton6.Checked == true)
                                {


                                    if (radioButton16.Checked == true)

                                    {
                                        definitionsearch = "and v.type in ('IF', 'P', 'AF', 'TR', 'TF', 'V', 'X', 'U', 'FN') and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton10.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'AF' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton15.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'X' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton11.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'IF' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton12.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'P' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton13.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TF' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton9.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TR' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton8.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'U' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton14.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'V' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                    if (radioButton17.Checked == true)
                                    {
                                        definitionsearch = "and v.type = 'FN' and s.[definition] = '" + textBox15.Text + "'";
                                    }

                                }

                                if (textBox15.Text != "" && radioButton7.Checked == true)
                                {


                                    if (radioButton16.Checked == true)

                                    {
                                        definitionsearch = "and v.type in ('IF', 'P', 'AF', 'TR', 'TF', 'V', 'X', 'U', 'FN') and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton10.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'AF' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton15.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'X' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton11.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'IF' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton12.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'P' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton13.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TF' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton9.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'TR' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton8.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'U' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton14.Checked == true)

                                    {
                                        definitionsearch = "and v.type = 'V' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                    if (radioButton17.Checked == true)
                                    {
                                        definitionsearch = "and v.type = 'FN' and s.[definition] like '%" + textBox15.Text + "%'";
                                    }

                                }
                            }

                            try
                            {


                                sqlcomm = sql9 + definitionsearch + sql10;

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
                                        ////this.label17.Location = new System.Drawing.Point(288, 112);
                                        label17.ForeColor = System.Drawing.Color.DarkGreen;
                                        textBox16.Visible = true;
                                        textBox16.Text = "Working...";
                                    }
                                 );


                                    if (cmd == null)

                                    {
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            label17.Text = "Connection Failed";
                                            ////this.label17.Location = new System.Drawing.Point(288, 112);
                                            label17.ForeColor = System.Drawing.Color.DarkRed;
                                        }
                                     );

                                    }

                                }
                                adapter.SelectCommand = cmd1;
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);

                                int ind = ds.Columns.IndexOf("RowVersion");
                                if (ind != -1)
                                {
                                    ds.Columns.RemoveAt(ind);
                                }

                                int ind2 = ds.Columns.IndexOf("TimeStamp");
                                if (ind2 != -1)
                                {
                                    ds.Columns.RemoveAt(ind2);
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
                                {
                                    return;
                                }

                                {



                                    string msg = ex.Message;

                                    if (msg.Contains("Incorrect syntax"))

                                    {
                                        MessageBox.Show("There is an issue with your syntax - please remove any disallowed SQL characters." + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                    }

                                    else
                                    {
                                        MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                    }
                                }
                            }
                            finally
                            {
                                cmd.Close();
                            }


                        }
                        catch (Exception ex)
                        {
                            string msg = //"Please enter valid connection details.";
                                ex.ToString();
                            MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                }
                return;
            }
        }


        void backgroundWorker7_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            textBox16.Visible = true;
            textBox16.Text = "Working...";
            button8.Enabled = false;
        }


        async void backgroundWorker7_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            {

                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        Text = "SQL Tools";
                    });


                    ctp = "ctp1";
                    //button3.Enabled = true;
                    //button3.Text = "Results to Clipboard";
                    //textBox16.Visible = false;
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    button8.Enabled = true;
                    ctp = "ctp1";


                    SqlConnection cmd = new SqlConnection();
                    cmd.Close();
                    if (dta != null && dta.Rows.Count > 0)
                    {
                        contextMenuStrip1.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        toolStripMenuItem9.Enabled = true;
                        toolStripMenuItem10.Enabled = true;
                        toolStripMenuItem11.Enabled = true;
                        toolStripMenuItem12.Enabled = true;
                        contextMenuStrip1.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        toolStripMenuItem9.Enabled = true;
                        toolStripMenuItem10.Enabled = true;
                        toolStripMenuItem11.Enabled = true;
                        toolStripMenuItem12.Enabled = true;
                        contextMenuStrip2.Enabled = true;
                        toolStripMenuItem2.Enabled = true;
                        contextMenuStrip3.Enabled = true;
                        toolStripMenuItem3.Enabled = true;
                        dta = dta.Copy();

                        if (lowmemorymode == false)
                        {
                            dtm8 = dta.Copy();

                        }

                        if (lowmemorymode == false)
                        {
                            dataGridView8.DataSource = dtm8;
                        }

                        if (lowmemorymode == true)
                        {
                            dataGridView8.DataSource = dta;
                        }


                        dataGridView8.ColumnHeadersVisible = true;
                        textBox16.Visible = false;
                        textBox16.Text = "";
                        button9.Enabled = true;




                        if (dta.Rows.Count < 1)
                        {
                            //textBox16.Visible = false;
                        }
                    }

                    if (dta is null || dta.Rows.Count == 0)
                    {
                        textBox16.Visible = true;
                        textBox16.Text = "No Results.";
                        dataGridView8.ColumnHeadersVisible = false;
                        //button3.Enabled = false;
                        button9.Enabled = false;
                        button10.Enabled = false;
                    }

                    if (textBox16.Text == "Working..." || textBox16.Text != "")
                    {
                        //this.datagridview8.ColumnHeadersVisible = false;
                        //button3.Enabled = false;
                        button9.Enabled = false;
                        button10.Enabled = false;
                        //    contextMenuStrip1.Enabled = false;
                        //    toolStripMenuItem9.Enabled = false;
                        //    toolStripMenuItem10.Enabled = false;
                        //    toolStripMenuItem1.Enabled = false;
                        //    toolStripMenuItem10.Enabled = false;
                        //    toolStripMenuItem11.Enabled = false;
                        //    toolStripMenuItem12.Enabled = false;
                        //    contextMenuStrip2.Enabled = false;
                        //    toolStripMenuItem2.Enabled = false;
                    }

                }
            }

            busy = false;
            button8.Enabled = true;
        }

        private void checkdef(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)// && definitionmode == "Name")
            {
                button8.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void DefToClipboard(object sender, EventArgs e)
        {

            button9.Enabled = false;
            button10.Enabled = true;
            button9.Text = "Copied to Clipboard";


            int coldef = dataGridView8.Columns["Definition"].Index;
            int coltype = dataGridView8.Columns["Type"].Index;
            int colname = dataGridView8.Columns["Name"].Index;
            int row = dataGridView8.CurrentRow.Index;


            string? defvalue = dataGridView8.Rows[row].Cells[coldef].Value.ToString();
            string? namevalue = dataGridView8.Rows[row].Cells[colname].Value.ToString();
            string? typevalue = dataGridView8.Rows[row].Cells[coltype].Value.ToString();

            string topaste = namevalue.ToUpper() + " - " + typevalue + Environment.NewLine + "------------" + Environment.NewLine + defvalue + Environment.NewLine + "------------";
            Clipboard.SetText(topaste);

        }


        private void DefCopyOut(object sender, EventArgs e)
        {

            button9.Enabled = false;
            button10.Enabled = true;
            button9.Text = "Copied to Clipboard";


            int coldef = dataGridView8.Columns["Definition"].Index;
            int coltype = dataGridView8.Columns["Type"].Index;
            int colname = dataGridView8.Columns["Name"].Index;
            int row = dataGridView8.CurrentRow.Index;


            string? defvalue = dataGridView8.Rows[row].Cells[coldef].Value.ToString();
            string? namevalue = dataGridView8.Rows[row].Cells[colname].Value.ToString();
            string? typevalue = dataGridView8.Rows[row].Cells[coltype].Value.ToString();

            string topaste = namevalue + "," + typevalue + "," + defvalue;
            Clipboard.SetText(topaste);

        }

        private void ClearDefClipboard(object sender, EventArgs e)
        {
            ClearClipboard(sender, e);
            button10.Enabled = false;
            button9.Enabled = true;
            button9.Text = "Results to Clipboard";
        }

        private void TabChangeWarnings(object sender, EventArgs e)
        {
            if (lowmemorymode == true)
            {


                if (tooltipshown == false)
                {

                    MessageBox.Show("'Low Memory Mode' is enabled. Therefore, switching to a new tab will clear any results from other tabs." + Environment.NewLine + "Switching tabs won't stop any queries from running in the current tab.", "Before switching tabs...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tooltipshown = true;

                }

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {


        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {


        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {
            //here
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton18.Checked == true)
            {
                definitionmode = "Name";
                //textBox15.Multiline = false;
            }

            if (radioButton19.Checked == true)
            {
                definitionmode = "Definition";
                //textBox15.Multiline = true;
            }
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            radioButton19_CheckedChanged(sender, e);
        }

        private void CopDefinitionList(object sender, EventArgs e)
        {
            string s = "Definition searched:" + Environment.NewLine + "'" + lastdefinitionsearched + "'" + Environment.NewLine + Environment.NewLine + "Results:" + Environment.NewLine;

            int coldef = dataGridView8.Columns["Name"].Index;

            foreach (DataGridViewRow dr in dataGridView8.Rows)
            {
                s += dr.Cells[coldef].Value + Environment.NewLine;
            }

            Clipboard.SetText(s);

            button9.Enabled = false;
            button10.Enabled = true;
            button9.Text = "Copied to Clipboard";
        }

        private void CopyDefResults(object sender, EventArgs e)
        {
            string s = "";

            int name = dataGridView8.Columns["Name"].Index;
            int def = dataGridView8.Columns["Definition"].Index;
            int type = dataGridView8.Columns["Type"].Index;

            foreach (DataGridViewRow dr in dataGridView8.Rows)
            {
                s += dr.Cells[name].Value + "," + dr.Cells[type].Value + "," + dr.Cells[def].Value + Environment.NewLine + Environment.NewLine;
            }

            s = s.ToString().Substring(0, s.Length - 1);

            Clipboard.SetText(s);

            button9.Enabled = false;
            button10.Enabled = true;
            button9.Text = "Copied to Clipboard";
        }





        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.BackColor = Color.LightGreen;
                checkBox2.Text = "Including SQL";
            }

            if (checkBox2.Checked == false)
            {
                checkBox2.BackColor = Color.IndianRed;
                checkBox2.Text = "Excluding SQL";
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = true;
            }

            if (checkBox1.Checked == false)
            {
                comboBox1.Enabled = false;
            }
        }


        private void backgroundWorker8_DoWork(object? sender, DoWorkEventArgs e)
        {
            {
              
                    if (dta is not null)
                    {
                        dta.Clear();
                    }

                    if (dta2 is not null)
                    {
                        dta2.Clear();
                    }

                    dta = null;
                    dta2 = null;
                


                if (tablenames is not null)
                {
                    tablenames.Clear();
                }

                //tablenames = null;

                BeginInvoke((MethodInvoker)delegate
                {

                    Text = "SQL Tools - WORKING...";
                });

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
                        SqlConnection cmd = new SqlConnection(connex);


                        try
                        {


                            sqlcomm = "select distinct(c.TABLE_NAME) from INFORMATION_SCHEMA.COLUMNS c";

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
                                    ////this.label17.Location = new System.Drawing.Point(288, 112);
                                    label17.ForeColor = System.Drawing.Color.DarkGreen;
                                    //textBox16.Visible = true;
                                    //textBox16.Text = "Working...";
                                }
                             );


                                if (cmd == null)

                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        label17.Text = "Connection Failed";
                                        ////this.label17.Location = new System.Drawing.Point(288, 112);
                                        label17.ForeColor = System.Drawing.Color.DarkRed;
                                    }
                                 );

                                }

                            }
                            adapter.SelectCommand = cmd1;
                            DataTable ds = new DataTable();
                            adapter.Fill(ds);

                            int ind = ds.Columns.IndexOf("RowVersion");
                            if (ind != -1)
                            {
                                ds.Columns.RemoveAt(ind);
                            }

                            int ind2 = ds.Columns.IndexOf("TimeStamp");
                            if (ind2 != -1)
                            {
                                ds.Columns.RemoveAt(ind2);
                            }



                            //

                            {
                                foreach (DataRow dr in ds.Rows)
                                {
                                    string? a = dr["Table_Name"].ToString();
                                    tablenames = dr.Table;
                                    //tablenames.Columns.Add("TableName");
                                    //tablenames.Rows.Add(a);
                                    tablenames.AcceptChanges();
                                }



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
                            return;



                        }

                        catch (Exception ex)

                        {

                            if (worker.CancellationPending == true)
                            {
                                return;
                            }

                            {



                                string msg = ex.Message;

                                if (msg.Contains("Incorrect syntax"))

                                {
                                    MessageBox.Show("There is an issue with your syntax - please remove any disallowed SQL characters." + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                }

                                else
                                {
                                    MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "(This error was returned when attempting to connect to the database and run the underlying query used to fetch the results. If this is a syntax error, you may have included SQL-specific characters in your search terms.)", "Please check your details", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                                }
                            }
                        }
                        finally
                        {
                            cmd.Close();
                        }


                    }
                    catch (Exception ex)
                    {
                        string msg = //"Please enter valid connection details.";
                            ex.ToString();
                        MessageBox.Show(msg, "Please check your details.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
            return;

        }


        private void backgroundWorker8_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    Text = "SQL Tools";
                });


                ctp = "ctp1";
                //button3.Enabled = true;
                //button3.Text = "Results to Clipboard";
                //textBox16.Visible = false;
                button2.Enabled = true;
                button1.Enabled = true;
                button4.Enabled = true;
                button8.Enabled = true;
                ctp = "ctp1";


                SqlConnection cmd = new SqlConnection();
                cmd.Close();
                if (tablenames != null && tablenames.Rows.Count > 0)
                {

                    tablenames = tablenames.Copy();
                    tablenames.AcceptChanges();

                    List<string> tables = new List<string>();

                    foreach (DataRow row in tablenames.Rows)
                    {

                        DataRow? val = row;

                        string? a = row[0].ToString();

                        tables.Add(a);
                    }

                    comboBox1.DataSource = tables.ToArray();


                    if (tablenames.Rows.Count < 1)
                    {
                        //textBox16.Visible = false;
                    }
                }

                if (tablenames is null || tablenames.Rows.Count == 0)
                {
                    string nr = "No Tables Retrieved";

                    comboBox1.Items.Add(nr);
                }



            }

            busy = false;
        }


        private void ComboClick(object sender, EventArgs e)

        { 
            if (comboxsel > 0)
            {
                comboBox1.SelectedIndex = comboxsel;
            }

            if (comboBox1.SelectedItem != null)
            {
                tablelimit = comboBox1.SelectedItem.ToString();
                //comboxsel = comboBox1.SelectedIndex;
                comboBox1.SelectedItem = comboBox1.Items[comboxsel];
            }

         

            if (backgroundWorker8.IsBusy == true)
            {
                workerbusy(sender, e);
            }

            if (backgroundWorker8.IsBusy == false)
            {
                backgroundWorker8.RunWorkerAsync();
            }
        }

        private void Check1Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                comboBox1.Enabled = false;

            }


            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = true;

            }
        }

        private void ignorespacert1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                richTextBox1_KeyDown(sender, e);
            }
        }


        private void ignorespacert2(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Decimal)
            {
                richTextBox2_KeyDown2(sender, e);
            }

        }

        private void ignorespacert4(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Decimal)
            {
                richTextBox4_KeyDown3(sender, e);
            }

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {


            if (dataGridView3.RowCount > 0)
            {
                int rowindex = dataGridView3.CurrentCell.RowIndex;
                int colindex = dataGridView3.Columns.IndexOf(dataGridView3.Columns["Referenced Table"]);
                string? holding = dataGridView3.Rows[rowindex].Cells[colindex].Value.ToString();
                if (holding != null)
                {

                    tabControl1.SelectedIndex = 0;
                    textBox5.Text = holding.ToString();
                    tabControl1.SelectedIndex = 0;
                    radioButton3.Checked = true;
                    radioButton6.Checked = true;
                    Set_Search_Table(sender, e);
                    passtobgworker(sender, e);
                    actualclick = true;
                }

                else
                {
                    return;
                }
            }

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                int rowindex = dataGridView3.CurrentCell.RowIndex;
                int colindex = dataGridView3.Columns.IndexOf(dataGridView3.Columns["Referencing Table"]);
                string? holding = dataGridView3.Rows[rowindex].Cells[colindex].Value.ToString();
                if (holding != null)
                {

                    tabControl1.SelectedIndex = 0;
                    textBox5.Text = holding.ToString();
                    tabControl1.SelectedIndex = 0;
                    radioButton3.Checked = true;
                    radioButton6.Checked = true;
                    Set_Search_Table(sender, e);
                    passtobgworker(sender, e);
                    actualclick = true;
                }

                else
                {
                    return;
                }
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                int rowindex = dataGridView3.CurrentCell.RowIndex;
                int colindex = dataGridView3.Columns.IndexOf(dataGridView3.Columns["Referenced Column"]);
                string? holding = dataGridView3.Rows[rowindex].Cells[colindex].Value.ToString();
                if (holding != null)
                {

                    tabControl1.SelectedIndex = 0;
                    textBox6.Text = holding.ToString();
                    tabControl1.SelectedIndex = 0;
                    radioButton4.Checked = true;
                    radioButton6.Checked = true;
                    Set_Search_Table(sender, e);
                    passtobgworker(sender, e);
                    actualclick = true;
                }

                else
                {
                    return;
                }
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                int rowindex = dataGridView3.CurrentCell.RowIndex;
                int colindex = dataGridView3.Columns.IndexOf(dataGridView3.Columns["Referencing Column"]);
                string? holding = dataGridView3.Rows[rowindex].Cells[colindex].Value.ToString();
                if (holding != null)
                {

                    tabControl1.SelectedIndex = 0;
                    textBox6.Text = holding.ToString();
                    tabControl1.SelectedIndex = 0;
                    radioButton4.Checked = true;
                    radioButton6.Checked = true;
                    Set_Search_Table(sender, e);
                    passtobgworker(sender, e);
                    actualclick = true;
                }

                else
                {
                    return;
                }
            }
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "[No Search Term Entered]")
            {
                textBox6.Clear();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }




        //private void button11_InitialClick(object sender, EventArgs e)

        //{ 
        //button11_Click(sender, e);
        //button11_Click(sender, e);
        //}

        //private void button11_Click(object sender, EventArgs e)

        //{


        //    string[]? procwords = new string[300];
        //    procwords[1] = "ABSOLUTE";
        //    procwords[2] = "EXEC";
        //    procwords[3] = "OVERLAPS";
        //    procwords[4] = "ACTION";
        //    procwords[5] = "EXECUTE";
        //    procwords[6] = "PAD";
        //    procwords[7] = "ADA";
        //    procwords[8] = "EXISTS";
        //    procwords[9] = "PARTIAL";
        //    procwords[10] = "ADD";
        //    procwords[11] = "EXTERNAL";
        //    procwords[12] = "PASCAL";
        //    procwords[13] = "ALL";
        //    procwords[14] = "EXTRACT";
        //    procwords[15] = "POSITION";
        //    procwords[16] = "ALLOCATE";
        //    procwords[17] = "FALSE";
        //    procwords[18] = "PRECISION";
        //    procwords[19] = "ALTER";
        //    procwords[20] = "FETCH";
        //    procwords[21] = "PREPARE";
        //    procwords[22] = "AND";
        //    procwords[23] = "FIRST";
        //    procwords[24] = "PRESERVE";
        //    procwords[25] = "ANY";
        //    procwords[26] = "FLOAT";
        //    procwords[27] = "PRIMARY";
        //    procwords[28] = "ARE";
        //    procwords[29] = "FOR";
        //    procwords[30] = "PRIOR";
        //    procwords[31] = "AS";
        //    procwords[32] = "FOREIGN";
        //    procwords[33] = "PRIVILEGES";
        //    procwords[34] = "ASC";
        //    procwords[35] = "FORTRAN";
        //    procwords[36] = "PROCEDURE";
        //    procwords[37] = "ASSERTION";
        //    procwords[38] = "FOUND";
        //    procwords[39] = "PUBLIC";
        //    procwords[40] = "AT";
        //    procwords[41] = "FROM";
        //    procwords[42] = "READ";
        //    procwords[43] = "AUTHORIZATION";
        //    procwords[44] = "FULL";
        //    procwords[45] = "REAL";
        //    procwords[46] = "AVG";
        //    procwords[47] = "GET";
        //    procwords[48] = "REFERENCES";
        //    procwords[49] = "BEGIN";
        //    procwords[50] = "GLOBAL";
        //    procwords[51] = "RELATIVE";
        //    procwords[52] = "BETWEEN";
        //    procwords[53] = "GO";
        //    procwords[54] = "RESTRICT";
        //    procwords[55] = "BIT";
        //    procwords[56] = "GOTO";
        //    procwords[57] = "REVOKE";
        //    procwords[58] = "BIT_LENGTH";
        //    procwords[59] = "GRANT";
        //    procwords[60] = "RIGHT";
        //    procwords[61] = "BOTH";
        //    procwords[62] = "GROUP";
        //    procwords[63] = "ROLLBACK";
        //    procwords[64] = "BY";
        //    procwords[65] = "HAVING";
        //    procwords[66] = "ROWS";
        //    procwords[67] = "CASCADE";
        //    procwords[68] = "HOUR";
        //    procwords[69] = "SCHEMA";
        //    procwords[70] = "CASCADED";
        //    procwords[71] = "IDENTITY";
        //    procwords[72] = "SCROLL";
        //    procwords[73] = "CASE";
        //    procwords[74] = "IMMEDIATE";
        //    procwords[75] = "SECOND";
        //    procwords[76] = "CAST";
        //    procwords[77] = "IN";
        //    procwords[78] = "SECTION";
        //    procwords[79] = "CATALOG";
        //    procwords[80] = "INCLUDE";
        //    procwords[81] = "SELECT";
        //    procwords[82] = "CHAR";
        //    procwords[83] = "INDEX";
        //    procwords[84] = "SESSION";
        //    procwords[85] = "CHAR_LENGTH";
        //    procwords[86] = "INDICATOR";
        //    procwords[87] = "SESSION_USER";
        //    procwords[88] = "CHARACTER";
        //    procwords[89] = "INITIALLY";
        //    procwords[90] = "SET";
        //    procwords[91] = "CHARACTER_LENGTH";
        //    procwords[92] = "INNER";
        //    procwords[93] = "SIZE";
        //    procwords[94] = "CHECK";
        //    procwords[95] = "INPUT";
        //    procwords[96] = "SMALLINT";
        //    procwords[97] = "CLOSE";
        //    procwords[98] = "INSENSITIVE";
        //    procwords[99] = "SOME";
        //    procwords[100] = "COALESCE";
        //    procwords[101] = "INSERT";
        //    procwords[102] = "SPACE";
        //    procwords[103] = "COLLATE";
        //    procwords[104] = "INT";
        //    procwords[105] = "SQL";
        //    procwords[106] = "COLLATION";
        //    procwords[107] = "INTEGER";
        //    procwords[108] = "SQLCA";
        //    procwords[109] = "COLUMN";
        //    procwords[110] = "INTERSECT";
        //    procwords[111] = "SQLCODE";
        //    procwords[112] = "COMMIT";
        //    procwords[113] = "INTERVAL";
        //    procwords[114] = "SQLERROR";
        //    procwords[115] = "CONNECT";
        //    procwords[116] = "INTO";
        //    procwords[117] = "SQLSTATE";
        //    procwords[118] = "CONNECTION";
        //    procwords[119] = "IS";
        //    procwords[120] = "SQLWARNING";
        //    procwords[121] = "CONSTRAINT";
        //    procwords[122] = "ISOLATION";
        //    procwords[123] = "SUBSTRING";
        //    procwords[124] = "CONSTRAINTS";
        //    procwords[125] = "JOIN";
        //    procwords[126] = "SUM";
        //    procwords[127] = "CONTINUE";
        //    procwords[128] = "KEY";
        //    procwords[129] = "SYSTEM_USER";
        //    procwords[130] = "CONVERT";
        //    procwords[131] = "LANGUAGE";
        //    procwords[132] = "TABLE";
        //    procwords[133] = "CORRESPONDING";
        //    procwords[134] = "LAST";
        //    procwords[135] = "TEMPORARY";
        //    procwords[136] = "COUNT";
        //    procwords[137] = "LEADING";
        //    procwords[138] = "THEN";
        //    procwords[139] = "CREATE";
        //    procwords[140] = "LEFT";
        //    procwords[141] = "TIME";
        //    procwords[142] = "CROSS";
        //    procwords[143] = "LEVEL";
        //    procwords[144] = "TIMESTAMP";
        //    procwords[145] = "CURRENT";
        //    procwords[146] = "LIKE";
        //    procwords[147] = "TIMEZONE_HOUR";
        //    procwords[148] = "CURRENT_DATE";
        //    procwords[149] = "LOCAL";
        //    procwords[150] = "TIMEZONE_MINUTE";
        //    procwords[151] = "CURRENT_TIME";
        //    procwords[152] = "LOWER";
        //    procwords[153] = "TO";
        //    procwords[154] = "CURRENT_TIMESTAMP";
        //    procwords[155] = "MATCH";
        //    procwords[156] = "TRAILING";
        //    procwords[157] = "CURRENT_USER";
        //    procwords[158] = "MAX";
        //    procwords[159] = "TRANSACTION";
        //    procwords[160] = "CURSOR";
        //    procwords[161] = "MIN";
        //    procwords[162] = "TRANSLATE";
        //    procwords[163] = "DATE";
        //    procwords[164] = "MINUTE";
        //    procwords[165] = "TRANSLATION";
        //    procwords[166] = "DAY";
        //    procwords[167] = "MODULE";
        //    procwords[168] = "TRIM";
        //    procwords[169] = "DEALLOCATE";
        //    procwords[170] = "MONTH";
        //    procwords[171] = "TRUE";
        //    procwords[172] = "DEC";
        //    procwords[173] = "NAMES";
        //    procwords[174] = "UNION";
        //    procwords[175] = "DECIMAL";
        //    procwords[176] = "NATIONAL";
        //    procwords[177] = "UNIQUE";
        //    procwords[178] = "DECLARE";
        //    procwords[179] = "NATURAL";
        //    procwords[180] = "UNKNOWN";
        //    procwords[181] = "DEFAULT";
        //    procwords[182] = "NCHAR";
        //    procwords[183] = "UPDATE";
        //    procwords[184] = "DEFERRABLE";
        //    procwords[185] = "NEXT";
        //    procwords[186] = "UPPER";
        //    procwords[187] = "DEFERRED";
        //    procwords[188] = "NO";
        //    procwords[189] = "USAGE";
        //    procwords[190] = "DELETE";
        //    procwords[191] = "NONE";
        //    procwords[192] = "USER";
        //    procwords[193] = "DESC";
        //    procwords[194] = "NOT";
        //    procwords[195] = "USING";
        //    procwords[196] = "DESCRIBE";
        //    procwords[197] = "NULL";
        //    procwords[198] = "VALUE";
        //    procwords[199] = "DESCRIPTOR";
        //    procwords[200] = "NULLIF";
        //    procwords[201] = "VALUES";
        //    procwords[202] = "DIAGNOSTICS";
        //    procwords[203] = "NUMERIC";
        //    procwords[204] = "VARCHAR";
        //    procwords[205] = "DISCONNECT";
        //    procwords[206] = "OCTET_LENGTH";
        //    procwords[207] = "VARYING";
        //    procwords[208] = "DISTINCT";
        //    procwords[209] = "OF";
        //    procwords[210] = "VIEW";
        //    procwords[211] = "DOMAIN";
        //    procwords[212] = "ON";
        //    procwords[213] = "WHEN";
        //    procwords[214] = "DOUBLE";
        //    procwords[215] = "ONLY";
        //    procwords[216] = "WHENEVER";
        //    procwords[217] = "DROP";
        //    procwords[218] = "OPEN";
        //    procwords[219] = "WHERE";
        //    procwords[220] = "ELSE";
        //    procwords[221] = "OPTION";
        //    procwords[222] = "WITH";
        //    procwords[223] = "END";
        //    procwords[224] = "OR";
        //    procwords[225] = "WORK";
        //    procwords[226] = "END-EXEC";
        //    procwords[227] = "ORDER";
        //    procwords[228] = "WRITE";
        //    procwords[229] = "ESCAPE";
        //    procwords[230] = "OUTER";
        //    procwords[231] = "YEAR";
        //    procwords[232] = "EXCEPT";
        //    procwords[233] = "OUTPUT";
        //    procwords[234] = "ZONE";
        //    procwords[235] = "EXCEPTION";

        //    string[]? a = richTextBox3.Text.Split(" ");
        //    List<string> ls = a.ToList();
        //    fulltext = richTextBox3.Text;


        //    foreach (string splt in ls)
        //    {

        //        foreach (string s in procwords)
        //        {

        //            if (s != null)
        //            {


        //                if (s.Equals(splt.ToUpper()))
        //                {

        //                    string splt2 = Environment.NewLine + splt.ToUpper() + Environment.NewLine;
        //                    splt2 = splt2.Replace(" ", "");
        //                    fulltext = fulltext.Replace(splt, splt2);

        //                    stringpos = fulltext.IndexOf(splt2);


        //                    //if (s != null)
        //                    //{
        //                    //    string t = "/n" + s + "/n";
        //                    //    CheckKeyword(t.ToUpper(), Color.Red, 0);

        //                    //}

        //                }


        //            }

        //        }


        //    }


        //    richTextBox3.Clear();
        //    richTextBox3.Text = fulltext;

        //    foreach (string s in procwords)
        //    {
                

        //        if (s != null)
        //        {
        //            //string t = "/N" + s + "/N";
        //            CheckKeyword(s.ToUpper(), Color.Red, 0);

        //        }

        //    }





        
                


           



            

        //    richTextBox3.ForeColor = Color.Black;

          

        //    //string newstring;

        //    //StringBuilder sb = new StringBuilder();

        //    //sb.Append(richTextBox3.Text);

        //    //string text = richTextBox3.Text;

        //    //var text2 = SqlPrettify.SqlPrettify.Pretty(text);

        //    //text2 = text2.Trim();

        //    //text2 = text2.Replace("\n", "\r\n");

        //    //text2 = text2.Replace("--", Environment.NewLine + "--");

        //    //richTextBox3.Text = text2;

            

        //}



        //private void CheckKeyword(string word, Color color, int startIndex)
        //{
        //    int sels = new int();

        //    if (this.richTextBox3.Text.Contains(word))
        //    {
        //        int index = -1;

        //        string wordsur = richTextBox3.Text.Substring(stringpos, word.Length +2);
        //        var wordsurrev = wordsur.Reverse();
        //        string wrdsurrevs = string.Join(string.Empty, wordsurrev);
        //        int len = wordsur.Length;
        //        var l = wordsur.Substring((stringpos + len) - 1, 1);
        //        var f = wrdsurrevs.Substring((stringpos + len) - 1, 1);

        //        while ((index = this.richTextBox3.Text.IndexOf(word, (index + 1))) != -1)
        //        {

        //            this.richTextBox3.Select((index + startIndex), word.Length);
        //            this.richTextBox3.SelectionColor = color;
        //            this.richTextBox3.Select(sels, 0);
        //            this.richTextBox3.SelectionColor = Color.Black;
                       
        //        }
        //    }
        //}



        //private void CheckKeywordUpper(string word, int startIndex)
        //{
        //    if (this.richTextBox3.Text.Contains(word))
        //    {
        //        int index = -1;
        //        int selectStart = this.richTextBox3.SelectionStart;

        //        while ((index = this.richTextBox3.Text.IndexOf(word, (index + 1))) != -1)
        //        {
        //            this.richTextBox3.Select((index + startIndex), word.Length);
        //            this.richTextBox3.Select(selectStart, 0);
        //            this.richTextBox3.SelectedText = richTextBox3.SelectedText.ToUpper();
        //            this.richTextBox3.SelectionColor = Color.Black;
        //        }
        //    }
        //}



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.Enabled = false;
            checkBox1.Checked = false;
            comboBox1.Enabled = false;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.Enabled = false;
            checkBox1.Checked = false;
            comboBox1.Enabled = false;

        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();

            if (valuesearchstring == "")
            {
                valuesearchstring = "(No Search Term Entered)";
            }


            sb.Append("Search Term: " + valuesearchstring + Environment.NewLine + "Search Type: " + searchtype + Environment.NewLine + Environment.NewLine + "Results:" + Environment.NewLine);

            foreach (DataGridViewRow d in dataGridView2.Rows)
            {

                
                    for (int i = 0; i < d.Cells.Count; i++)
                    {
                        if (i == (d.Cells.Count - 1))
                        {
                            sb.Append("[VALUE: " + d.Cells[i].Value + "]" + Environment.NewLine);
                        }
                        else
                        {
                            sb.Append("[PATH: " + d.Cells[i].Value + "]" + " - ");
                        }
                    }     

            }

            string? txt = sb.ToString();

            Clipboard.SetText(txt);
            sb.Clear();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            List<string> ls = new List<string>();

            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewRow d in dataGridView2.SelectedRows)
            {
               ls.Add("[PATH: " + d.Cells[0].Value + "]" + " - " + "[VALUE: " + d.Cells[1].Value + "]" + Environment.NewLine);
            }


            ls.Reverse();
            string[] values = ls.ToArray();

            if (valuesearchstring == "")
            {
                valuesearchstring = "(No Search Term Entered)";
            }

            sb.Append("Search Term: " + valuesearchstring + Environment.NewLine + "Search Type: " + searchtype + Environment.NewLine + Environment.NewLine + "Results:" + Environment.NewLine);

            foreach(string s in values)
            {
                sb.Append(s);
            }
          
            string text = sb.ToString();
            Clipboard.SetText(text);
            sb.Clear();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            int rowcount = dataGridView2.Rows.Count;
            List<string> ls = new List<string>();
           

            StringBuilder sb = new StringBuilder();

            if (valuesearchstring == "")
            {
                valuesearchstring = "(No Search Term Entered)";
            }

            sb.Append("Search Term: " + valuesearchstring + Environment.NewLine + "Search Type: " + searchtype + Environment.NewLine + Environment.NewLine + "Results:" + Environment.NewLine);


                foreach (DataGridViewRow d in dataGridView2.Rows)
                {

                var s = d.Cells["Column Path"].Value;
                ls.Add("[" + s + "]"); 

                }

            string[] locationlist = ls.ToArray();
            string[] distinctpaths = locationlist.Distinct().ToArray();
            
            foreach (string s in distinctpaths)
            {
                sb.Append(s + Environment.NewLine);
            }

            string text = sb.ToString();
            Clipboard.SetText(text);
            sb.Clear();
        }


        private void findthisrecord(object sender, EventArgs e)
        { 

            

            var valuetoget = dataGridView2.SelectedCells[0].Value;
            string[] valuesplit = valuetoget.ToString().Split('>');
            var table = valuesplit[0].ToString().Trim();
            var column = valuesplit[1].ToString().Trim();
            var searchvalue = dataGridView2.SelectedCells[1].Value;
            string searchterm = "select * from [" + table + "] where " + column + " = " + "'" + searchvalue.ToString() + "'";

            tabControl1.SelectedTab = tabControl1.TabPages[5];
            tabControl2.SelectedTab = tabControl2.TabPages[0];
            richTextBox1.Text = searchterm;
            richTextBox1_KeyDowns(sender, e);



        }


        public static string makeupper (string input)
        {
            string output = input.ToUpper();
            return output;
        }

        public static string makelower(string input)
        {
            string output = input.ToLower();
            return output;
        }

        public void pretty(object sender, EventArgs e)
        {

            string[]? procwords = new string[300];
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

            string input1 = richTextBox3.Text;

            string input2 = Regex.Replace(input1, @"\r\n?|\n", " ");

            string[] input3 = input2.Split(" ");

            string toheader;

            if ((checkBox3.Checked == false) && (checkBox4.Checked == false))
            {
                richTextBox3.Text = SqlPrettify.SqlPrettify.Pretty(richTextBox3.Text);
            }

            if (checkBox5.Checked == true)
            {
                string s = richTextBox3.Text.ToUpper();
                richTextBox3.Text = SqlPrettify.SqlPrettify.Pretty(s);
            }

            if (checkBox6.Checked == true)
            {
                string s = richTextBox3.Text.ToLower();
                richTextBox3.Text = SqlPrettify.SqlPrettify.Pretty(s);
            }

            if (checkBox3.Checked == true)
            {

                foreach (string p in procwords)
                {
                    if (p != null)
                    {
                        foreach (string s in input3)
                        {
                            string t = s.ToLower();
                            string u = p.ToLower();

                            if (t == u)
                            {
                                int index = Array.IndexOf(input3, s);
                                string v = makeupper(s);
                                input3[index] = v;
                            }
                        }
                    }
                }

                string input4 = String.Join(" ", input3);

                richTextBox3.Text = SqlPrettify.SqlPrettify.Pretty(input4);
                toheader = SqlPrettify.SqlPrettify.Pretty(input4);
            }

            if (checkBox4.Checked == true)
            {

                foreach (string p in procwords)
                {
                    if (p != null)
                    {
                        foreach (string s in input3)
                        {
                            string t = s.ToLower();
                            string u = p.ToLower();

                            if (t == u)
                            {
                                int index = Array.IndexOf(input3, s);
                                string v = makelower(s);
                                input3[index] = v;
                            }
                        }
                    }
                }

                string input4 = String.Join(" ", input3);

                richTextBox3.Text = SqlPrettify.SqlPrettify.Pretty(input4);
                toheader = SqlPrettify.SqlPrettify.Pretty(input4);
            }

          

        }


        //Private Sub chkBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBox1.CheckedChanged
    //    If chkBox1.CheckState = CheckState.Checked And chkBox2.CheckState = CheckState.Checked Then
    //        chkBox2.CheckState = CheckState.Unchecked
    
    //    End If
    
    //    If chkBox1.CheckState = CheckState.Unchecked And chkBox2.CheckState = CheckState.Unchecked Then
    //        chkBox2.CheckState = CheckState.Checked
    
    //    End If
    //End Sub
    



        public void sqlcheckboxbehaviour1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true || checkBox4.Checked == true)
            {
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
            }

            if (checkBox3.Checked == true && checkBox4.Checked == true)
            {
                checkBox4.Checked = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
            }

            if (checkBox3.Checked == false && checkBox4.Checked == false)
            {
                checkBox4.Checked = false;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
            }

        }

        public void sqlcheckboxbehaviour2(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true || checkBox4.Checked == true)
            {
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
            }

            if (checkBox3.Checked == true && checkBox4.Checked == true)
            {
                checkBox3.Checked = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
            }

            if (checkBox3.Checked == false && checkBox4.Checked == false)
            {
                checkBox3.Checked = false;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
            }

        }


        public void sqlcheckboxbehaviour3(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true || checkBox6.Checked == true)
            {
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }

            if (checkBox5.Checked == true && checkBox6.Checked == true)
            {
                checkBox6.Checked = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }

            if (checkBox5.Checked == false && checkBox6.Checked == false)
            {
                checkBox6.Checked = false;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }

        }

        public void sqlcheckboxbehaviour4(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true || checkBox6.Checked == true)
            {
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }

            if (checkBox5.Checked == true && checkBox6.Checked == true)
            {
                checkBox5.Checked = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }

            if (checkBox5.Checked == false && checkBox6.Checked == false)
            {
                checkBox5.Checked = false;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }


            //if (checkBox5.Checked == false && checkBox6.Checked == false)
        }




        private void richTextBox3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int currentline = richTextBox1.GetFirstCharIndexOfCurrentLine();
            if (currentline > 0)
            {
                curlin = richTextBox1.SelectionStart;
            }

            else
            {
                curlin = richTextBox1.SelectionStart;         
            }

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            int currentline = richTextBox2.GetFirstCharIndexOfCurrentLine();
            if (currentline > 0)
            {
                curlin = richTextBox2.SelectionStart;
            }

            else
            {
                curlin = richTextBox2.SelectionStart;
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            int currentline = richTextBox4.GetFirstCharIndexOfCurrentLine();
            if (currentline > 0)
            {
                curlin = richTextBox4.SelectionStart;
            }

            else
            {
                curlin = richTextBox4.SelectionStart;
            }
        }

        private void checkBox7_Click(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            { autocomplete = true; }
        }
    }

    static class StringReverse

    {
        public static string reverse(string star)
        {
            char[] stararr = star.ToCharArray();
            Array.Reverse(stararr);
            return new string(stararr);
        }

        public static bool IsInt(string value)
        {
            return int.TryParse(value, out int intValue);
        }


    }







}












