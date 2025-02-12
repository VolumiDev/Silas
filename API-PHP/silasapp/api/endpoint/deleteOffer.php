<?php
require_once('../includes/Database.class.php');

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $body = json_decode(file_get_contents('php://input'), true);
    if(isset($body['id'])){
        $id = $body['id'];
        $database = new Database();
        $conn = $database->getConnection();
        $sql = "DELETE FROM offers WHERE id = :id";
        $stmt = $conn->prepare($sql);
        $stmt->bindParam(':id', $id, PDO::PARAM_INT);
        if($stmt->execute()){
            header('200 OK');
            echo json_encode(['message' => 'Oferta eliminada correctamente']);
        } else {
            header('500');
            echo json_encode(['error' => 'ERROR AL ELIMINAR OFERTA']);
        }
    } 
}
?>
