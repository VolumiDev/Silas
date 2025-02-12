<?php
require_once('../includes/Database.class.php');

header('Content-Type: application/json');

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $body = json_decode(file_get_contents('php://input'), true);
    
    if (isset($body['id_user'])) {
        $id_user = $body['id_user'];
        
        try {
            $database = new Database();
            $conn = $database->getConnection();
            $sql = "UPDATE companies SET status = 0 WHERE id_user = :id_user";
            $stmt = $conn->prepare($sql);
            $stmt->bindParam(':id_user', $id_user, PDO::PARAM_INT);
            $stmt->execute();
            http_response_code(200);
            echo json_encode(['message' => 'Compañía desactivada correctamente']);
        } catch (PDOException $e) {
            http_response_code(500);
            echo json_encode(['error' => 'error: ' . $e->getMessage()]);
        }
    } else {
        http_response_code(400);
        echo json_encode(['error' => 'FALTA id_user']);
    }
} 
?>
