

function Mensaje(title, mensaje, icon = 'success', btnConfirmText = 'Aceptar', btnConfirmColor = '#32A525', html = false, fondo = false, ReturnLogin = false, UrlReturn = '',CerrarClik = false)
{

    try {

        Atributos = {
            title: title,
            icon: icon,
            confirmButtonText: btnConfirmText,
            confirmButtonColor: btnConfirmColor,
            allowOutsideClick: CerrarClik
        };

        if (html) {
            Atributos.html = mensaje;
        }

        if (!html) {
            Atributos.text = mensaje;
        }

        if (fondo) {
            Atributos.backdrop = 'rgba(224,225,226,1)';
        }

        if (ReturnLogin) {
            Swal.fire(Atributos).then((result) => { window.location.replace(UrlReturn) });
        }
        else {
            Swal.fire(Atributos);
        }
    } catch (e) {
        console.log(e);
    }
   
}

//Mensajes de confirmación
function Confirmar(Msg,btnPosback, Title, withSiteMaster = true, iconColor = '#C22F00', btnCancelColor = '#18BEE3', btnConfirmText = 'Confirmar', btnConfirmColor = '#F27474', btnReverse = true) {
    Swal.fire
        ({
            title: Title,
            text: Msg,
            icon: 'question',
            iconColor: iconColor,
            showCancelButton: true,
            cancelButtonColor: btnCancelColor,
            cancelButtonText: 'Cancelar',
            confirmButtonText: btnConfirmText,
            confirmButtonColor: btnConfirmColor,
            reverseButtons: btnReverse
        }).then((result) => {
            if (result.isConfirmed) {
                if (withSiteMaster) {
                    __doPostBack('ctl00$ContentPlaceHolder1$' + btnPosback, '');
                }
                else {
                    __doPostBack(btnPosback, '');
                }
            }
            else {
                Swal.fire(
                    '',
                    'Operación Cancelada!!!',
                    'warning'
                )
            }
        });
}
