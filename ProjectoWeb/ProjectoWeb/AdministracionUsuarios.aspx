<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AdministracionUsuarios.aspx.cs" Inherits="ProjectoWeb.AdministracionUsuarios" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <link href="asset/CSS/Grid.css" rel="stylesheet" />
            <div class="container-fluid" style="margin-top: 15px">
                <div class="card">

                    <div class="card card-header" style="background-color: #f2a166">
                        <h5 style="color: #ffffff">Administración de Usuarios</h5>
                    </div>

                    <div class="card-body">
                        <%-- Controles --%>
                        <div class="row">

                            <div class="col-md-6" style="margin-top: 10px">
                                <label>Nombre Completo</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtNombreCompleto" MaxLength="200" CssClass="form-control" />
                            </div>

                            <div class="col-md-6" style="margin-top: 10px">
                                <label>Correo</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtCorreo" MaxLength="200" CssClass="form-control" />
                            </div>

                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Login</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtLogin" MaxLength="50" CssClass="form-control" />
                            </div>

                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Contraseña</label><label style="color: firebrick">*</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtContraseña" MaxLength="120" TextMode="Password" CssClass="form-control" />
                                    <asp:LinkButton runat="server" ID="lnkMostrarPassword" CssClass="btn btn-primary" OnClick="lnkMostrarPassword_Click">
                                        <i runat="server" id="iconoVerPassword" class="fas fa-eye"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>

                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Rol</label><label style="color: firebrick">*</label>
                                <asp:DropDownList runat="server" ID="ddlRol" AppendDataBoundItems="true" CssClass="form-control form-select">
                                    <asp:ListItem>--Seleccione--</asp:ListItem>
                                </asp:DropDownList>
                            </div>

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
                            <asp:HiddenField runat="server" ID="HF_IdUsuario" Value="0" />
                            <asp:GridView runat="server"
                                ID="gridUsuarios"
                                AllowPaging="true"
                                PageSize="5"
                                CssClass="table table-bordered table-hover"
                                AutoGenerateColumns="false"
                                EmptyDataText="Sin Registros para mostrar"
                                DataKeyNames="IdUsuario,IdRol"
                                AutoGenerateSelectButton="true" 
                                OnSelectedIndexChanged="gridUsuarios_SelectedIndexChanged" 
                                OnPageIndexChanging="gridUsuarios_PageIndexChanging">
                                <HeaderStyle BackColor="#000066" Font-Bold="true"  ForeColor="White"/>
                                <SelectedRowStyle BackColor="#cccccc" ForeColor="#666666" />
                                <AlternatingRowStyle BackColor="White" />   
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo"/>
                                     <asp:BoundField DataField="Correo" HeaderText="Correo"/>
                                     <asp:BoundField DataField="UserName" HeaderText="User Name"/>
                                     <asp:BoundField DataField="CuentaBloqueada" HeaderText="Bloqueado"/>
                                     <asp:BoundField DataField="IntentosFallidos" HeaderText="Intentos Fallidos"/>
                                     <asp:BoundField DataField="Rol" HeaderText="Rol"/>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
