<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ListCategory.aspx.cs" Inherits="Admin_ListCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="table-responsive">
        <table class="table">
            <thead>
                <tr>
                    <th>Nhóm 1</th>
                    <th>Nhóm 2</th>
                    <th>Nhóm 3</th>
                    <th>Nhóm 4</th>
                    <th>Nhóm 5</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class ="CategoryItem"><a href ="TonGiao.aspx">Tôn giáo</a></td>
                    <td class ="CategoryItem"><a href ="DanToc.aspx">Dân tộc</a></td>
                    <td class ="CategoryItem"><a href ="ChucVu.aspx">Chức vụ</a></td>
                    <td class ="CategoryItem"><a href ="LinhVuc.aspx">Lĩnh vực</a></td>
                    <td class ="CategoryItem"><a href ="HinhThucTuyenDung.aspx">Hình thức tuyển dụng</a></td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td class ="CategoryItem"><a href ="HinhThucDangKy.aspx">Hình thức đăng ký</a></td>
                    <td class ="CategoryItem"><a href ="TuVan.aspx">Tư vấn</a></td>
                    <td class ="CategoryItem"><a href ="LoaiHopDong.aspx">Loại hợp đồng</a></td>
                    <td class ="CategoryItem"><a href ="CanBo.aspx">Cán bộ</a></td>
                    <td class ="CategoryItem"><a href ="KetQuaTuVan.aspx">Kết quả tư vấn</a></td>
                </tr>
            </tbody>
             <tbody>
                <tr>
                    <td class ="CategoryItem"><a href ="KetQuaHoSo.aspx">Kết quả hồ sơ</a></td>
                    <td class ="CategoryItem"><a href ="Business.aspx">Ngành nghề kinh doanh</a></td>
                    <td class ="CategoryItem"><a href ="TrinhDoTinHoc.aspx">Trình độ tin học</a></td>
                    <td class ="CategoryItem"><a href ="TrinhDoNgoaiNgu.aspx">Trình độ ngoại ngữ</a></td>
                    <td class ="CategoryItem"><a href ="LoaiHinhDoanhNghiep.aspx">Loại hình doanh nghiệp</a></td>
                </tr>
            </tbody>
            <tbody>
                <tr>
                    <td class ="CategoryItem"><a href ="NhomNganh.aspx">Nhóm ngành</a></td>
                    <td class ="CategoryItem"><a href ="NganhNghe.aspx">Ngành nghề</a></td>
                    <td class ="CategoryItem"><a href ="#">Đào tạo, khóa học</a></td>
                    <td class ="CategoryItem"><a href ="QuocGiaList.aspx">Quốc gia</a></td>
                    <td class ="CategoryItem"><a href ="ViTri.aspx">Vị trí</a></td>
                </tr>
            </tbody>
            <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
                <HeaderTemplate>
                    <tbody>
                        <tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <td class ="CategoryItem"><a href ="DanhMuc.aspx?id=<%# Eval("IdDanhMuc") %>"><%# Eval("NameDanhMuc") %></a></td>
                </ItemTemplate>
                <SeparatorTemplate>
                    <% if(index++ % 5 == 0 ){ %>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr>
                    <% } %>
                </SeparatorTemplate>
                <FooterTemplate>
                        </tr>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

