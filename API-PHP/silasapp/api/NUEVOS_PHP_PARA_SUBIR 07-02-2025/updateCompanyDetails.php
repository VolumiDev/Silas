<?php
require_once('../includes/Database.class.php');

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $body = json_decode(file_get_contents('php://input'), true);
    
    if (isset($body['id_user'])) {
        $id_user = $body['id_user'];
        $adress    = isset($body['adress'])    ? $body['adress']    : null;
        $telephone = isset($body['telephone']) ? $body['telephone'] : null;
        $contact   = isset($body['contact'])   ? $body['contact']   : null;
        $mobile    = isset($body['mobile'])    ? $body['mobile']    : null;
        $status    = isset($body['status'])    ? $body['status']    : null;
        
        $fields = [];
        $params = [':id_user' => $id_user];
        
        if ($adress !== null) {
            $fields[] = "adress = :adress";
            $params[':adress'] = $adress;
        }
        if ($telephone !== null) {
            $fields[] = "telephone = :telephone";
            $params[':telephone'] = $telephone;
        }
        if ($contact !== null) {
            $fields[] = "contact = :contact";
            $params[':contact'] = $contact;
        }
        if ($mobile !== null) {
            $fields[] = "mobile = :mobile";
            $params[':mobile'] = $mobile;
        }
        if ($status !== null) {
            $fields[] = "status = :status";
            $params[':status'] = $status;
        }
        
        if (empty($fields)) {
            http_response_code(400);
            echo json_encode(['error' => 'No hay campos que actualizar']);
            exit;
        }
        
        $setClause = implode(", ", $fields);
        
        try {
            $database = new Database();
            $conn = $database->getConnection();
            $sql = "UPDATE companies SET $setClause WHERE id_user = :id_user";
            $stmt = $conn->prepare($sql);
            
            foreach ($params as $key => $value) {
                $stmt->bindValue($key, $value);
            }
            
            $stmt->execute();
            http_response_code(200);
            echo json_encode(['message' => 'Empresa actualizada correctamente']);
        } catch (PDOException $e) {
            http_response_code(500);
            echo json_encode(['error' => 'error: ' . $e->getMessage()]);
        }
    } 
}
?>
