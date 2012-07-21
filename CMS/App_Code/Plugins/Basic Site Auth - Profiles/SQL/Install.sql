﻿CREATE TABLE IF NOT EXISTS bsa_profiles
(
	profileid INT PRIMARY KEY AUTO_INCREMENT,
	userid INT NOT NULL,
	FOREIGN KEY(`userid`) REFERENCES `bsa_users`(`userid`) ON UPDATE CASCADE ON DELETE CASCADE,

	disabled VARCHAR(1) NOT NULL DEFAULT 0,
	profile_picture_url TEXT,
	background_url TEXT,
	background_colour VARCHAR(6) DEFAULT '000000',
	colour_background VARCHAR(6) DEFAULT 'FFFFFF',
	colour_text VARCHAR(6) DEFAULT '000000',
	nutshell TEXT,
	gender TINYINT NOT NULL DEFAULT 0,
	country_code VARCHAR(2),
	FOREIGN KEY(`country_code`) REFERENCES `markup_engine_countrycodes`(`country_code`) ON UPDATE CASCADE ON DELETE SET NULL,
	occupation TEXT,

	contact_github TEXT,
	contact_website TEXT,
	contact_email TEXT,
	contact_facebook TEXT,
	contact_googleplus TEXT,
	contact_steam TEXT,
	contact_wlm TEXT,
	contact_skype TEXT,
	contact_youtube TEXT,
	contact_soundcloud TEXT,
	contact_xbox TEXT,
	contact_psn TEXT,
	contact_flickr TEXT,
	contact_twitter TEXT,
	contact_xfire TEXT,
	contact_deviantart TEXT
);