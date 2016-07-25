<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportMorador.aspx.cs" Inherits="ReportMorador" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório de Moradores</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container-fluid (full-width)">
        <form id="form1" runat="server" defaultbutton="btnMostrar">
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
                <div class="form-inline">
                    <h2>Busca por:</h2>
                    <p></p>
                    <div class="form-group">
                        <label for="nome">Nome:</label>
                        <asp:TextBox class="form-control" ID="txtNome" runat="server" placeholder="Enter name"></asp:TextBox>
                        <div class="form-group">
                            <label for="status">Bloco:</label>
                            <asp:DropDownList ID="DowListBloco" runat="server" Height="31px" Width="95px">
                                <asp:ListItem Value="0">--TODOS--</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                                <asp:ListItem Value="13">13</asp:ListItem>
                                <asp:ListItem Value="14">14</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="16">16</asp:ListItem>
                                <asp:ListItem Value="17">17</asp:ListItem>
                                <asp:ListItem Value="18">18</asp:ListItem>
                                <asp:ListItem Value="19">19</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="21">21</asp:ListItem>
                                <asp:ListItem Value="22">22</asp:ListItem>
                                <asp:ListItem Value="23">23</asp:ListItem>
                                <asp:ListItem Value="24">24</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="status">Apto:</label>
                        <asp:DropDownList ID="DowListApto" runat="server" Height="31px" Width="95px">
                            <asp:ListItem Value="0">--TODOS--</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="11">11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="13">13</asp:ListItem>
                            <asp:ListItem Value="14">14</asp:ListItem>
                            <asp:ListItem Value="15">15</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="21">21</asp:ListItem>
                            <asp:ListItem Value="22">22</asp:ListItem>
                            <asp:ListItem Value="23">23</asp:ListItem>
                            <asp:ListItem Value="24">24</asp:ListItem>
                            <asp:ListItem Value="25">25</asp:ListItem>
                            <asp:ListItem Value="26">26</asp:ListItem>
                            <asp:ListItem Value="31">31</asp:ListItem>
                            <asp:ListItem Value="32">32</asp:ListItem>
                            <asp:ListItem Value="33">33</asp:ListItem>
                            <asp:ListItem Value="34">34</asp:ListItem>
                            <asp:ListItem Value="35">35</asp:ListItem>
                            <asp:ListItem Value="36">36</asp:ListItem>
                            <asp:ListItem Value="41">41</asp:ListItem>
                            <asp:ListItem Value="42">42</asp:ListItem>
                            <asp:ListItem Value="43">43</asp:ListItem>
                            <asp:ListItem Value="44">44</asp:ListItem>
                            <asp:ListItem Value="45">45</asp:ListItem>
                            <asp:ListItem Value="46">46</asp:ListItem>
                            <asp:ListItem Value="51">51</asp:ListItem>
                            <asp:ListItem Value="52">52</asp:ListItem>
                            <asp:ListItem Value="53">53</asp:ListItem>
                            <asp:ListItem Value="54">54</asp:ListItem>
                            <asp:ListItem Value="55">55</asp:ListItem>
                            <asp:ListItem Value="56">56</asp:ListItem>
                            <asp:ListItem Value="61">61</asp:ListItem>
                            <asp:ListItem Value="62">62</asp:ListItem>
                            <asp:ListItem Value="63">63</asp:ListItem>
                            <asp:ListItem Value="64">64</asp:ListItem>
                            <asp:ListItem Value="65">65</asp:ListItem>
                            <asp:ListItem Value="66">66</asp:ListItem>
                            <asp:ListItem Value="71">71</asp:ListItem>
                            <asp:ListItem Value="72">72</asp:ListItem>
                            <asp:ListItem Value="73">73</asp:ListItem>
                            <asp:ListItem Value="74">74</asp:ListItem>
                            <asp:ListItem Value="75">75</asp:ListItem>
                            <asp:ListItem Value="76">76</asp:ListItem>
                            <asp:ListItem Value="81">81</asp:ListItem>
                            <asp:ListItem Value="82">82</asp:ListItem>
                            <asp:ListItem Value="83">83</asp:ListItem>
                            <asp:ListItem Value="84">84</asp:ListItem>
                            <asp:ListItem Value="85">85</asp:ListItem>
                            <asp:ListItem Value="86">86</asp:ListItem>
                            <asp:ListItem Value="91">91</asp:ListItem>
                            <asp:ListItem Value="92">92</asp:ListItem>
                            <asp:ListItem Value="93">93</asp:ListItem>
                            <asp:ListItem Value="94">94</asp:ListItem>
                            <asp:ListItem Value="95">95</asp:ListItem>
                            <asp:ListItem Value="96">96</asp:ListItem>
                            <asp:ListItem Value="101">101</asp:ListItem>
                            <asp:ListItem Value="102">102</asp:ListItem>
                            <asp:ListItem Value="103">103</asp:ListItem>
                            <asp:ListItem Value="104">104</asp:ListItem>
                            <asp:ListItem Value="105">105</asp:ListItem>
                            <asp:ListItem Value="106">105</asp:ListItem>
                            <asp:ListItem Value="106">106</asp:ListItem>
                            <asp:ListItem Value="111">111</asp:ListItem>
                            <asp:ListItem Value="112">112</asp:ListItem>
                            <asp:ListItem Value="113">113</asp:ListItem>
                            <asp:ListItem Value="114">114</asp:ListItem>
                            <asp:ListItem Value="115">115</asp:ListItem>
                            <asp:ListItem Value="116">116</asp:ListItem>
                            <asp:ListItem Value="121">121</asp:ListItem>
                            <asp:ListItem Value="122">122</asp:ListItem>
                            <asp:ListItem Value="123">123</asp:ListItem>
                            <asp:ListItem Value="124">124</asp:ListItem>
                            <asp:ListItem Value="125">125</asp:ListItem>
                            <asp:ListItem Value="126">126</asp:ListItem>
                            <asp:ListItem Value="131">131</asp:ListItem>
                            <asp:ListItem Value="132">132</asp:ListItem>
                            <asp:ListItem Value="133">133</asp:ListItem>
                            <asp:ListItem Value="134">134</asp:ListItem>
                            <asp:ListItem Value="135">135</asp:ListItem>
                            <asp:ListItem Value="136">136</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:Button class="btn btn-default" ID="btnMostrar" OnClick="Button1_Click" runat="server" Text="Mostrar" />
                    <asp:Button class="btn btn-default" ID="btnVoltar" OnClick="btnVoltar_Click" runat="server" Text="Voltar" />
                    <br />
                    <br />
                </div>
                <rsweb:ReportViewer ID="rptMorador" runat="server" SizeToReportContent="true">
                </rsweb:ReportViewer>
            </div>
        </form>
    </div>
</body>
</html>
