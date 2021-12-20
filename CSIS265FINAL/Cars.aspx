<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Cars.aspx.cs" Inherits="CSIS265FINAL.Cars"   EnableEventValidation ="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Car Data"></asp:Label>
</p>
<p>
    <asp:HiddenField runat="server" ID="hdnId" />
    <asp:Label ID="Label2" runat="server" Text="Make: "></asp:Label>
    <asp:TextBox ID="txtMake" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label3" runat="server" Text="Model: "></asp:Label>
    <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label runat="server" Text="Color: "></asp:Label>
    <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label5" runat="server" Text="Weight: "></asp:Label>
    <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label6" runat="server" Text="Mpg: "></asp:Label>
    <asp:TextBox ID="txtMpg" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnAddCar" runat="server" OnClick="btnAddCar_Click" Text="AddCar" />
</p>
    <p>
        <asp:Label ID="txtAddSucsses" runat="server" BorderStyle="None" ForeColor="#66FF99"></asp:Label>
</p>
 
    <p>
        <asp:Label ID="txtErorr" runat="server" BorderStyle="None" ForeColor="red"></asp:Label>
</p>
      <p>
        <asp:Repeater ID="rptData" runat="server">
            <HeaderTemplate>
                <table>

                
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                      <td>
                          <asp:Label runat="server" Id="lblId" Text='<%#Eval("ID") %>' ></asp:Label>
                      </td>
                     <td>
                          <asp:Label runat="server" Id="LblMake" Text='<%#Eval("MAKE") %>' ></asp:Label>
                      </td>
                     <td>
                          <asp:Label runat="server" Id="LblModel" Text='<%#Eval("MODEL") %>' ></asp:Label>
                      </td>
                     <td>
                          <asp:Label runat="server" Id="LblColor" Text='<%#Eval("COLOR") %>' ></asp:Label>
                      </td>
                     <td>
                          <asp:Label runat="server" Id="LblWeight" Text='<%#Eval("WEIGHT") %>' ></asp:Label>
                      </td>
                     <td>
                          <asp:Label runat="server" Id="LblMpg" Text='<%#Eval("MPG") %>' ></asp:Label>
                      </td>
                    <td>
                          <asp:button runat="server" Id="btnEdit" Text='Edit' onClick="btnEdit_Click" ></asp:button>
                      </td>
                    <td>
                          <asp:button runat="server" Id="btnDelete" Text='Delete' onClick="btnDelete_Click" ></asp:button>
                      </td>

                </tr>

            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </p>

    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
