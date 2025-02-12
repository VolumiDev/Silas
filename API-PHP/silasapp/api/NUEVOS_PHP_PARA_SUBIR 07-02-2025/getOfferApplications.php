    <?php
    require_once('../includes/Database.class.php');

    if(isset($_GET['id_offer'])){
        $id_offer = $_GET['id_offer'];
        $database = new Database();
        $conn = $database->getConnection();
        
        $sql = "
            SELECT 
                s.id_user AS student_id,
                s.nie AS student_nie,
                s.name AS student_name,
                s.surname AS student_surname,
                s.gendre AS student_gender,
                s.birthdate AS student_birthdate,
                s.phone AS student_phone,
                s.emer_phone AS student_emergency_phone,
                so.presentation AS application_presentation,
                so.status AS application_status
            FROM students_offers so
            JOIN students s ON so.id_user = s.id_user
            WHERE so.id_offer = :id_offer
            ORDER BY s.name
        ";
        $stmt = $conn->prepare($sql);
        $stmt->bindParam(':id_offer', $id_offer, PDO::PARAM_INT);
        $stmt->execute();
        $applications = $stmt->fetchAll(PDO::FETCH_ASSOC);
        header('Content-Type: application/json');
        echo json_encode($applications);
    } else {
        header('400');
        echo json_encode(['error' => 'FALTA id_offer']);
    }
    ?>
