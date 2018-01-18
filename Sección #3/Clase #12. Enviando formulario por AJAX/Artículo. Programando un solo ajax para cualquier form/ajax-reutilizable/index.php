<?php 
	if(!empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest') {
		sleep(1);

		$response = array(
			'response' => true,
			'message'  => 'Todo salio magnífico',
			'href'     => null,
			'function' => 'Listo()'
		);

		print_r(json_encode($response));

		exit();
	}
?>
<!DOCTYPE html>
<html lang="es">
	<head>
		<title>Ajax Ejemplo</title>
	    <meta charset="utf-8" />
 		<meta name="description" content="Formulario reutilizando lógica de ajax">

		<script src="jquery.js"></script>
		<script src="jquery.form.js"></script>
		<script src="jquery.validator.js"></script>
		<script src="ini.js"></script>

		<style>
			.form-group label{display:block;}
			.form-group{display:block;}
			.form-group .form-control{padding:4px;width:300px;}
			button{margin-top:15px;}

			.alert{text-align:center;background:green;color:#eee;padding:4px;}
			.alert button{display:none;}

			.failed{border:1px solid red;}

			form{position:relative;padding:10px;width:300px;}
			.block-loading{position:absolute;width:100%;height:100%;top:0;left:0;background:#fff url(loader.gif) no-repeat center center;opacity:0.7;}
		</style>
	</head>
	<body>

		<form action="" method="post" accept-charset="utf-8" class="upd">
			<div class="form-group">
				<label>Nombre</label>
				<input name="Nombre" value="" class="form-control required" placeholder="Ingrese su nombre" type="text">
			</div>
			<div class="form-group">
				<label>Correo</label>
				<input name="Correo" value="" class="form-control required email" placeholder="Ingrese su correo" type="text">
			</div>
			<div class="text-right">
				<button type="submit" class="btn btn-primary" data-ajax="true">
					Enviar
				</button>
			</div>

		</form>

		<script>
			function Listo(){
				alert('Me dieron click');
			}
		</script>

	</body>
</html>