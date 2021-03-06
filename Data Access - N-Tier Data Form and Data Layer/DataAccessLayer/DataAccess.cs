
using System;
using System.Data;
using System.Data.SqlClient;

// This class provides the database access for a front end. It passes
//   a Dataset containing Supplier and Product information to the front end.

public class DataAccess
{
    // Initialize constants for connecting to the database
    // and displaying a connection error to the user.

    protected const string CONNECTION_ERROR_MSG  = "To run this sample, you must have SQL " + 
													"or MSDE with the Northwind database installed.  For " + 
													"instructions on installing MSDE, view the ReadMe file.";

    protected const string MSDE_CONNECTION_STRING  = @"Server=(local)\NetSDK;" + 
														"DataBase=northwind;" + 
														"Integrated Security=SSPI";

    protected const string SQL_CONNECTION_STRING  = "Server=localhost;" + 
													"DataBase=northwind;" + 
													"Integrated Security=SSPI";

    static bool DidPreviouslyConnect = false;

    // Create two data adapters--one for each table.

    private SqlDataAdapter sdaSuppliers;

    private SqlDataAdapter sdaProducts;

    protected string strConn  = SQL_CONNECTION_STRING;

    // Declare several events that can be used to provide information to
    //   the front end.

	public delegate void ConnectionStatusChangeDelegate(string status);
	public event ConnectionStatusChangeDelegate ConnectionStatusChange;
    
	public delegate void ConnectionFailureDelegate(string status);
    public event ConnectionFailureDelegate ConnectionFailure;

	public delegate void ConnectionCompletedDelegate(string status);
    public event ConnectionCompletedDelegate ConnectionCompleted;

    // Create the Dataset used in this sample. It contains two tables consisting of 
    // Supplier and Product data.

    public DataSet CreateDataSet()
	{

        DataSet dsSupplierProducts = new DataSet();

        // Raise a status event saying that the user is attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        if (DidPreviouslyConnect==false) 
		{
            ConnectionStatusChange("Connecting to SQL Server");
        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool IsConnecting = true;

        while (IsConnecting)
		{
            try 
			{

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.

                SqlConnection scnnNW = new SqlConnection(strConn);

                string strSQL  = "SELECT * FROM Suppliers";

                // A SqlCommand object is used to execute the SQL commands.

                SqlCommand scmd = new SqlCommand(strSQL, scnnNW);

                // A SqlDataAdapter uses the SqlCommand object to fill a DataSet.

                sdaSuppliers = new SqlDataAdapter(scmd);

                // A SqlCommandBuilder automatically generates the SQL commands needed
                // to update the database later.

                SqlCommandBuilder scb = new SqlCommandBuilder(sdaSuppliers);

                this.sdaSuppliers.Fill(dsSupplierProducts, "Supplier");

                // Create a new SqlDataAdapter, this time simply passing in the
                // SQL Select Statement

                sdaProducts = new SqlDataAdapter("SELECT * FROM Products", scnnNW);

                // The commands generated by the SqlCommandBuilder are based on the 
                // currently set CommandText of the SqlCommand object. this will

                SqlCommandBuilder scbProducts = new SqlCommandBuilder(sdaProducts);

                // Fill the second table in the DataSet.

                sdaProducts.Fill(dsSupplierProducts, "Product");

                // OPTIONAL: To see a different kind of Master-Details interface,
                // in which both the master and details data is contained in the
                // same DataGrid, uncomment the following line of code, which sets
                // up a parent-child table relation. { re-run the app and 
                // expand the SupplierID node and view product details in the same
                // DataGrid (the Product grid is not needed then). 
                //dsSupplierProducts.Relations.Add("Supplier_Products", _
                //    dsSupplierProducts.Tables("Supplier").Columns("SupplierID"), _
                //    dsSupplierProducts.Tables("Product").Columns("SupplierID"))
                // Data has been successfully retrieved, so break out of the loop
                // and close the status form.

                IsConnecting = false;

                DidPreviouslyConnect = true;

			} 
			catch(Exception exp)
			{

                if (strConn == SQL_CONNECTION_STRING)
				{
                    // Couldn't connect to SQL Server.  Now try MSDE.
                    
					strConn = MSDE_CONNECTION_STRING;
                    ConnectionStatusChange("Connecting to MSDE");
				}
                else 
				{

                    // Unable to connect to SQL Server or MSDE

                    ConnectionFailure(CONNECTION_ERROR_MSG);

                }

            }

        }

        // Reflect the success by raising the proper event.

        ConnectionCompleted(Convert.ToString(true));

        // return the filled DataSet

        return dsSupplierProducts;

    }

    // This subroutine takes a passed Dataset and updates the Northwind
    //   database, with the changes.

    public void UpdateDataSet(DataSet inDS )
	{

        // if the Dataset that was passed in is null, exit this subrouting.

        if (inDS == null) 
		{
            return;
        }

        try 
		{

            // First verify that the data adapters have been created, and call
            //   the CreateDataset to build them if necessary.

            if (this.sdaProducts == null | this.sdaSuppliers == null) 
			{
                CreateDataSet();
            }

            // try { to Update the DataSet. It is critical that everything is done
            //   in the proper sequence, unless you turn off the EnforceConstraints property.
            // So there are two ways of updating the data. 
            // The first is shutting off EnforceConstraints

            inDS.EnforceConstraints = false;

            this.sdaProducts.Update(inDS, "Product");
            this.sdaSuppliers.Update(inDS, "Supplier");

            //' You can also do it in a proper sequence so not to violate constraints at all.
            //' Products must be deleted first, so you don't strand products when a supplier
            //'   is deleted. Don't forget that you must check first to see if there are actual
            //'   changes to be made in each DataRowState, otherwise GetChanges will return
            //'   a null Dataset and an exception will be raised.
            //' To use this method instead, simply uncomment the lines below.
            //if not inDS.GetChanges(DataRowState.Deleted) == null {
            //    this.sdaProducts.Update(inDS.GetChanges(DataRowState.Deleted), "Products")
            //    this.sdaSuppliers.Update(inDS.GetChanges(DataRowState.Deleted), "Suppliers")
            //}
            //if not inDS.GetChanges(DataRowState.Detached) == null {
            //    this.sdaProducts.Update(inDS.GetChanges(DataRowState.Detached), "Products")
            //    this.sdaSuppliers.Update(inDS.GetChanges(DataRowState.Detached), "Suppliers")
            //}
            //' Suppliers must be added first, so you don't create orphaned products
            //if not inDS.GetChanges(DataRowState.Added) == null {
            //    this.sdaSuppliers.Update(inDS.GetChanges(DataRowState.Added), "Suppliers")
            //    this.sdaProducts.Update(inDS.GetChanges(DataRowState.Added), "Products")
            //}
            //' Changes can be made in any order
            //if not inDS.GetChanges(DataRowState.Modified) == null {
            //    this.sdaSuppliers.Update(inDS.GetChanges(DataRowState.Modified), "Suppliers")
            //    this.sdaProducts.Update(inDS.GetChanges(DataRowState.Modified), "Products")
            //}

		} 
		catch(Exception exc)
		{

            // Alert the front end that an error occurred.

            ConnectionFailure("Unable to update the data source.");

        }

    }

}

