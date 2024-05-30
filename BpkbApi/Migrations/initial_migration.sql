-- Table: tr_bpkb
CREATE TABLE IF NOT EXISTS tr_bpkb (
    agreement_number VARCHAR(100) PRIMARY KEY,
    bpkb_no VARCHAR(100),
    branch_id VARCHAR(10),
    bpkb_date DATETIME,
    faktur_no VARCHAR(100),
    faktur_date DATETIME,
    location_id VARCHAR(10),
    police_no VARCHAR(20),
    bpkb_date_in DATETIME,
    created_by VARCHAR(20),
    created_on DATETIME DEFAULT CURRENT_TIMESTAMP,
    last_updated_by VARCHAR(20),
    last_updated_on DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (location_id) REFERENCES ms_storage_location(location_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Table to store information about vehicle BPKB (vehicle registration) transactions.';

-- Table: ms_storage_location
CREATE TABLE IF NOT EXISTS ms_storage_location (
    location_id VARCHAR(10) PRIMARY KEY,
    location_name VARCHAR(100)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Table to store information about storage locations.';

-- Table: ms_user
CREATE TABLE IF NOT EXISTS ms_user (
    user_id BIGINT PRIMARY KEY AUTO_INCREMENT COMMENT 'Unique identifier for users',
    user_name VARCHAR(20) NOT NULL COMMENT 'Username of the user',
    password VARCHAR(50) NOT NULL COMMENT 'User password',
    is_active BIT DEFAULT 1 COMMENT 'Flag indicating whether the user is active or not (1 for active, 0 for inactive)',
    created_on DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Timestamp indicating when the user was created',
    last_updated_on DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Timestamp indicating when the user was last updated'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Table to store information about system users.';
