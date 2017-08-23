<%@ Application Language="C#" %>
<%@ Import Namespace="STORE" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        DanhMuc objDanhMuc = new DanhMuc();
        TVSSystem.NoiCapCMND = objDanhMuc.getIdDanhMucByName("Nơi cấp CMND");
        TVSSystem.NoiChotSoCuoi = objDanhMuc.getIdDanhMucByName("Nơi chốt sổ cuối");
        TVSSystem.NoiDangKyKhamBenh = objDanhMuc.getIdDanhMucByName("Nơi đăng ký khám bệnh");
        TVSSystem.NoiNhanBaoHiem = objDanhMuc.getIdDanhMucByName("Nơi nhận bảo hiểm");
        TVSSystem.LyDoDangKytre = objDanhMuc.getIdDanhMucByName("Lý do đăng ký trễ");
        //Application[""]
    }
</script>
