<?php
require_once('../includes/Database.class.php');

if (isset($_GET['id_user'])) {
    $id_user = $_GET['id_user'];
    $database = new Database();
    $conn = $database->getConnection();
        $sql = "SELECT 
                id_user AS company_id,
                name AS company_name,
                adress AS company_address,
                telephone AS company_telephone,
                contact AS company_contact,
                mobile AS company_mobile,
                status AS company_status
            FROM companies
            WHERE id_user = :id_user";
    
    $stmt = $conn->prepare($sql);
    $stmt->bindParam(':id_user', $id_user, PDO::PARAM_INT);
    $stmt->execute();
    $company = $stmt->fetch(PDO::FETCH_ASSOC);
    
    if ($company) {
        header('Content-Type: application/json');
        echo json_encode($company);
    }
} else {
    header("400");
    echo json_encode(["error" => "FALTA id_user"]);
}
?>
