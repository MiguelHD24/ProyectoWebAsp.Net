<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ProjectoWeb.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= txtFechaNacimiento.ClientID %>").datepicker();
            
        });
    </script>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <link href="asset/CSS/Grid.css" rel="stylesheet" />
            <div class="container-fluid" style="margin-top: 15px">
                <div class="card">

                    <div class="card card-header" style="background-color: #f2a166">
                        <h5 style="color: #ffffff">Administración de Clientes</h5>
                    </div>
                     <div class="card-body">
                        <%-- Controles --%>
                        <div class="row">

                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Nombre</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtNombre" MaxLength="200" CssClass="form-control" />
                            </div>

                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Apellidos</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtApellidos" MaxLength="200" CssClass="form-control" />
                            </div>

                          
                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Numero de Identidad</label><label style="color:firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtNumIdentidad" MaxLength="200" CssClass="form-control" /> 
                            </div>
                            <div class="col-md-2" style="margin-top: 10px">
                                <label>Fecha de Nacimiento</label><label style="color:firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtFechaNacimiento" MaxLength="200" CssClass="form-control" />
                                
                            </div>
                            <div class="col-md-2" style="margin-top: 10px">
                                <label>Numero de Telefono</label><label style="color:firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtTelefono" MaxLength="200" CssClass="form-control" /> 
                            </div>
                           
                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Direccion</label><label style="color:firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtDireccion" MaxLength="200" CssClass="form-control" /> 
                            </div>
                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Email</label><label style="color:firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtCorreo" MaxLength="200" CssClass="form-control" /> 
                            </div>

                             <%-- Botones --%>
                        <div class="row" style="margin-top: 15px">
                            <asp:Panel runat="server" ID="panelBtnVolver" CssClass="col-md-2">
                                <asp:LinkButton Text="Volver" runat="server" CssClass="w-100 btn btn-primary" ForeColor="White" ID="lnkVolver" OnClick="lnkVolver_Click"/>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnLimpiar" CssClass="col-md-2" Visible="false">
                                <asp:LinkButton Text="Limpiar" runat="server" CssClass="w-100 btn" BackColor="#00cc66" ForeColor="White" ID="lnkLimpiar" OnClick="lnkLimpiar_Click"/>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnGuardar" CssClass="col-md-2" Visible="false">
                                <asp:LinkButton Text="Guardar" runat="server" CssClass="w-100 btn" BackColor="#000099" ForeColor="White" ID="lnkGuardar" OnClick="lnkGuardar_Click"/>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnAnular" CssClass="col-md-2" Visible="true">
                                <asp:LinkButton Text="Anular" runat="server" CssClass="w-100 btn btn-warning" ForeColor="#000000" ID="lnkAnular" OnClick="lnkAnular_Click"/>
                            </asp:Panel>
                              <asp:Panel runat="server" ID="panelBtnBloqueo" CssClass="col-md-2" Visible="true">
                                <asp:LinkButton Text="Bloqueo" runat="server" CssClass="w-100 btn btn-danger" ForeColor="#ffffff" ID="lnkBloqueo" OnClick="lnkBloqueo_Click"/>
                            </asp:Panel>
                        </div>

                            <%-- Grid --%>
                        <div class="row" style="margin-top: 15px; overflow: scroll">
                            <asp:HiddenField runat="server" ID="HF_IdCliente" Value="0" />
                            <asp:GridView runat="server"
                                ID="gridClientes"
                                AllowPaging="true"
                                PageSize="5"
                                CssClass="table table-bordered table-hover"
                                AutoGenerateColumns="false"
                                EmptyDataText="Sin Registros para mostrar"
                                DataKeyNames="idcliente"
                                AutoGenerateSelectButton="true" 
                                OnSelectedIndexChanged="gridClientes_SelectedIndexChanged"                                
                                OnPageIndexChanging="gridClientes_PageIndexChanging">
                                <HeaderStyle BackColor="#000066" Font-Bold="true"  ForeColor="White"/>
                                <SelectedRowStyle BackColor="#cccccc" ForeColor="#666666" />
                                <AlternatingRowStyle BackColor="White" />   
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                                     <asp:BoundField DataField="apellidos" HeaderText="Apellidos"/>
                                     <%--<asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha Nacimiento"/>--%>
                                     <asp:BoundField DataField="num_identidad" HeaderText="Numero Identidad"/>
                                     <asp:BoundField DataField="direccion" HeaderText="Direccion"/>
                                     <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                                     <asp:BoundField DataField="correo" HeaderText="Correo"/>
                                </Columns>
                            </asp:GridView>

                         </div>

                    </div>

                            
                            

                        </div>
                </div>
            </div>
         </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
