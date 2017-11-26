<?php
		switch($_REQUEST['action']){
			case 'traer_algo':
			sleep(3);
				echo json_encode(array('algo'=>'soy algoooooo'));
			break;
		}
?>
