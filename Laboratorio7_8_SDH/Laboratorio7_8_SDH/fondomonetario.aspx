<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="fondomonetario.aspx.cs" Inherits="Laboratorio7_8_SDH.fondomonetario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="upd1">
                <ContentTemplate>
                    <asp:Label ID="lblPais" runat="server">País</asp:Label>
                   
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlPais" runat="server" Width="200px" style="margin-left:100px" DataSourceID="SqlPais" DataTextField="DESCRIPCION" DataValueField="DESCRIPCION" >
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlPais" runat="server" ConnectionString="<%$ ConnectionStrings:MONETARIOConnectionString %>" SelectCommand="SELECT * FROM [PAIS]"></asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblHabitantes" runat="server">Habitantes</asp:Label>
                    <asp:TextBox ID="txtHabitantes" runat="server" Width="195px" style="margin-left:70px"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblIdioma" runat="server">Idioma</asp:Label>
                   
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlIdioma" runat="server" Width="200px" style="margin-left:80px" DataSourceID="SqlIdioma" DataTextField="DESC_IDIOMA" DataValueField="DESC_IDIOMA">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlIdioma" runat="server" ConnectionString="<%$ ConnectionStrings:MONETARIOConnectionString %>" SelectCommand="SELECT * FROM [IDIOMA]"></asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblPIB" runat="server">PIB</asp:Label>
                    <asp:TextBox ID="txtPIB" runat="server" Width="195px" style="margin-left:110px"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblSuperficie" runat="server">Superficie</asp:Label>
                    <asp:TextBox ID="txtSuperficie" runat="server" Width="195px" style="margin-left:69px"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblRiesgo" runat="server">Riesgo seguridad</asp:Label>

                              
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                             
                    <asp:RadioButtonList ID="rbnRiesgo" runat="server" RepeatDirection="Horizontal" style="margin-left: 133px" Width="200px">
                        <asp:ListItem Selected="True" Value="1">Alto</asp:ListItem>
                        <asp:ListItem Value="2">Medio</asp:ListItem>
                        <asp:ListItem Value="3">Bajo</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:CheckBox ID="cbxCredito" runat="server" Text="Sujeto a préstamo?"/>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnRegistrar" style="margin-left:40px" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                    <asp:Button ID="btnActualizar" style="margin-left:40px" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                    <asp:Button ID="btnEliminar" style="margin-left:40px" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />

                                     
                    <br />
                    <br />
                    <asp:GridView ID="GrdMonetario" 
                        runat="server" 
                        BackColor="White" 
                        BorderColor="White" 
                        BorderStyle="Ridge" 
                        BorderWidth="2px" 
                        CellPadding="3" 
                        CellSpacing="1"
                        GridLines="None" 
                        AutoGenerateColumns="False" Width="658px" 
                        DataSourceID="SqlGestion" Height="171px"
                        >
                        <Columns>
                            <asp:BoundField DataField="PAIS" HeaderText="PAIS" SortExpression="PAIS" />
                            <asp:BoundField DataField="HABITANTES" HeaderText="HABITANTES" SortExpression="HABITANTES" />
                            <asp:BoundField DataField="IDIOMA" HeaderText="IDIOMA" SortExpression="IDIOMA" />
                            <asp:BoundField DataField="PIB" HeaderText="PIB" SortExpression="PIB" />
                            <asp:BoundField DataField="SUPERFICIE" HeaderText="SUPERFICIE" SortExpression="SUPERFICIE" />
                            <asp:BoundField DataField="RIESGO" HeaderText="RIESGO" SortExpression="RIESGO" />
                            <asp:BoundField DataField="PRESTAMO" HeaderText="PRESTAMO" ReadOnly="True" SortExpression="PRESTAMO" />
                        </Columns>
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>

                                     
                    <asp:SqlDataSource ID="SqlGestion" runat="server" ConnectionString="<%$ ConnectionStrings:MONETARIOConnectionString %>" 
                        SelectCommand=
                        "SELECT
                        P.DESCRIPCION AS PAIS
                        ,GP.CANT_HABIT AS HABITANTES
                        ,I.DESC_IDIOMA AS IDIOMA
                        ,GP.PIB
                        ,GP.SUPERFICIE
                        ,RIESGO
                        ,CASE
	                        WHEN GP.PRESTAMO = 0
		                        THEN 'NO'
		                        ELSE 'SI'
	                        END
	                    AS PRESTAMO
                        FROM GESTIONPRESTAMO GP
	                        JOIN PAIS P
	                        ON GP.ID_PAIS = P.ID_PAIS
		                        JOIN IDIOMA I
		                        ON I.ID_IDIOMA = GP.ID_IDIOMA">

                    </asp:SqlDataSource>                            
                    
                                     
                </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
    </form>
</body>
</html>
