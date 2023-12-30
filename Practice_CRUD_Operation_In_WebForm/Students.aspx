<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="Practice_CRUD_Operation_In_WebForm.Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name :</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Enrollment No :</td>
                    <td>
                        <asp:TextBox ID="txtEnrollmentNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Gender :</td>
                    <td>
                        <asp:RadioButtonList ID="rblGender" runat="server">

                            <%-- Static Binding--%>
                            <%--<asp:ListItem Text="Male" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>--%>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td>Address :</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Course :</td>
                    <td>
                        <asp:DropDownList ID="ddlCourse" runat="server">
                            <%-- Static Binding --%>
                            <%-- <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="BCA" Value="1"></asp:ListItem>
                            <asp:ListItem Text="MCA" Value="2"></asp:ListItem>
                            <asp:ListItem Text="B.Tech" Value="3"></asp:ListItem>
                            <asp:ListItem Text="M.Tech" Value="4"></asp:ListItem>
                            <asp:ListItem Text="B.Com" Value="5"></asp:ListItem>
                            <asp:ListItem Text="BA" Value="6"></asp:ListItem>--%>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Country</td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>State</td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:GridView ID="gvemployee" runat="server" OnRowCommand="gvemployee_RowCommand" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Student ID">
                                    <ItemTemplate>
                                        <%#Eval("Student_Id")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <%#Eval("Student_Name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enrollment No">
                                    <ItemTemplate>
                                        <%#Eval("Student_Enrollment_No")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender">
                                    <ItemTemplate>
                                        <%-- <%#Eval("Student_Gender").ToString()=="1" ? "Male" :Eval("Student_Gender").ToString()=="2" ? "Female" : "Other" %>--%>
                                        <%#Eval("Gender_name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <%#Eval("Student_Address")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course">
                                    <ItemTemplate>
                                        <%-- <%#Eval("Student_Course").ToString()=="1" ? "BCA" :Eval("Student_Course").ToString()=="2" ? "MCA" : Eval("Student_Course").ToString()=="3" ? "B.Tech" :Eval("Student_Course").ToString()=="4" ? "M.Tech" :Eval("Student_Course").ToString()=="5" ? "B.com" : "BA"%>--%>
                                        <%#Eval("Course_name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Country">
                                    <ItemTemplate>
                                        <%#Eval("country_name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State">
                                    <ItemTemplate>
                                        <%#Eval("state_name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="D" CommandArgument='<%#Eval("Student_Id") %>'></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="E" CommandArgument='<%#Eval("Student_Id") %>'></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
