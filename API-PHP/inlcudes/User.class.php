<?php
    require_once('Database.class.php');

    //CONTENDRA TODOS LOS METODOS PARA MANIPULAR LA BADE DE DATOS

    class User{
        public static function create_user($email, $name, $password){
            $database = new Database();
            $conn = $database->getConnection();

            $stmt = $conn->prepare('INSERT INTO users_list(email, name, password)
                VALUES (:email, :name, :password)');

            $stmt->bindParam(':email', $email);
            $stmt->bindParam(':name', $name);
            $stmt->bindParam(':password', $password);

            if ( $stmt-> execute()){
                print json_encode(
                    array(
                        'estado' => '1',
                        'mensaje' => 'Creación correcta'));
        
            }else{
                print json_encode(
                    array(
                        'estado' => '0',
                        'mensaje' => 'Creación incorrecta'));
            }
        }
    }
?>