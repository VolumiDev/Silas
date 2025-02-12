<?php
    require_once('Database.class.php');

    //CONTENDRA TODOS LOS METODOS PARA MANIPULAR LA BADE DE DATOS
    class Student{
        

        //METODO PARA TRAER UN ESTUDENT POR LA ID
        public static function getStudentById($id){
            $database = new Database();
            $conn = $database->getConnection();

            $stmt = $conn->prepare('SELECT * FROM students WHERE id_user = :id');
            $stmt->bindParam(':id', $id);

            if ($stmt->execute()){
                $result = $stmt->fetch(PDO::FETCH_ASSOC);
                header('Content-Type: application/json');
                echo json_encode($result);
            }else{
                header('HTTP/1.1 404 Student not found');
            }
        }



        
        // //METODO PARA CREAR UN USUARIO
        // public static function create_user($email, $password){
            
        //     $database = new Database();
        //     $conn = $database->getConnection();

        //     $stmt = $conn->prepare('INSERT INTO users(email, password, status)
        //         VALUES (:email, :password, 0)');

        //     $stmt->bindParam(':email', $email);
        //     $stmt->bindParam(':password', $password);
            

        //     if ( $stmt-> execute()){
        //         header('HTTP/1.1 201 User created saccessfully');
        //     }else{
        //         header('HTTP/1.1 404 User did not created');
        //     }
        // }


        // //METODO PARA VERIFICAR SI UN EMAIL YA EXISTE
        // public static function exist_email($email){
        //     $database = new Database();
        //     $conn = $database->getConnection();

        //     try{
        //         $stmt = $conn->prepare('SELECT * FROM users WHERE email = :email');
        //         $stmt->bindParam(':email', $email);
        //         if ($stmt->execute()){
        //             $result = $stmt->fetch();
                    
        //             // Respuesta JSON indicando si el email existe o no
        //         header('Content-Type: application/json');
        //         echo json_encode(['exist' => $result ? true : false]);
        //         }else{
        //              // Error en la ejecución de la consulta
        //             header('Content-Type: application/json');
        //             header('HTTP/1.1 500 Internal Server Error');
        //             echo json_encode(['error' => 'Query execution failed']);
        //         }
        //     }catch(PDOException $e){
        //         // Error en la ejecución de la consulta
        //         header('Content-Type: application/json');
        //         header('HTTP/1.1 500 Internal Server Error');
        //         echo json_encode(['error' => 'Query execution failed']);
        //     }  
            
        // }


        // //METODO PARA VALIDAR CREDENCIALES
        // public static function credential_validator($email, $password){
        //     $database = new Database();
        //     $conn = $database->getConnection();
        
        //     try {
        //         // Consulta para obtener id, status y verificar si el usuario es estudiante o compañía
        //         $stmt = $conn->prepare(
        //             'SELECT u.id, u.status, 
        //                 CASE 
        //                     WHEN s.id_user IS NOT NULL THEN "student"
        //                     WHEN c.id_user IS NOT NULL THEN "company"
        //                     ELSE NULL
        //                 END AS category
        //             FROM users u
        //             LEFT JOIN students s ON u.id = s.id_user
        //             LEFT JOIN companies c ON u.id = c.id_user
        //             WHERE u.email = :email AND u.password = :password'
        //         );
        
        //         $stmt->bindParam(':email', $email);
        //         $stmt->bindParam(':password', $password);
        
        //         if ($stmt->execute()) {
        //             $result = $stmt->fetch(PDO::FETCH_ASSOC);
        
        //             if ($result) {
        //                 // Credenciales correctas
        //                 header('Content-Type: application/json');
        //                 http_response_code(200); // Status 200: OK
        //                 echo json_encode([
        //                     'status' => 200,
        //                     'id' => $result['id'],
        //                     'user_status' => $result['status'],
        //                     'category' => $result['category']
        //                 ]);
        //             } else {
        //                 // Credenciales incorrectas
        //                 header('Content-Type: application/json');
        //                 http_response_code(401); // Status 401: Unauthorized
        //                 echo json_encode([
        //                     'status' => 401,
        //                     'id' => -1,
        //                     'user_status' => -1,
        //                     'category' => "Credentials Error"
        //                 ]);
        //             }
        //         } else {
        //             // Error en la ejecución de la consulta
        //             header('Content-Type: application/json');
        //             http_response_code(500); // Status 500: Internal Server Error
        //             echo json_encode([
        //                     'status' => 500,
        //                     'id' => -1,
        //                     'user_status' => -1,
        //                     'category' => "Query Error"
        //             ]);
        //         }
        //     } catch (PDOException $e) {
        //         // Error en la conexión o consulta
        //         header('Content-Type: application/json');
        //         http_response_code(500); // Status 500: Internal Server Error
        //         echo json_encode([
        //             'status' => 500,
        //             'error' => 'Database error: ' . $e->getMessage()
        //         ]);
        //     }
        // }


        // //METODO PARA AGREGAR UN USUARIO A LA TABLA DE STUDENTS
        // public static function addUserToStudent($id){
        //     $database = new Database();
        //     $conn = $database->getConnection();

        //     $stmt = $conn->prepare('INSERT INTO students(id_user) VALUES (:id)');
        //     $stmt->bindParam(':id', $id);

        //     if ($stmt->execute()){
        //         header('HTTP/1.1 201 User added to student table');
        //     }else{
        //         header('HTTP/1.1 404 User did not added to student table');
        //     }
        // }



        // //METODO PARA AGREGAR UN USUARIO A LA TABLA DE COMPANIES
        // public static function addUserToCompany($id){
        //     $database = new Database();
        //     $conn = $database->getConnection();

        //     $stmt = $conn->prepare('INSERT INTO companies(id_user) VALUES (:id)');
        //     $stmt->bindParam(':id', $id);

        //     if ($stmt->execute()){
        //         header('HTTP/1.1 201 User added to company table');
        //     }else{
        //         header('HTTP/1.1 404 User did not added to company table');
        //     }
        // }
        
    }
?>