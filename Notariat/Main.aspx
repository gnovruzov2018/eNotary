<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Notariat.Main" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Depozitar-klirinq sistemləri ilə inteqrasiya</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" 
                runat="server" 
                AutoGenerateColumns="false"
                CssClass="mydatagrid" 
                PagerStyle-CssClass="pager"
                HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" 
                AllowPaging="True" 
                PageSize="10">
               
                <Columns>
                    <asp:BoundField DataField="StatusName" HeaderText="Status"  />
                    <asp:BoundField DataField="TrackingCode" HeaderText="Tracking Code"  />
                    <asp:BoundField DataField="NotaryOfficeName" HeaderText="Notariat Kontoru" />
                    <asp:BoundField DataField="UpdateDate" HeaderText="Tarix və saat" />
                    <asp:BoundField DataField="ActionRowId" HeaderText="Açar" />
                </Columns> 
            </asp:GridView>

            <br />
         </div>

         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div>
             <br />
             <asp:Button ID="Button1" Text="Open!" runat="server" />
             <br />
             <br />
             <asp:Panel ID="Panel1" CssClass="modalPopup" runat="server">
                 <table>
                     <tr>
                         <td>
                             <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                         </td>
                     </tr>
                 </table>
             </asp:Panel>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
           TargetControlID="Button1" PopupControlID="Panel1"  BackgroundCssClass="modalBackground" />
         </div>


        <%-- <div>
            <asp:GridView ID="GridView2" 
                runat="server" 
                AutoGenerateColumns="false"
                AllowPaging="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID"  />
                    <asp:BoundField DataField="Type" HeaderText="Tip"  />
                    <asp:BoundField DataField="Name" HeaderText="Ad" />
                    <asp:BoundField DataField="UniqueCode" HeaderText="Unikal kodu" />
                    <asp:BoundField DataField="IDCardSeries" HeaderText="Kartın seriyası" />
                    <asp:BoundField DataField="IDCardNumber" HeaderText="Kartın nömrəsis" />
                </Columns> 
            </asp:GridView>
            <br />
         </div>--%>

    </form>
</body>
</html>
