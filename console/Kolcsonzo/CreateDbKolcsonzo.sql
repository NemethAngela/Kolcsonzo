
DROP TABLE IF EXISTS `kolcsonzesek`;
DROP TABLE IF EXISTS `kolcsonzok`;


CREATE TABLE `kolcsonzesek` (
  `id` int(32) NOT NULL,
  `kolcsonzokId` int(32) NOT NULL,
  `iro` varchar(100) DEFAULT NULL,
  `mufaj` varchar(100) DEFAULT NULL,
  `cim` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


CREATE TABLE `kolcsonzok` (
  `id` int(32) NOT NULL,
  `nev` varchar(100) DEFAULT NULL,
  `szulIdo` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

ALTER TABLE `kolcsonzesek`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `kolcsonzok`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `kolcsonzesek`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT;

ALTER TABLE `kolcsonzok`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT;

ALTER TABLE `kolcsonzesek` ADD FOREIGN KEY (`kolcsonzokId`) REFERENCES `kolcsonzok` (`id`);
