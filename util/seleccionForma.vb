Public Class seleccionForma
    Dim f As Form
    Public Function abreForma(ByRef cadena As String) As Form
        Select Case cadena
            '*****MANTENIMIENTO*****
            Case "Mantenimiento de Departamentos"
                f = New frmDepartamentos
            Case "Mantenimiento de Municipios"
                f = New frmMunicipios
            Case "Mantenimiento de Nacionalidades"
                f = New frmNacionalidades
            Case "Mantenimiento de Cargos Ministerio de Trabajo"
                f = New frmCargosMin
            Case "Mantenimiento de Estatus de Contrato"
                f = New frmEstatusContrato
            Case "Mantenimiento de Tipos de Personal"
                f = New frmTipoPersonal
            Case "Mantenimiento de Formas de Pago"
                f = New frmFormaPagoPer
            Case "Mantenimiento de Niveles Académicos"
                f = New frmNivelAca
            Case "Mantenimiento de Tipos de Seguro Social"
                f = New frmSeguroSocial
            Case "Mantenimiento de Tipos de Documento de Identificación"
                f = New frmIdentifica
            Case "Mantenimiento de Situación Socio Económica"
                f = New frmSocioEconomica
            Case "Mantenimiento de Tipos de Alta Seguro Social"
                f = New frmTipoAlta
            Case "Mantenimiento de Grados de Lesión"
                f = New frmLesion
            Case "Mantenimiento de Tipos de Suspensión"
                f = New frmTiposSuspension
            Case "Mantenimiento de Tipos de Descuentos Fijos"
                f = New frmTipoPrestamo
            Case "Mantenimiento de Tipos de Base"
                f = New frmTipoBase
            Case "Mantenimiento de Tipos de Eventos"
                f = New frmTipoEventos
            Case "Mantenimiento de Tipos de Acciones"
                f = New frmTipoAccion
            Case "Mantenimiento de Motivos de Eventos"
                f = New frmMotivoEventos
            Case "Mantenimiento de Puestos"
                f = New frmPuestos
            Case "Cambio de Código de Puesto"
                f = New frmCambioCodigo
            Case "Ingreso de Transacciones de Nómina"
                f = New frmIngTipoTran
            Case "Mantenimiento de Transacciones de Nómina"
                f = New frmConsTipoTran
            Case "Listado de Transacciones de Nómina" 'esto debo revisarlo con pruebas

            Case "Ingreso de Pasivos Laborales"
                f = New FrmIngresoProvisiones
            Case "Mantenimiento de Pasivos Laborales"
                f = New FrmMantProvisiones
            Case "Permisos Requisiciones"
                f = New frmAutorizacion_arbol
            Case "Listado Permisos Requisiciones"
                f = New frmListadoPermisos_Requi
            Case "Permisos"
                f = New frmAsignacionPermisos
            Case "Mantenimiento de Cursos"
                f = New frmTipoCurso
            Case "Cambio de Empresa"
                f = New frmSeleccionEmpresa

                '*****EVALUACIONES*****
            Case "Mantenimiento de Tipo de Evaluaciones"
                f = New frmTipoEvaluacion
            Case "Asignación de Jefes y Subalternos para Evaluaciones"
                f = New frmEvaluacionAsignacion
            Case "LISTADO DE JEFES Y SUBALTERNOS" 'Debe someterse a revisión

            Case "Resultado Evaluaciones 2011"
                f = New frmResultadoEvaluaciones
            Case "Resultado Evaluaciones Docentes"
                f = New frmListadoEvaluacionDocentes
            Case "Resultado Evaluaciones Por Jefe 2011"
                f = New frmResultadoEvaluacionesxjefe
            Case "Resultado Evaluaciones a Docentes Consolidado"
                f = New frmConsultaxMaestrosEvaluados
            Case "Resultado Evaluaciones Por Jefe 2012"
                f = New frmResultadoEvaluacionesxjefe2
            Case "Resultado Evaluaciones 2012"
                f = New frmResultadoEvaluaciones2
            Case "Evaluaciones de docentes por alumnos"
                f = New frmListadoEvaluacionDoc2014
            Case "Gráficas de evaluaciones de docentes"
                f = New frmGraficasEvaluacionDoc2014
            Case "Evaluaciones del personal"
                f = New frmListadoEvaluacion2014
            Case "Gráficas de evaluaciones del personal"
                'No existe forma
            Case "Reporte Evaluación de Colaboradores"
                f = New frmListadoEvaluacionAsignacion
            Case "Asignación de Alumnos a Maestros"
                f = New frmAsignaProfAlumGraSecc
            Case "Mantenimiento de Preguntas"
                f = New frmEvaluaPreguntas
            Case "Mantenimiento de Opciones"
                f = New frmEvaluaOpciones
            Case "Reporte de Preguntas y Opciones de Evaluaciones"
                f = New frmConsulEvaluaciones
            Case "Listado de Evaluaciones Pendientes"
                f = New frmConsultaJefes
            Case "Fecha de Vigencia de Evaluaciones"
                f = New FrmEvaluaVigencia

                '*****EMPLEADOS*****
            Case "Ingreso de Contratos"
                f = New frmIngContratos
            Case "Mantenimiento de Contratos"
                f = New frmConsContratos
            Case "Listado de Eventos de Personal"
                f = New frmListadoEventos
            Case "Impresión de Contratos"
                f = New frmImpContratos
            Case "Asignación de Jefes"
                f = New frmAsignacionJefes

                '*****SEGURO SOCIAL*****
            Case "Ingreso de Suspensiones Seguro Social"
                f = New frmIngSuspensiones
            Case "Mantenimiento de Suspensiones Seguro Social"
           '     f = New frmSuspensiones
            Case "Planilla del Seguro Social"
                f = New frmListadoSeguroSocial
            Case "Planilla del Seguro Social Excel"
                f = New frmIGSS
                '*****MOVIMIENTOS DE NOMINA*****
            Case "Mantenimiento de Movimientos Variables de Nómina"
                f = New frmMantMovNominas
            Case "Ingreso de Descuentos Fijos"
                f = New frmIngPrestamos
            Case "Mantenimiento de Descuentos FIjos"
                f = New frmConsPrestamos
            Case "Listado de Movimientos Variables de Nómina"
                f = New frmListadoMovimientoVariables
            Case "Mantenimiento de Movimientos Variables para multiple empleados"
                f = New frmMovimientosNominaMultiple

                '*****NOMINA*****
            Case "Ingreso de Tipos de Nómina"
                f = New frmIngTipoNomina
            Case "Mantenimiento de Tipos de Nómina"
                f = New frmIngConxNomina

            Case "Generación de Nómina de Anticipo Quincenal"
                f = New frmGenePagoNomiQui
            Case "Generación de Nómina Mensual"
                f = New frmGenePagoMensual
            Case "Generación de Nómina de Bono 14"
                f = New frmGeneraBono14
            Case "Mantenimiento de Nóminas Extraordinarias"
                f = New frmBonoEspecial
            Case "Generación de Nómina de Vacaciones y Aguinaldo"
                f = New frmGenePagoVacaciones
            Case "Eliminación de Registros de Nómina"
                f = New frmEliminaNomi
            Case "Modificación de Nómina para un único registro"
                f = New frmModificaNominaReg
            Case "Modificación Nómina"
                f = New frmModificacionNomina
            Case "Registro de Nóminas Pagadas"
                f = New frmRegistroNominas
            Case "Generación de Nómina de Vacaciones y Aguinaldo Especial"
                f = New frmGenePagoVacacionesEsp
            Case "Generación de Pagos por Forma"
                f = New frmGeneraPago
            Case "Generación de Archivo con Pagos para el Banco"
                f = New frmArchivoBanco
            Case "Generación de Pagos con Cheque"
                f = New frmGeneraPagoCheques
            Case "Impresión de Cheques"
                f = New frmImpresionCheque
            Case "Traslado de Cheques a Bancos y Contabilidad"
                f = New frmTrasladoChNomina
            Case "Impresión General de Recibos"
                f = New frmImpresionRecibo
            Case "Mantenimiento de Pagos"
                f = New frmConsultaPago
            Case "Consulta de Historial de Pago"
                f = New frmConsultaLibroSalario
            Case "Listado de Pagos Efectuados"
                f = New frmListadoPagos
            Case "Eliminación de Pagos de Nómina"
                f = New frmEliminaPago
            Case "Mantenimiento Formato Impresión de Nómina"
                f = New frmEstructuraNomina
            Case "Impresión de Nómina"
                f = New frmListadosNomina
            Case "Listado de Transacciones de Nómina Ingresadas"
                f = New frmListadoTransacciones

                '*****PAGOS DE EXTRANOMINA*****
            Case "Emisión de Cheques Extranómina"
                f = New frmIngChequeNom
            Case "Mantenimiento de Cheques Extranómina"
                If roll = 30 Then
                    f = New frmSoloConsultaCheques
                Else
                    f = New frmConsultaCheques
                End If
            Case "Ingreso de Notas Bancarias"
                f = New frmIngNotaNom
            Case "Mantenimiento de Notas Bancarias"
                f = New frmConsultaNotas
            Case "Listado de Pagos Extranómina"
                f = New frmListadoExtraNomina

                '*****LISTADOS*****
            Case "Listados de Empleados"
                f = New frmListadoEmpleados
            Case "Listado de Sueldos"
                f = New frmListadoSueldos
            Case "Listado de Contratos por Centro de Costo"
                f = New frmListadoContratosCentro
            Case "Listado de Ingresos Impuesto Sobre la Renta"
                f = New frmIngresoImpuestoISR
            Case "Libro de Salarios"
                f = New frmLibroSalario
            Case "Proyección de Indemnizaciones"
                f = New frmListadoProyecIndeminzacion
            Case "Estadística Anual"
                f = New frmGeneraEstadistica
            Case "Listado de Antigüedad de Empleados"
                f = New frmEmpleadoAntiguedad
            Case "Listado Cumpleañeros por mes"
                f = New frmListadoCumpleaños
            Case "Listado de Préstamos"
                f = New frmReportePrestamos
        End Select

        Return f
    End Function
End Class
