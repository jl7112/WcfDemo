<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" EnableEventValidation="false"  Inherits="Client.MainForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var prevselitem = null;
        function selectx(row) {
            if (prevselitem != null) {
                prevselitem.style.backgroundColor = '#ffffff';
            }
            row.style.backgroundColor = 'PeachPuff';
            prevselitem = row;

        }
 </script>
</head>
<body>
    <form id="form1" runat="server">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
          onrowdeleting="GridView1_RowDeleting" 
          onrowdatabound="GridView1_RowDataBound" 
          onrowcommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="编号">
                        <ItemTemplate>
                            <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="姓名" />               
                    <asp:BoundField DataField="Age" HeaderText="年龄" />
                    <asp:BoundField DataField="Grade" HeaderText="年级" />
                    <asp:BoundField DataField="Address" HeaderText="家庭地址" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" /> 
                    <asp:TemplateField HeaderText="编辑">
　　　　　　　             <ItemTemplate>
　　　　　　　　　　　         <asp:LinkButton ID="lbtID" 
                            CommandName="lbtn" runat="server" ForeColor="Blue" Text="编辑">
                            </asp:LinkButton>
　　　　　　　　　           </ItemTemplate>
                    </asp:TemplateField>      
                </Columns>          
       </asp:GridView>

        <p>编号<asp:TextBox ID="txt_id" runat="server"></asp:TextBox></p>
        <p>姓名<asp:TextBox ID="txt_name" runat="server"></asp:TextBox></p>
        <p>年龄<asp:TextBox ID="txt_age" runat="server"></asp:TextBox></p>
        <p>年级<asp:TextBox ID="txt_grade" runat="server"></asp:TextBox></p>
        <p>家庭地址<asp:TextBox ID="txt_address" runat="server"></asp:TextBox></p>
        <asp:Button ID="btnAdd" runat="server" Text="保存" onclick="btnAdd_Click" />
    </form>

</body>
</html>

