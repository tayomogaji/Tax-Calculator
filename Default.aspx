<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Tax" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
    <title>Tax Calculator</title>
    <link rel="shortcut icon" type="image/x-icon" href="calculator_icon_fxx_icon.ico" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="taxStyle.css" rel="stylesheet" type="text/css"/>
</head>

<body>
    <div class="jumbotron">
    <h1>Tax calculator</h1>
    </div>

    <%--------------------------start of form section-------------------------%>
    <form id="form1" runat="server">   
    <div class="w3-container" id="mainInput" runat="server">
      <div class="row">
     <%--------------------------start of Input section-------------------------%>
          <div class="col-md-4 col-md-offset-1 calculate">

            <%--Dropdown and list items for Income and time period.--%> 
            <hr/><h2>Income</h2><hr/>
            <asp:TextBox class="options" ID="userIncome" runat="server" Placeholder="Your Income"></asp:TextBox>
            <div>
            <h4>per</h4>
            <asp:DropDownList class="options" ID="period" runat="server" OnSelectedIndexChanged="period_SelectedIndexChanged">
                <asp:ListItem Value ="Y">Year</asp:ListItem>
                <asp:ListItem Value ="M">Month</asp:ListItem>
                <asp:ListItem Value ="W">Week</asp:ListItem>
            </asp:DropDownList>
            <br/>
            <asp:Label ID="errortext" runat="server" Text=""></asp:Label>
        </div><hr/>

        <div>
            <h2>Age</h2><hr/>
            <asp:DropDownList class="options" ID="age" runat="server">
                <asp:ListItem Value ="U">U65</asp:ListItem>
                <asp:ListItem Value ="O">65+</asp:ListItem>
            </asp:DropDownList>

            <%--National Insureance checkbox option--%>
            <h4>Include NI</h4>
            <asp:CheckBox class="options" ID="ni" runat="server" Checked="True" />
        </div><hr/>

        <div>
        <asp:Button class="options" ID="calculate" runat="server" Text="Calculate" OnClick="calculate_Click" />
        </div>
        </div>
    <%--------------------------end of form section-------------------------%>

    <%------------------------start of Results section-------------------------%>
          <div class="col-md-5 col-md-offset-1 tax">
        <div class="afterTax">
            <h2>After Tax</h2><hr/>
        <asp:Label ID="afterTax" runat="server" Text=""></asp:Label><hr/>
        <h4>Breakdown</h4><br/> 
            </div>
            

        <div class="col-md-7 col-md-offset-2 text-left">
        <asp:Table ID="breakdown" runat="server" Width="279px"> 
            <asp:TableRow>
            <asp:TableCell>Gross Income</asp:TableCell> 
                <asp:TableCell><asp:Label ID="gross" runat="server" Text=""></asp:Label></asp:TableCell> 
        </asp:TableRow>

            <asp:TableRow>
            <asp:TableCell>Allowance</asp:TableCell>
                <asp:TableCell><asp:Label ID="allowance" runat="server" Text=""></asp:Label></asp:TableCell> 
        </asp:TableRow>

            <asp:TableRow>
            <asp:TableCell>Taxable Income</asp:TableCell>
                <asp:TableCell><asp:Label ID="taxableTotal" runat="server" Text=""></asp:Label></asp:TableCell> 
        </asp:TableRow>

            <asp:TableRow>
            <asp:TableCell>Taxed Income</asp:TableCell>
                <asp:TableCell><asp:Label ID="taxed" runat="server" Text=""></asp:Label></asp:TableCell> 
        </asp:TableRow>

            <asp:TableRow>
            <asp:TableCell>National Insurance</asp:TableCell>
                <asp:TableCell><asp:Label ID="niTax" runat="server" Text=""></asp:Label></asp:TableCell> 
        </asp:TableRow>

            <asp:TableRow>
            <asp:TableCell>Total Tax Due</asp:TableCell>
                <asp:TableCell><asp:Label ID="taxTotal" runat="server" Text=""></asp:Label></asp:TableCell> 
        </asp:TableRow>
    </asp:Table> 
            </div>
            </div>
            
                    <%--using a table to breakdown the details--%>
        
     <%------------------------end of Results section-------------------------%>
   </div><%--row--%>
 </div><%--w3-container--%>
</form>
</body>
</html>
