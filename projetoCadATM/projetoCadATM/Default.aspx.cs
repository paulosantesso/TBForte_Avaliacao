using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CadATM.BLL;
using CadATM.DTO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HabilitaCampos(false);
            CarregaUF();
            ddlUF_SelectedIndexChanged(null, null);
        }
    }

    private void HabilitaCampos(bool valor)
    {
        txtPC.Enabled = !valor;

        txtNome.Enabled = valor;
        txtPA.Enabled = valor;
        txtEndereco.Enabled = valor;
        txtBairro.Enabled = valor;
        txtComplemento.Enabled = valor;

        ddlUF.Enabled = valor;
        ddlCidade.Enabled = valor;

        txtCEP.Enabled = valor;
        txtPontoRef.Enabled = valor;
        txtLatitude.Enabled = valor;
        txtLongitude.Enabled = valor;

    }

    private void CarregaDados(CadATM.DTO.ATM objATM)
    {
        txtID.Text = objATM.ID.ToString();
        txtPC.Text = objATM.PC;

        txtNome.Text = objATM.Nome;
        txtPA.Text = objATM.PA.ToString();
        txtEndereco.Text = objATM.Endereco;
        txtBairro.Text = objATM.Bairro;
        txtComplemento.Text = objATM.Complemento;

        ddlUF.SelectedItem.Value = objATM.UF.Sigla;
        ddlCidade.SelectedItem.Value = objATM.Municipio.ID.ToString();

        txtCEP.Text = objATM.CEP;
        txtPontoRef.Text = objATM.PontoReferencia;
        txtLatitude.Text = objATM.Latitude.ToString();
        txtLongitude.Text = objATM.Longitude.ToString();
    }

    private void CarregaUF()
    {
        CadATM.BLL.BLLUF objUF = new BLLUF();
        List<UF> lista = new List<UF>();

        lista = objUF.RetornaLista();

        foreach (UF _uf in lista)
        {
            var item = new ListItem
            {
                Text = _uf.Nome,
                Value = _uf.Sigla
            };

            ddlUF.Items.Add(item);
        }
    }

    protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
    {
        CadATM.BLL.BLLMunicipio objMunicipio = new BLLMunicipio();
        List<Municipio> lista = new List<Municipio>();

        lista = objMunicipio.RetornaLista(ddlUF.SelectedItem.Value);

        foreach (Municipio _municipio in lista)
        {
            var item = new ListItem
            {
                Text = _municipio.Nome,
                Value = _municipio.ID.ToString()
            };

            ddlCidade.Items.Add(item);
        }
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        try
        {
            if (String.IsNullOrEmpty(txtPC.Text))
            {
                ExibeMensagem("Campo PC vazio");
            }
            else
            {
                var bllATM = new CadATM.BLL.BLLATM();
                var objATM = bllATM.Pesquisa(txtPC.Text);

                if (objATM == null)
                {
                    //HABILITAR INCLUSAO
                    HabilitaCampos(true);
                }
                else
                {
                    //CARREGAR DADOS
                    CarregaDados(objATM);
                }
            }
        }
        catch (Exception ex)
        {
            ExibeMensagem(ex.Message);
        }

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            var objATM = new CadATM.DTO.ATM();
            var _UF = new CadATM.BLL.BLLUF();
            var _Municipio = new CadATM.BLL.BLLMunicipio();
            var _ATM = new CadATM.BLL.BLLATM();

            objATM.ID = !string.IsNullOrEmpty(txtID.Text) ? int.Parse(txtID.Text) : 0;
            objATM.PC = txtPC.Text;
            objATM.Nome = txtNome.Text;
            objATM.PA = int.Parse(txtPA.Text);
            objATM.Endereco = txtEndereco.Text;
            objATM.Bairro = txtBairro.Text;
            objATM.Complemento = txtComplemento.Text;

            objATM.CEP = txtCEP.Text;
            objATM.PontoReferencia = txtPontoRef.Text;
            objATM.Latitude = decimal.Parse(txtLatitude.Text);
            objATM.Longitude = decimal.Parse(txtLongitude.Text);

            objATM.UF = _UF.Recupera(ddlUF.SelectedItem.Value);
            objATM.Municipio = _Municipio.Recupera(int.Parse(ddlCidade.SelectedItem.Value));

            _ATM.Salvar(objATM);

        }
        catch (Exception ex)
        {
            ExibeMensagem(ex.Message);
        }


    }

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                ExibeMensagem("Campo ID vazio");
            }
            else
            {
                var bllATM = new CadATM.BLL.BLLATM();

                int IDExclusao = int.Parse(txtID.Text);
                bllATM.Exclusao(IDExclusao);
            }
        }
        catch (Exception ex)
        {
            ExibeMensagem(ex.Message);
        }
    }

    public void ExibeMensagem(string Mensagem)
    {
        Response.Write("<script>alert('" + Mensagem + "');</script>");
    }


}