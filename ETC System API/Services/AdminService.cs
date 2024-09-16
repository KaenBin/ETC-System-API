//using ETC_System_API.Models;

//namespace ETC_System_API.Services;

//public static class Adminervice
//{
//    static List<Admin> Admin { get; }
//    static int nextId = 3;
//    static Adminervice()
//    {
//        Admin = new List<Admin>
//        {
//            new Admin { Id = 1, FirstName = "Admin1", LastName = "Admin1", ContactInfo = "admin@example.com" },
//            new Admin { Id = 2, FirstName = "Owner1", LastName = "Owner1", ContactInfo = "owner@example.com" }
//        };
//    }

//    public static List<Admin> GetAll() => Admin;

//    public static Admin? Get(int id) => Admin.FirstOrDefault(p => p.Id == id);

//    public static void Add(Admin Admin)
//    {
//        Admin.Id = nextId++;
//        Admin.Add(Admin);
//    }

//    public static void Delete(int id)
//    {
//        var Admin = Get(id);
//        if (Admin is null)
//            return;

//        Admin.Remove(Admin);
//    }

//    public static void Update(Admin Admin)
//    {
//        var index = Admin.FindIndex(p => p.Id == Admin.Id);
//        if (index == -1)
//            return;

//        Admin[index] = Admin;
//    }
//}