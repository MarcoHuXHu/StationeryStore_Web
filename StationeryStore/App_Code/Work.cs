using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Work
/// </summary>
public class Work
{
    Team5ADProjectEntities ctx = new Team5ADProjectEntities();

    List<ItemDiscrepancyModel> idlist;
    List<ItemModel> ilist;
    Discrepancy discrepancy;
    Item item;
    public Work()
    {

    }

    public bool Authenticate(string userId, string pwd)
    {
        
        Staff s = ctx.Staffs.Where(x => x.UserID == userId && x.Password == pwd).ToList().FirstOrDefault();
        if (s != null)
        {
            return true;
        }
        else return false;
    }

    public  List<Item> lowInStock()
    {
        
        List<Item> result = new List<Item>();
        List<Item> all = ctx.Items.ToList();
        foreach (Item i in all)
        {
            if (i.InStock <= i.ReorderLevel)
            {
                result.Add(i);
            }


        }
        return result;
    }
    public  bool delegated(string userId)
    {
        
        Delegation de = ctx.Delegations.Where(x => x.CoveringHeadID == userId && x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).ToList().FirstOrDefault();
        if (de != null)
        {
            return true;
        }
        else return false;
    }

    public  bool delegateTo(string userId)
    {
        
        Delegation de = ctx.Delegations.Where(x => x.DepartmentHeadID == userId && x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today).ToList().FirstOrDefault();
        if (de != null)
        {
            return true;
        }
        else return false;
    }

    public  Delegation getDlgtInfo(string userId)
    {
        
        List<Delegation> list = ctx.Delegations.Where(x => x.DepartmentHeadID == userId && (x.StartDate <= DateTime.Today && x.EndDate >= DateTime.Today) || (x.StartDate >= DateTime.Today)).ToList();
        if (list.Count == 0)
        {
            return null;
        }else if (list.Count == 1)
        {
            return list.First();
        }else
        {
            for(int c=0;c< list.Count() - 1;c++)
            {
                
                Delegation de = list[c];        
                ctx.Delegations.Remove(de);
                ctx.SaveChanges();
                list.RemoveAt(c);
            }
            return list.First();
        }
    }

    public List<Staff> getDptSfInfo(string userId)
    {
        
        string deptId = getUser(userId).DepartmentID;
        List<Staff> st1 = ctx.Staffs.OrderBy(x=>x.Name).Where(x => x.DepartmentID == deptId).ToList();
        st1.Remove(getUser(userId));
        return st1;
    }

    public  void addDelegation(Delegation de)
    {
        
        ctx.Delegations.Add(de);
        ctx.SaveChanges();
    }

    public  void deleteDelegation(Delegation de)
    {
        
        ctx.Delegations.Remove(de);
        ctx.SaveChanges();
    }

    public  void revokeDelegation(Delegation de)
    {
        
        Delegation d = ctx.Delegations.Where(x => x.DelegationID == de.DelegationID).ToList().FirstOrDefault();
        d.EndDate = DateTime.Today;
        ctx.SaveChanges();
    }

    public  string getDeptRep(string userId)
    {
        
        string deptId = getUser(userId).DepartmentID;
        return ctx.Staffs.Where(x => x.DepartmentID == deptId && x.Role == "DeptRep").FirstOrDefault().UserID;

    }
    public  void ChangeRep(string oldRep, string newRep)
    {
        
        Staff newrep = ctx.Staffs.Where(x => x.Name == newRep).First();
        Staff oldrep = ctx.Staffs.Where(x => x.Name == oldRep).First();
        oldrep.Role = "Employee";
        newrep.Role = "DeptRep";
        ctx.SaveChanges();
    }

    public  void changeCollectionPoint(string userId, string point)
    {
        
        Department d = getUser(userId).Department;
        d.Collection_Point = point;
        ctx.SaveChanges();
    }
    public  string getDeptHeadId(string deptId)
    {
        
        return ctx.Staffs.Where(x => x.DepartmentID == deptId && (x.Role == "DeptHead" || x.Role == "Manager" || x.Role == "Supervisor")).ToList().FirstOrDefault().UserID;
    }

    public  Request getRequestById(string id)
    {
        
        return ctx.Requests.Where(x => x.RequestID == id).ToList().FirstOrDefault();
    }
    public  List<Item> getAllItems()
    {
        
        return ctx.Items.ToList();
    }
    public  List<Item> getFoundItems(string text)
    {
        
        return ctx.Items.Where(x => x.Category.Contains(text) || x.Description.Contains(text)).ToList();
    }

    public  Item getItem(string itemId)
    {
        
        return ctx.Items.Where(x => x.ItemID == itemId).FirstOrDefault();
    }

    public  void createRequest(Request rq)
    {
        

        ctx.Requests.Add(rq);
        ctx.SaveChanges();


    }

    public  string getRequestId(string deptId)
    {
        
        Request rq = ctx.Requests.Where(x => x.RequestID.Contains(deptId)).OrderByDescending(y => y.RequestDate).FirstOrDefault();
        if (rq == null) { return null; }
        else
        {
            return rq.RequestID;
        }
    }

    public  Staff getUser(string id)
    {
        
        return ctx.Staffs.Where(x => x.UserID == id).FirstOrDefault();
    }

    public  Staff getUserbyName(string name)
    {
        
        return ctx.Staffs.Where(x => x.Name == name).FirstOrDefault();
    }


    public  void createRequestDetail(RequestDetail rd)
    {
        
        ctx.RequestDetails.Add(rd);
        ctx.SaveChanges();
    }

    public  void updateOutstangQty(string deptId, string itemId, int qty)
    {
        
        OutstandingRequest or = ctx.OutstandingRequests.Where(x => x.DepartmentID == deptId && x.ItemID == itemId).FirstOrDefault();
        if (or == null)
        {
            or = new OutstandingRequest();
            or.DepartmentID = deptId;
            or.ItemID = itemId;
            or.OutstandingQty = qty;
            ctx.OutstandingRequests.Add(or);
            ctx.SaveChanges();
        }
        else
        {
            or.OutstandingQty += qty;
            ctx.SaveChanges();
        }
    }

    public  List<Request> getRequest(string userId)
    {
        
        return ctx.Requests.Where(x => x.UserID == userId).OrderByDescending(y => y.RequestDate).ToList();

    }

    public  List<Request> getDeptRequests(string userId)
    {
        
        string deptId = getUser(userId).DepartmentID;
        return ctx.Requests.Where(x => x.Staff.DepartmentID == deptId).OrderByDescending(y => y.RequestDate).ToList();
    }



    public  List<RequestDetail> getRequestDetail(string id)
    {
        
        return ctx.RequestDetails.Where(x => x.RequestID == id).OrderByDescending(y => y.Request.RequestDate).ToList();
    }

    public  List<String> getRequestSatus()
    {
        
        var list = ctx.RequestDetails.GroupBy(y => y.Status).Select(x => x.FirstOrDefault()).ToList();
        return list.Select(o => o.Status).ToList();
    }

    public  List<RqHistory> getRqHistory(string userId)
    {
        
        List<RqHistory> hList = new List<RqHistory>();
        List<Request> rqList = getDeptRequests(userId);

        foreach (Request rq in rqList)
        {
            string status = null;
            List<RequestDetail> rdList = getRequestDetail(rq.RequestID);
            if (rdList[0].Status != "Cancelled")
            {
                if (rdList[0].Status == "InProgress" || rdList[0].Status == "Completed" || rdList[0].Status == "Unfulfilled")
                {
                    status = "Approved";
                }
                else
                {
                    status = rdList[0].Status;
                }
                RqHistory h = new RqHistory(rq.RequestID, rq.RequestDate, getUser(rq.UserID).Name, status);
                hList.Add(h);
            }

        }
        return hList;
    }

    public  List<RqDetail> getRqDetail(string rqId)
    {
        
        List<RequestDetail> rdList = getRequestDetail(rqId);

        List<RqDetail> deList = new List<RqDetail>();
        foreach (RequestDetail rd in rdList)
        {

            RqDetail de = new RqDetail(rqId, rd.ItemID, rd.Request.RequestDate, rd.Item.Description, rd.Item.UOM, rd.RequestQty, rd.Status, rd.Request.Comment);
            deList.Add(de);

        }
        return deList;
    }

    public  void CancelRequest(string id)
    {
        
        List<RequestDetail> list = ctx.RequestDetails.Where(x => x.RequestID == id).ToList();
        foreach (RequestDetail rd in list)
        {
            rd.Status = "Cancelled";
            ctx.SaveChanges();
        }

    }

    public  void DeleteRequestItem(string rqId, string itemId)
    {
        
        RequestDetail rd = ctx.RequestDetails.Where(x => x.RequestID == rqId && x.ItemID == itemId).ToList().First();
        ctx.RequestDetails.Remove(rd);
        ctx.SaveChanges();
        List<RequestDetail> list = ctx.RequestDetails.Where(x => x.RequestID == rqId).ToList();
        if (list.Count == 0)
        {
            Request rq = ctx.Requests.Where(x => x.RequestID == rqId).ToList().FirstOrDefault();
            ctx.Requests.Remove(rq);
            ctx.SaveChanges();
        }
    }

    public  void UpdateRqQty(string rqId, string itemId, int qty)
    {
        
        RequestDetail rd = ctx.RequestDetails.Where(x => x.RequestID == rqId && x.ItemID == itemId).ToList().First();
        rd.RequestQty = qty;
        ctx.SaveChanges();

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rqId"></param>
    /// <param name="comment"></param>
    public  void ApproveRequest(string rqId, string comment)
    {
        
        Request rq = ctx.Requests.Where(x => x.RequestID == rqId).ToList().First();
        rq.Comment = comment;
        List<RequestDetail> list = getRequestDetail(rqId);

        // Edited by Marco
        // Updated version can also operate on TransactionLog
        Transaction clerk = new Transaction();
        foreach (RequestDetail rd in list)
        {
            string deptId = rq.Staff.DepartmentID;
            clerk.requestUpdateOutstanding(rd.ItemID, deptId, rd.RequestQty);
        }
        foreach (RequestDetail rd in list)
        {
            rd.Status = "InProgress";
            ctx.SaveChanges();
            //Work.updateOutstangQty(deptId, rd.ItemID, rd.RequestQty);
        }
    }

    public  void RejecteRequest(string rqId, string comment)
    {
        
        Request rq = ctx.Requests.Where(x => x.RequestID == rqId).ToList().First();
        rq.Comment = comment;
        List<RequestDetail> list = getRequestDetail(rqId);
        foreach (RequestDetail rd in list)
        {
            rd.Status = "Rejected";
            ctx.SaveChanges();

        }


    }

    public  void AllocateItems(string rqId, string itemId, int qty)
    {
        
        RequestDetail rd = ctx.RequestDetails.Where(x => x.RequestID == rqId && x.ItemID == itemId).ToList().FirstOrDefault();
        int result = rd.RetrievedQty + qty;
        if (result == rd.RequestQty)
        {
            rd.Status = "Completed";
        }
        else
        {
            rd.Status = "Unfulfilled";
        }
        rd.RetrievedQty = result;
        ctx.SaveChanges();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public  List<DisbursementModel> viewRequestSummary()
    {
        
        List<DisbursementModel> list = new List<DisbursementModel>();
        var q = from O in ctx.OutstandingRequests
                join I in ctx.Items on O.ItemID equals I.ItemID
                group O by new { O.ItemID, I.Description, I.InStock, I.BinNumber } into g
                select new
                {
                    ItemID = g.Key.ItemID,
                    Description = g.Key.Description,
                    Needed = g.Sum(o => o.OutstandingQty),
                    InStock = g.Key.InStock,
                    g.Key.BinNumber
                };
        foreach (var a in q.ToList())
        {
            DisbursementModel dm = new DisbursementModel(a.ItemID, a.Description, a.Needed, a.InStock, a.BinNumber);
            if (dm.NeededNumber != 0)
                list.Add(dm);
        }
        return list;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public  List<DisbursementModel> viewRequestByDept()
    {
        
        List<DisbursementModel> list = new List<DisbursementModel>();
        var q = from O in ctx.OutstandingRequests
                orderby O.Department.DepartmentName
                select new
                {
                    DepartmentID = O.DepartmentID,
                    Department = O.Department.DepartmentName,
                    ItemID = O.ItemID,
                    Description = O.Item.Description,
                    Needed = O.OutstandingQty,
                    InStock = O.Item.InStock

                };
        foreach (var a in q.ToList())
        {
            DisbursementModel dm = new DisbursementModel(a.DepartmentID, a.Department, a.ItemID, a.Description, a.Needed);
            dm.InStock = a.InStock;
            if (dm.NeededNumber != 0)
                list.Add(dm);
        }
        return list;
    }

    public Decimal getMaxPrice(string itemId)
    {
        
        var sql = from s in ctx.SupplyDetails where s.ItemID == itemId && s.Priority == 1 select s.Price;
        List<Decimal> pricelist = sql.ToList();
        return pricelist[0];
    }
    public List<ItemModel> showAllItems()
    {
        
        var sql = from i in ctx.Items
                  select new ItemModel
                  {
                      ItemID = i.ItemID,
                      Category = i.Category,
                      Description = i.Description,
                      ReorderLevel = i.ReorderLevel,
                      InStock = i.InStock,
                      UOM = i.UOM,
                  };
        ilist = sql.ToList();
        return ilist;
    }

    public List<ItemModel> searchItems(string category)
    {
        
        var sql = from i in ctx.Items
                  where i.Category.Contains(category) || i.Description.Contains(category)
                  select new ItemModel
                  {
                      ItemID = i.ItemID,
                      Category = i.Category,
                      Description = i.Description,
                      ReorderLevel = i.ReorderLevel,
                      InStock = i.InStock,
                      UOM = i.UOM,
                  };
        ilist = sql.ToList();
        return ilist;
    }
    public List<ItemDiscrepancyModel> getAllDiscrepancies(string selectedValue)
    {
        
        if (!selectedValue.Equals("ShowAll"))
        {
            var sql = from i in ctx.Items
                      join d in ctx.Discrepancies on i.ItemID equals d.ItemID
                      where d.Status == selectedValue
                      select new ItemDiscrepancyModel
                      {
                          DiscrepancyId = d.DiscrepancyID,
                          ItemCode = d.ItemID,
                          Description = i.Description,
                          Quantity = d.Quantity,
                          Reason = d.Reason,
                          Status = d.Status,
                      };
            idlist = sql.ToList();
        }
        else if (selectedValue.Equals("ShowAll"))
        {
            var sql = from i in ctx.Items
                      join d in ctx.Discrepancies on i.ItemID equals d.ItemID
                      select new ItemDiscrepancyModel
                      {
                          DiscrepancyId = d.DiscrepancyID,
                          ItemCode = d.ItemID,
                          Description = i.Description,
                          Quantity = d.Quantity,
                          Reason = d.Reason,
                          Status = d.Status,
                      };
            idlist = sql.ToList();
        }
        return idlist;
    }

    public string getMaxDiscrepancyId()
    {
        
        var sql = from d in ctx.Discrepancies orderby d.DiscrepancyID select d.DiscrepancyID;
        List<string> li = sql.ToList();
        List<int> newli = li.Select(x => int.Parse(x)).ToList();
        return newli.Max().ToString();
    }

    public int saveDiscrepancy(string discrepancyId, int quantity, string reason, string status, Item item)
    {
        
        Discrepancy discrepancy = new Discrepancy();
        discrepancy.DiscrepancyID = discrepancyId;
        discrepancy.Quantity = quantity;
        discrepancy.Reason = reason;
        discrepancy.Status = status;
        discrepancy.Item = item;
        ctx.Discrepancies.Add(discrepancy);
        return ctx.SaveChanges();
    }

    public Discrepancy getDiscrepancy(string id)
    {
        
        var sql = from d in ctx.Discrepancies where d.DiscrepancyID == id select d;
        discrepancy = sql.FirstOrDefault();
        return discrepancy;
    }

    public int updateDiscrepancy(string id, string status)
    {
        
        discrepancy = getDiscrepancy(id);
        var sql = from i in ctx.Items where i.ItemID == discrepancy.ItemID select i;
        item = sql.FirstOrDefault();
        if (status.Equals("Approved"))
        {
            discrepancy.Status = "Approved";
            item.InStock = item.InStock + discrepancy.Quantity;
        }
        else if (status.Equals("Rejected"))
        {
            discrepancy.Status = "Rejected";
        }
        return ctx.SaveChanges();
    }
    public int saveDiscrepancy(string discrepancyId, int quantity, string reason, string status, Item item, Staff staff, DateTime now)
    {
        
        Discrepancy discrepancy = new Discrepancy();
        discrepancy.DiscrepancyID = discrepancyId;
        discrepancy.Quantity = quantity;
        discrepancy.Reason = reason;
        discrepancy.Status = status;
        discrepancy.Item = item;
        discrepancy.Staff = staff;
        discrepancy.Date = now;
        ctx.Discrepancies.Add(discrepancy);
        return ctx.SaveChanges();
    }
    public List<Discrepancy> getSpecificDiscrepancies()
    {
        
        var sql = from d in ctx.Discrepancies
                  join i in ctx.Items on d.ItemID equals i.ItemID
                  join s in ctx.SupplyDetails on i.ItemID equals s.ItemID
                  where s.Price > 250 && d.Status == "Pending Approval"
                  select d;
        return sql.ToList();
    }
    public Staff getSpecificStaff(string staffId)
    {
        
        var sql = from s in ctx.Staffs where s.UserID == staffId select s;
        return sql.FirstOrDefault();
    }
    public string getEmailToPersonId(string itemPrice)
    {
        string emailId = "";
        if (Convert.ToDecimal(itemPrice) >= 250)
        {
            emailId = "54213";
        }
        else
        {
            emailId = "54188";
        }
        return emailId;
    }
    //method
    public  List<Department> GetDepartment()
    {
        

        List<Department> departmentlist = new List<Department>();
        ////foreach(Supplier sup in model.Supplier)
        ////{

        ////    supplierlist.Add(sup);
        ////}

        departmentlist = ctx.Departments.ToList<Department>();

        return departmentlist;


    }
    public  List<Department> GetCollectionPoint()
    {
        
        List<Department> departmentlist = new List<Department>();
        ////foreach(Supplier sup in model.Supplier)
        ////{

        ////    supplierlist.Add(sup);
        ////}

        departmentlist = ctx.Departments.GroupBy(x => new { x.Collection_Point }).Select(x => x.FirstOrDefault()).ToList<Department>();

        return departmentlist;


    }




    public  void UpdateDepartment(string DepartmentCode, string departmentname, string contact,
        string telephone, string headname, string collectionPoint, string repName)
    {


        //List<Department> departmentlist = new List<Department>();
        //departmentlist = ctx.Departments.Where(department => department.DepartmentID == DepartmentCode).ToList<Department>();
        //foreach (Department dept in departmentlist)
        //{
        //    dept.DepartmentName = departmentname;
        //    dept.ContactName = contact;
        //    dept.Telephone = telephone;
        //    dept.HeadName = headname;
        //    dept.Collection_Point = collectionPoint;
        //    dept.RepresentativeName = repName;

        //}
        //ctx.SaveChanges();
    }

    public  void DeleteDepartment(string departmentCode)
    {
        
        List<TransactionLog> transactionList = new List<TransactionLog>();
        transactionList = ctx.TransactionLogs.Where(x => x.DepartmentID == departmentCode).ToList();
        foreach (TransactionLog t in transactionList)
        {
            ctx.TransactionLogs.Remove(t);
        }
        ctx.SaveChanges();
        List<Department> departmentlist = new List<Department>();
        departmentlist = ctx.Departments.Where(department => department.DepartmentID == departmentCode).ToList<Department>();

        foreach (Department dept in departmentlist)
        {
            if (dept.DepartmentID == departmentCode)
            {
                ctx.Departments.Remove(dept);
            }
        }
        ctx.SaveChanges();
    }

    //Method name: CreateSupplier
    //CreateSupplier(SupplierCode, SupplierName, ContactName, PhoneNo, FaxNo, Address, GSTNo); 
    //input arguments are SupplierCode, SupplierName, ContactName, PhoneNo, FaxNo, Address, GSTNo
    //return type: void

    public  void CreateDepartment(string DepartmentCode, string departmentname, string contact,
        string telephone, string headname, string collectionPoint, string repName)
    {

        //List<Supplier> currentList = GetSupplier();
        //foreach(Supplier sup in currentList)
        //{
        //    if (sup.SupplierID==SupplierCode)
        //    {

        //        break; 
        //    }


        //Department toAddDepartment = new Department();


        //toAddDepartment.DepartmentID = DepartmentCode;
        //toAddDepartment.DepartmentName = departmentname;
        //toAddDepartment.ContactName = contact;
        //toAddDepartment.Telephone = telephone;

        //toAddDepartment.HeadName = headname;
        //toAddDepartment.Collection_Point = collectionPoint;
        //toAddDepartment.RepresentativeName = repName;

        //ctx.Departments.Add(toAddDepartment);
        //try
        //{
        //    ctx.SaveChanges();
        //}

        //catch (DbEntityValidationException ex)
        //{
        //    string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
        //    throw new DbEntityValidationException(errorMessages);
        //}

    }
    //method
    public  List<Item> GetItems()
    {
        
        List<Item> itemlist = new List<Item>();
        ////foreach(Supplier sup in model.Supplier)
        ////{

        ////    supplierlist.Add(sup);
        ////}

        itemlist = ctx.Items.ToList<Item>();

        return itemlist;


    }

    public  List<Item> GetCategory()
    {
        
        List<Item> itemlist = new List<Item>();
        ////foreach(Supplier sup in model.Supplier)
        ////{

        ////    supplierlist.Add(sup);
        ////}

        itemlist = ctx.Items.GroupBy(x => new { x.Category }).Select(x => x.FirstOrDefault()).ToList<Item>();

        return itemlist;


    }



    public  void UpdateItem(string ItemCode, string description, string category,
        string reorderLevel, string reorderQty, string uom)
    {
        
        List<Item> itemlist = new List<Item>();

        itemlist = ctx.Items.Where(item => item.ItemID == ItemCode).ToList<Item>();
        foreach (Item item in itemlist)
        {
            item.Description = description;
            item.Category = category;
            item.ReorderLevel = Convert.ToInt32(reorderLevel);
            item.ReorderQty = Convert.ToInt32(reorderQty);
            item.UOM = uom;

        }
        ctx.SaveChanges();
    }

    public  void DeleteItem(string itemCode)
    {
        
        List<Item> itemlist = new List<Item>();
        itemlist = ctx.Items.Where(item => item.ItemID == itemCode).ToList<Item>();

        foreach (Item item in itemlist)
        {
            if (item.ItemID == itemCode)
            {
                ctx.Items.Remove(item);
            }
        }
        ctx.SaveChanges();
    }

    //Method name: CreateSupplier
    //CreateSupplier(SupplierCode, SupplierName, ContactName, PhoneNo, FaxNo, Address, GSTNo); 
    //input arguments are SupplierCode, SupplierName, ContactName, PhoneNo, FaxNo, Address, GSTNo
    //return type: void

    public  void CreateItem(string ItemCode, string description,
        string Category, string ReorderLevel, string ReorderQty, string UOM, string binNo)
    {
        
        //List<Supplier> currentList = GetSupplier();
        //foreach(Supplier sup in currentList)
        //{
        //    if (sup.SupplierID==SupplierCode)
        //    {

        //        break; 
        //    }



        Item toAddItem = new Item();

        toAddItem.ItemID = ItemCode;
        toAddItem.Description = description;
        toAddItem.Category = Category;
        toAddItem.ReorderLevel = Convert.ToInt32(ReorderLevel);

        toAddItem.ReorderQty = Convert.ToInt32(ReorderQty);
        toAddItem.UOM = UOM;
        toAddItem.BinNumber = binNo;

        ctx.Items.Add(toAddItem);
        try
        {
            ctx.SaveChanges();
        }

        catch (DbEntityValidationException ex)
        {
            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
            throw new DbEntityValidationException(errorMessages);
        }
    }
    //method
    public  List<Supplier> GetSupplier()
    {
        
        List<Supplier> supplierlist = new List<Supplier>();
        ////foreach(Supplier sup in model.Supplier)
        ////{

        ////    supplierlist.Add(sup);
        ////}

        supplierlist = ctx.Suppliers.ToList<Supplier>();

        return supplierlist;


    }

    public  void UpdateSupplier(string SupplierCode, string SupplierName, string GSTRegistrationNo, string ContactName, string Phone, string Fax, string Address)
    {
        
        List<Supplier> supplierlist = new List<Supplier>();

        supplierlist = ctx.Suppliers.Where(sup => sup.SupplierID == SupplierCode).ToList<Supplier>();
        foreach (Supplier supt in supplierlist)
        {
            supt.SupplierName = SupplierName;
            supt.GSTRegistrationNo = GSTRegistrationNo;
            supt.ContactName = ContactName;
            supt.Phone = Phone;
            supt.Address = Address;
            supt.FaxNo = Fax;

        }
        ctx.SaveChanges();
    }

    public  void DeleteSupplier(string SupplierCode)
    {
        
        List<Supplier> supplierlist = new List<Supplier>();
        supplierlist = ctx.Suppliers.Where(sup => sup.SupplierID == SupplierCode).ToList<Supplier>();

        foreach (Supplier supt in supplierlist)
        {
            if (supt.SupplierID == SupplierCode)
            {
                ctx.Suppliers.Remove(supt);
            }
        }
        ctx.SaveChanges();
    }

    //Method name: CreateSupplier
    //CreateSupplier(SupplierCode, SupplierName, ContactName, PhoneNo, FaxNo, Address, GSTNo); 
    //input arguments are SupplierCode, SupplierName, ContactName, PhoneNo, FaxNo, Address, GSTNo
    //return type: void

    public  void CreateSupplier(string SupplierCode, string SupplierName, string ContactName, string PhoneNo, string FaxNo, string Address, string GSTNo, string email)
    {
        
        //List<Supplier> currentList = GetSupplier();
        //foreach(Supplier sup in currentList)
        //{
        //    if (sup.SupplierID==SupplierCode)
        //    {

        //        break; 
        //    }



        Supplier toAddSupplier = new Supplier();

        toAddSupplier.SupplierID = SupplierCode;
        toAddSupplier.SupplierName = SupplierName;
        toAddSupplier.GSTRegistrationNo = GSTNo;
        toAddSupplier.ContactName = ContactName;
        toAddSupplier.Phone = PhoneNo;
        toAddSupplier.FaxNo = FaxNo;
        toAddSupplier.Address = Address;
        toAddSupplier.Email = email;
        ctx.Suppliers.Add(toAddSupplier);
        try
        {
            ctx.SaveChanges();
        }

        catch (DbEntityValidationException ex)
        {
            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
            throw new DbEntityValidationException(errorMessages);
        }


    }

    public  void UpdateSupplierDetail(string SupplierCode, string itemid, decimal price, int priority)
    {

        
        List<SupplyDetail> supplydetaillist = new List<SupplyDetail>();

        supplydetaillist = ctx.SupplyDetails.Where(sup => sup.SupplierID == SupplierCode && sup.ItemID == itemid).ToList<SupplyDetail>();
        foreach (SupplyDetail suptdetail in supplydetaillist)
        {
            suptdetail.Price = price;
            suptdetail.Priority = priority;
        }
        ctx.SaveChanges();
    }

    public  void DeleteSupplierDetail(string SupplierCode, string ItemID)
    {
        
        List<SupplyDetail> supplierdetaillist = new List<SupplyDetail>();
        supplierdetaillist = ctx.SupplyDetails.Where(sup => sup.SupplierID == SupplierCode && sup.ItemID == ItemID).ToList<SupplyDetail>();

        foreach (SupplyDetail suptdetail in supplierdetaillist)
        {
            if (suptdetail.SupplierID == SupplierCode && suptdetail.ItemID == ItemID)
            {
                ctx.SupplyDetails.Remove(suptdetail);
            }
        }
        ctx.SaveChanges();
    }

    public  void CreateSupplierDetail(string SupplierCode, string ItemID, string Price, string priority)
    {

        
        SupplyDetail toAddSupplyDetail = new SupplyDetail();

        toAddSupplyDetail.SupplierID = SupplierCode;
        toAddSupplyDetail.ItemID = ItemID;
        toAddSupplyDetail.Price = Convert.ToDecimal(Price);
        toAddSupplyDetail.Priority = Convert.ToInt32(priority);

        ctx.SupplyDetails.Add(toAddSupplyDetail);
        try
        {
            ctx.SaveChanges();
        }

        catch (DbEntityValidationException ex)
        {
            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
            throw new DbEntityValidationException(errorMessages);
        }



    }
    public string isNormalStockNumber(string itemID, string quantity)
    {
        
        int result;
        string returnMessage = "";
        var sql = from i in ctx.Items where i.ItemID == itemID select i.InStock;
        if (!int.TryParse(quantity, out result))
        {
            return "Please enter positive/negative number!";
        }
        else if (Convert.ToInt32(quantity) > sql.FirstOrDefault())
        {
            return "Out range of stock!Please key in correct number!";
        }
        return returnMessage;
    }

    public  List<Item> GetUOM()
    {
        
        List<Item> itemlist = new List<Item>();
        ////foreach(Supplier sup in model.Supplier)
        ////{

        ////    supplierlist.Add(sup);
        ////}

        itemlist = ctx.Items.GroupBy(x => new { x.UOM }).Select(x => x.FirstOrDefault()).ToList<Item>();

        return itemlist;


    }

    public  void insertNotification(Notification n)
    {
        
        ctx.Notifications.Add(n);
        ctx.SaveChanges();
    }

    public List<DiscrepancySupplyDetailsModel> listPendingDiscrepancies(string userId)
    {
        
        DateTime now = DateTime.Now;
        var sql1 = from d in ctx.Delegations select d;
        var sql2 = from s in ctx.Staffs where s.UserID == userId select s.Role;
        List<string> role = sql2.ToList();
        List<Delegation> li1 = sql1.ToList();
        List<string> headId = new List<string>();
        String oneheadID = "";
        List<DiscrepancySupplyDetailsModel> li2 = new List<DiscrepancySupplyDetailsModel>();
        //DialogResult dr = MessageBox.Show("list", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
        if (role[0].Equals("Clerk"))
        {
            //DialogResult dr1 = MessageBox.Show("Employee", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
            for (int m = 0; m < li1.Count; m++)
            {
                if (li1[m].CoveringHeadID.Equals(userId) && li1[m].StartDate < now && li1[m].EndDate > now)
                {
                    headId.Add(li1[m].DepartmentHeadID);
                    oneheadID = headId[0];
                }
            }
            var head = from s in ctx.Staffs where s.UserID == oneheadID select s.Role;
            List<string> headRole = head.ToList();

            if (headId.Count == 2)
            {
                return listAllDiscrepancies(userId);
            }

            else if (headRole[0].Equals("Manager"))
            {
                return listManagerDiscrepancy(userId);
            }
            else if (headRole[0].Equals("Supervisor"))
            {
                return listSupervisorDiscrepancy(userId);
            }
        }
        else
        {
            //DialogResult dr1 = MessageBox.Show("Others", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
            for (int j = 0; j < li1.Count; j++)
            {
                if (userId.Equals(li1[j].CoveringHeadID) && li1[j].StartDate < now && li1[j].EndDate > now)
                {
                    return listAllDiscrepancies();
                }
            }
            if (role[0].Equals("Manager"))
            {
                //DialogResult dr2 = MessageBox.Show("Manager", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                li2 = listManagerDiscrepancy();
            }
            else if (role[0].Equals("Supervisor"))
            {
                //DialogResult dr2 = MessageBox.Show("Supervisor", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                li2 = listSupervisorDiscrepancy();
            }
        }
        return li2;
    }

    private List<DiscrepancySupplyDetailsModel> listSupervisorDiscrepancy(string userId)
    {
        
        //getMaxPrice(string itemId);
        var sql = from d in ctx.Discrepancies
                  join st in ctx.Staffs on d.UserID equals st.UserID
                  join i in ctx.Items on d.ItemID equals i.ItemID
                  join s in ctx.SupplyDetails on i.ItemID equals s.ItemID
                  where d.UserID != userId && s.Priority == 1 && s.Price < 250 && d.Status == "Pending Approval"
                  group new { d.DiscrepancyID } by new { d.DiscrepancyID, st.Name, d.ItemID, i.Description, d.Quantity, d.Reason, s.Price } into a
                  select new DiscrepancySupplyDetailsModel
                  {
                      DiscrepancyId = a.Key.DiscrepancyID,
                      Requester = a.Key.Name,
                      ItemID = a.Key.ItemID,
                      Description = a.Key.Description,
                      Quantity = a.Key.Quantity,
                      Reason = a.Key.Reason,
                      Price = a.Key.Price,
                  };
        return sql.ToList();
    }

    private List<DiscrepancySupplyDetailsModel> listManagerDiscrepancy(string userId)
    {
        
        var sql = from d in ctx.Discrepancies
                  join st in ctx.Staffs on d.UserID equals st.UserID
                  join i in ctx.Items on d.ItemID equals i.ItemID
                  join s in ctx.SupplyDetails on i.ItemID equals s.ItemID
                  where d.UserID != userId && s.Priority == 1 && s.Price >= 250 && d.Status == "Pending Approval"
                  group new { d.DiscrepancyID } by new { d.DiscrepancyID, st.Name, d.ItemID, i.Description, d.Quantity, d.Reason, s.Price } into a
                  select new DiscrepancySupplyDetailsModel
                  {
                      DiscrepancyId = a.Key.DiscrepancyID,
                      Requester = a.Key.Name,
                      ItemID = a.Key.ItemID,
                      Description = a.Key.Description,
                      Quantity = a.Key.Quantity,
                      Reason = a.Key.Reason,
                      Price = a.Key.Price,
                  };
        return sql.ToList();
    }

    private List<DiscrepancySupplyDetailsModel> listAllDiscrepancies(string userId)
    {
        
        var sql = from d in ctx.Discrepancies
                  join st in ctx.Staffs on d.UserID equals st.UserID
                  join i in ctx.Items on d.ItemID equals i.ItemID
                  join s in ctx.SupplyDetails on i.ItemID equals s.ItemID
                  where d.UserID != userId && s.Priority == 1 && d.Status == "Pending Approval"
                  group new { d.DiscrepancyID } by new { d.DiscrepancyID, st.Name, d.ItemID, i.Description, d.Quantity, d.Reason, s.Price } into a
                  select new DiscrepancySupplyDetailsModel
                  {
                      DiscrepancyId = a.Key.DiscrepancyID,
                      Requester = a.Key.Name,
                      ItemID = a.Key.ItemID,
                      Description = a.Key.Description,
                      Quantity = a.Key.Quantity,
                      Reason = a.Key.Reason,
                      Price = a.Key.Price,
                  };
        return sql.ToList();
    }

    public List<DiscrepancySupplyDetailsModel> listAllDiscrepancies()
    {
        
        var sql = from d in ctx.Discrepancies
                  join st in ctx.Staffs on d.UserID equals st.UserID
                  join i in ctx.Items on d.ItemID equals i.ItemID
                  join s in ctx.SupplyDetails on i.ItemID equals s.ItemID
                  where s.Priority == 1 && d.Status == "Pending Approval"
                  group new { d.DiscrepancyID } by new { d.DiscrepancyID, st.Name, d.ItemID, i.Description, d.Quantity, d.Reason, s.Price } into a
                  select new DiscrepancySupplyDetailsModel
                  {
                      DiscrepancyId = a.Key.DiscrepancyID,
                      Requester = a.Key.Name,
                      ItemID = a.Key.ItemID,
                      Description = a.Key.Description,
                      Quantity = a.Key.Quantity,
                      Reason = a.Key.Reason,
                      Price = a.Key.Price,
                  };
        return sql.ToList();
    }

    public List<DiscrepancySupplyDetailsModel> listManagerDiscrepancy()
    {
        
        var sql = from d in ctx.Discrepancies
                  join st in ctx.Staffs on d.UserID equals st.UserID
                  join i in ctx.Items on d.ItemID equals i.ItemID
                  join s in ctx.SupplyDetails on i.ItemID equals s.ItemID
                  where s.Priority == 1 && s.Price >= 250 && d.Status == "Pending Approval"
                  group new { d.DiscrepancyID } by new { d.DiscrepancyID, st.Name, d.ItemID, i.Description, d.Quantity, d.Reason, s.Price } into a
                  select new DiscrepancySupplyDetailsModel
                  {
                      DiscrepancyId = a.Key.DiscrepancyID,
                      Requester = a.Key.Name,
                      ItemID = a.Key.ItemID,
                      Description = a.Key.Description,
                      Quantity = a.Key.Quantity,
                      Reason = a.Key.Reason,
                      Price = a.Key.Price,
                  };
        return sql.ToList();
    }

    public List<DiscrepancySupplyDetailsModel> listSupervisorDiscrepancy()
    {
        
        var sql = from d in ctx.Discrepancies
                  join st in ctx.Staffs on d.UserID equals st.UserID
                  join i in ctx.Items on d.ItemID equals i.ItemID
                  join s in ctx.SupplyDetails on i.ItemID equals s.ItemID
                  where s.Priority == 1 && s.Price < 250 && d.Status == "Pending Approval"
                  group new { d.DiscrepancyID } by new { d.DiscrepancyID, st.Name, d.ItemID, i.Description, d.Quantity, d.Reason, s.Price } into a
                  select new DiscrepancySupplyDetailsModel
                  {
                      DiscrepancyId = a.Key.DiscrepancyID,
                      Requester = a.Key.Name,
                      ItemID = a.Key.ItemID,
                      Description = a.Key.Description,
                      Quantity = a.Key.Quantity,
                      Reason = a.Key.Reason,
                      Price = a.Key.Price,
                  };
        return sql.ToList();
    }


    public  string GetSupplierDetails(decimal price, string supplierLabel)
    {
        
        var q = from a in ctx.Suppliers
                where a.SupplierID == supplierLabel
                select a;
        Supplier sd = q.First();
        string result = "<ul><li> Contact name: <b>" + sd.ContactName + "</b></li><br/><li> Contact No: <b>" + sd.Phone + "</b></li><br/><li> Fax No : <b>" + sd.FaxNo + "</b></li><br/><li> Price: <b>" + price + "</b></li></ul>";
        return result;
    }

    public  SupplyDetail GetSupplier(int priority, string itemid)
    {
        
        var qry = from x in ctx.SupplyDetails
                  where x.ItemID == itemid && x.Priority == priority
                  select x;
        SupplyDetail s = qry.First();
        return s;
    }

    public  string ShowComment(string orderID)
    {
        
        string cmt = "";
        var q = from x in ctx.Orders
                where x.OrderID == orderID
                select x;
        Order com = q.First();
        cmt = com.Comment;
        return cmt;
    }

    public  Order InsertNewOrder(string itemid, string quantity, string justification)
    {
        
        Order o = new Order();
        Order od = ctx.Orders.OrderByDescending(x => x.OrderID).FirstOrDefault();
        if (od == null)
        {
            o.OrderID = "DO0000001";
        }
        else
        {
            string a = od.OrderID.Substring(0, 2);
            int b = Convert.ToInt32(od.OrderID.Substring(2, 7));
            int x = b + 1;
            string newID = String.Format("{0:0000000}", x);
            newID = newID.Insert(0, a);
            o.OrderID = newID;
        }
        o.ItemID = itemid;
        o.TotalQty = Convert.ToInt32(quantity);
        o.Justification = justification;
        o.Status = "PendingApproval";
        o.OrderDate = DateTime.Now;
        o.UserID = "00242"; //temporarily hardcode

        return o;
    }

    public  void UpdateOrder(string orderid, string qty, string justification)
    {
        
        Order o = ctx.Orders.Where(x => x.OrderID == orderid).First();
        o.TotalQty = Convert.ToInt32(qty);
        if (justification != String.Empty)
        {
            o.Justification = justification;
        }
        ctx.SaveChanges();
    }

    public  void UpdateOrderStatus(string orderid, string stt)
    {
        
        Order o = ctx.Orders.Where(x => x.OrderID == orderid).First();
        o.Status = stt;
        ctx.SaveChanges();
    }

    public  void UpdateComment(string orderID, string comment)
    {
        
        Order o = ctx.Orders.Where(x => x.OrderID == orderID).First();
        o.Comment = comment;
        ctx.SaveChanges();
    }

    public  void UpdateOrderDetails(string poNumber)
    {
        
        OrderDetail od = ctx.OrderDetails.Where(x => x.PurchaseOrderID == poNumber).First();
        od.ReceivedQty = od.OrderQty;
        ctx.SaveChanges();
    }

    public  void UpdateItemStock(string orderID, string itemID)
    {
        
        Order o = ctx.Orders.Where(x => x.OrderID == orderID).First();
        Item i = ctx.Items.Where(x => x.ItemID == itemID).First();
        int updatedStock = i.InStock + o.TotalQty;
        i.InStock = updatedStock;
        ctx.SaveChanges();
    }

    public  List<WCFNotification> ViewNotificationByUserID(string userID)
    {
        
        List<Notification> nList = ctx.Notifications.Where(x => x.UserID == userID).ToList();

        List<WCFNotification> wcfnList = new List<WCFNotification>();
        foreach (Notification notification in nList)
        {

            WCFNotification wn = new WCFNotification(notification.NotificationID, userID, notification.Subject, notification.Message, notification.Status, notification.Date);
            wcfnList.Add(wn);

        }
        return wcfnList;
    }



    public  Order getOrderById(string id)
    {
        
        return ctx.Orders.Where(x => x.OrderID == id).ToList().FirstOrDefault();
    }



    public  List<OrderModel> listPendingOrder()
    {
        
        List<OrderModel> list = new List<OrderModel>();
        var q = from x in ctx.Orders
                where x.Status == "PendingApproval"
                orderby x.OrderDate
                select new { x.OrderID, x.ItemID, x.Item.Category, x.Item.Description, x.TotalQty, x.Justification };

        foreach (var a in q.ToList())
        {
            OrderModel ol = new OrderModel(a.OrderID, a.ItemID, a.Category, a.Description, a.TotalQty, a.Justification);
            list.Add(ol);
        }
        return list;
    }

    public  List<String> getOrderStatus()
    {
        //
        //var list = ctx.Orders.GroupBy(y => y.Status).Select(x => x.FirstOrDefault()).ToList();
        //return list.Select(o => o.Status).ToList();
        string[] status = new string[6] { "PendingApproval", "Cancelled", "Rejected", "Approved", "Ordered", "Completed" };
        return status.ToList();
    }

    public  List<String> getOrderHistoryStatus()
    {
        // var list = ctx.Orders.GroupBy(y => y.Status).Select(x => x.FirstOrDefault()).ToList();
        // return list.Select(o => o.Status).Where(o => !o.Contains("PendingApproval")).ToList();
        string[] stt = new string[5] { "Cancelled", "Rejected", "Approved", "Ordered", "Completed" };
        return stt.ToList();
    }

    public  List<OrderModel> getOrderList()
    {
        
        List<OrderModel> oList = new List<OrderModel>();
        var q = from x in ctx.Orders
                orderby x.OrderDate descending
                select new { x.OrderID, x.ItemID, x.Item.Description, x.TotalQty, x.Justification, x.OrderDate, x.Status };

        foreach (var a in q.ToList())
        {
            OrderModel ol = new OrderModel(a.OrderID, a.ItemID, a.Description, a.TotalQty, a.Justification, a.OrderDate, a.Status);
            oList.Add(ol);
        }
        return oList;
    }

    public  List<OrderModel> getOrderHistory()
    {
        
        List<OrderModel> oList = new List<OrderModel>();
        var q = from x in ctx.Orders
                where x.Status != "PendingApproval"
                orderby x.OrderDate descending
                select new { x.OrderID, x.ItemID, x.Item.Category, x.Item.Description, x.TotalQty, x.Justification, x.Status, x.OrderDate, x.Comment };

        foreach (var a in q.ToList())
        {
            OrderModel ol = new OrderModel(a.OrderID, a.ItemID, a.Category, a.Description, a.TotalQty, a.Justification, a.Status, a.OrderDate, a.Comment);
            oList.Add(ol);
        }
        return oList;
    }

    public  List<OrderModel> getOrderList(string stt)
    {
        
        List<OrderModel> list = new List<OrderModel>();
        if (!stt.Equals("Show All"))
        {
            var q = from x in ctx.Orders
                    where x.Status == stt
                    orderby x.OrderDate descending
                    select new { x.OrderID, x.ItemID, x.Item.Description, x.TotalQty, x.Justification, x.Status };

            foreach (var a in q.ToList())
            {
                OrderModel ol = new OrderModel(a.OrderID, a.ItemID, a.Description, a.TotalQty, a.Justification, a.Status);
                list.Add(ol);
            }
        }
        else
        {
            list = getOrderList();
        }
        return list;
    }

    public  List<OrderModel> getOrderHistory(string stt)
    {
        
        List<OrderModel> list = new List<OrderModel>();
        if (!stt.Equals("Show All"))
        {
            var q = from x in ctx.Orders
                    where x.Status == stt
                    orderby x.OrderDate descending
                    select new { x.OrderID, x.ItemID, x.Item.Category, x.Item.Description, x.TotalQty, x.Justification, x.Status, x.OrderDate, x.Comment };

            foreach (var a in q.ToList())
            {
                OrderModel ol = new OrderModel(a.OrderID, a.ItemID, a.Category, a.Description, a.TotalQty, a.Justification, a.Status, a.OrderDate, a.Comment);
                list.Add(ol);
            }
        }
        else
        {
            list = getOrderHistory();
        }
        return list;
    }

    public  string InsertNewOrder(string itemid, string quantity, string justification, string userId)
    {
        
        Order o = new Order();
        Order od = ctx.Orders.OrderByDescending(x => x.OrderID).FirstOrDefault();
        if (od == null)
        {
            o.OrderID = "DO0000001";
        }
        else
        {
            string a = od.OrderID.Substring(0, 2);
            int b = Convert.ToInt32(od.OrderID.Substring(2, 7));
            int x = b + 1;
            string newID = String.Format("{0:0000000}", x);
            newID = newID.Insert(0, a);
            o.OrderID = newID;
        }
        o.ItemID = itemid;
        o.TotalQty = Convert.ToInt32(quantity);
        o.Justification = justification;
        o.Status = "PendingApproval";
        o.OrderDate = DateTime.Now;
        o.UserID = userId;

        ctx.Orders.Add(o);
        ctx.SaveChanges();

        return o.OrderID;
    }






    public  List<OrderDetail> getOrderDetailsList(string orderID)
    {
        
        return ctx.OrderDetails.Where(x => x.OrderID == orderID).ToList();
    }

    public  string InsertOrderDetails(string supplier, string qty, string orderid)
    {
        
        OrderDetail o = new OrderDetail();
        OrderDetail od = ctx.OrderDetails.OrderByDescending(x => x.PurchaseOrderID).FirstOrDefault();
        if (od == null)
        {
            o.PurchaseOrderID = "PO0000001";
        }
        else
        {
            string a = od.PurchaseOrderID.Substring(0, 2);
            int b = Convert.ToInt32(od.PurchaseOrderID.Substring(2, 7));
            int x = b + 1;
            string newID = String.Format("{0:0000000}", x);
            newID = newID.Insert(0, a);
            o.PurchaseOrderID = newID;
        }
        o.OrderID = orderid;
        o.SupplierID = supplier;
        o.OrderQty = Convert.ToInt32(qty);
        o.ReceivedQty = 0;

        ctx.OrderDetails.Add(o);
        ctx.SaveChanges();

        return o.PurchaseOrderID;
    }
    /// <summary>
    /// For bySummary, get Retrieve Summary
    /// For byDepartment Get Retrieve Log and Given Log
    /// </summary>
    /// <param name="bySummary"></param>
    /// <param name="byDepartment"></param>
    /// <returns></returns>
    public  int GetRetrieveLog(List<DisbursementModel> bySummary, List<DisbursementModel> byDepartment)
    {
        HistoryDisbursement finder = new HistoryDisbursement();
        int result = finder.GetProgressingLog();
        if (result != 0)
        {
            foreach (DisbursementModel dm in bySummary)
                if (finder.SummaryByItem.ContainsKey(dm.ItemID))
                    dm.RetrivedNumber = Convert.ToInt32(finder.SummaryByItem[dm.ItemID].RetrivedNumber);
            foreach (DisbursementModel dm in byDepartment)
                if (finder.SummaryByDepartment.ContainsKey(dm.DepartmentID))
                    if (finder.SummaryByDepartment[dm.DepartmentID].ContainsKey(dm.ItemID))
                    {
                        dm.RetrivedNumber = Convert.ToInt32(finder.SummaryByDepartment[dm.DepartmentID][dm.ItemID].RetrivedNumber);
                        dm.GivenNumber = Convert.ToInt32(finder.SummaryByDepartment[dm.DepartmentID][dm.ItemID].GivenNumber);
                    }
        }
        return result;
    }
    /// <summary>
    /// Clerk Submit Retrieve List, and will update database
    /// </summary>
    /// <param name="listByDepartment"></param>
    /// <returns></returns>
    private  int SubmitRetrieve(List<DisbursementModel> listByDepartment)
    {
        Transaction clerk = new Transaction();
        foreach (DisbursementModel dm in listByDepartment)
        {
            int res = clerk.Retrieve(dm.ItemID, dm.DepartmentID, dm.RetrivedNumber);
            if (res < 0) return res;
        }
        return 0;
    }
    /// <summary>
    /// Clerk change number by Summary
    /// </summary>
    /// <param name="listBySummary"></param>
    /// <param name="listByDepartment"></param>
    /// <returns></returns>
    public  int SubmitSummary(List<DisbursementModel> listBySummary, List<DisbursementModel> listByDepartment)
    {
        // Validation of changing number
        foreach (DisbursementModel dm in listBySummary)
        {
            if (dm.NeededNumber < dm.RetrivedNumber)
                return -1001;   // Over Needed
            if (dm.InStock < dm.RetrivedNumber)
                return -1002;   // Over InStock
        }

        // Update By Department by Auto Allocate
        AutoAllocate automator = new AutoAllocate();
        Dictionary<string, int> dic1 = new Dictionary<string, int>();
        foreach (DisbursementModel dm in listBySummary)
            dic1.Add(dm.ItemID, dm.RetrivedNumber);
        Dictionary<string, Dictionary<string, int>> dic2 = automator.AllocateAllDepartment(dic1);
        foreach (DisbursementModel model in listByDepartment)
            model.RetrivedNumber = dic2[model.DepartmentID][model.ItemID];

        // Submit to write RetrieveLogs
        return SubmitRetrieve(listByDepartment);
    }
    /// <summary>
    /// Clerk change number byDepartment
    /// </summary>
    /// <param name="listBySummary"></param>
    /// <param name="listByDepartment"></param>
    /// <returns></returns>
    public  int SubmitByDepartment(List<DisbursementModel> listBySummary, List<DisbursementModel> listByDepartment)
    {
        // Update listBySummary
        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < listByDepartment.Count(); i++)
        {
            if (dic.ContainsKey(listByDepartment[i].ItemID))
                dic[listByDepartment[i].ItemID] += listByDepartment[i].RetrivedNumber;
            else
                dic.Add(listByDepartment[i].ItemID, listByDepartment[i].RetrivedNumber);
        }

        int res1 = 0;
        // Check Discrepency in BySummary and ByDepartment
        // And Validation of changing number
        foreach (DisbursementModel dm in listBySummary)
        {
            if (dic.ContainsKey(dm.ItemID))
                dm.RetrivedNumber = dic[dm.ItemID];
        }
        foreach (DisbursementModel dm in listBySummary)
        {

            int num = dic[dm.ItemID];
            if (dm.NeededNumber < num)
                return -1001;   // Over Needed
            if (dm.InStock < num)
                return -1002;   // Over InStock
            if (num != dm.RetrivedNumber)
                res1 = 1;        // Discrepency in BySummary and ByDepartment
        }


        // Submit to write RetrieveLogs
        int res2 = SubmitRetrieve(listByDepartment);
        if (res2 == 0)
            return res1;
        return res2;
    }
    /// <summary>
    /// Clerk Submit to Deliver Item at Collection
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public  int SubmitDeliver(List<DisbursementModel> list)
    {
        Transaction clerk = new Transaction();
        foreach (DisbursementModel dm in list)
        {
            if (dm.GivenNumber > dm.NeededNumber)
                return -1001;   // given > needed;
            if (dm.GivenNumber > dm.InStock)
                return -1002;   // given > instock;
            if (dm.GivenNumber > dm.RetrivedNumber)
                return -1003;   // given > retrieved;
        }
        for (int i = 0; i < list.Count(); i++)
        {
            int res = clerk.Give(list[i].ItemID, list[i].DepartmentID, list[i].GivenNumber);
            if (res < 0) return res;
        }
        return 0;
    }
    /// <summary>
    /// Dept Rep confirmation and update database
    /// This action will end an transaction
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public  int SubmitReceive(List<DisbursementModel> list)
    {
        Transaction clerk = new Transaction();
        foreach (DisbursementModel dm in list)
        {
            if (dm.GivenNumber > dm.NeededNumber)
                return -1001;   // given > needed;
            if (dm.GivenNumber > dm.InStock)
                return -1002;   // given > instock;
            if (dm.GivenNumber > dm.RetrivedNumber)
                return -1003;   // given > retrieved;
        }
        for (int i = 0; i < list.Count(); i++)
        {
            int res = clerk.Receive(list[i].ItemID, list[i].DepartmentID, list[i].GivenNumber);
            if (res < 0) return res;
        }
        return 0;
    }
}