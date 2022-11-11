-- TABLA Genres
INSERT INTO "Genres" (id, name) VALUES 
	(1, 'Metroidvania'),
	(2, 'Plataformas'),
	(3, 'Aventura'),
	(4, 'Peleas'),
	(5, 'Accion'),
	(6, 'Puzzle'),
	(7, 'Carreras'),
	(8, 'Shooter'),
	(9, 'Simulacion'),
	(10, 'Deportes'),
	(11, 'Estrategia'),
	(12, 'RPG'),
	(13, 'Shoot''em up'),
	(14, 'Sigilo'),
	(15, 'Hack and slash'),
	(16, 'Estrategia por turnos'),
	(17, 'Beat''em up');

-- TABLA Developers
INSERT INTO "Developers" (id, name, web) VALUES
	(1, 'Team Cherry', 'https://www.teamcherry.com.au/'),
	(2, 'Sabotage Studio', 'https://sabotagestudio.com/'),
	(3, 'StudioMDHR', null),
	(4, 'Extremely OK Games', 'https://exok.com/'),
	(5, 'Asobo Studio', 'https://www.asobostudio.com/'),
	(6, 'Ninja Theory', 'https://www.ninjatheory.com/'),
	(7, 'Subset Games', 'https://subsetgames.com/'),
    (8, 'DrinkBox Studios', 'https://www.drinkboxstudios.com/');

-- TABLA Engines
INSERT INTO "Engines" (id, name, languages, web) VALUES
	(1, 'Unity', 'C#', 'https://unity.com/'),
	(2, 'MonoGame', 'C#', 'https://www.monogame.net/'),
	(3, 'Unreal Engine 4', 'C++|Blueprint Visual Scripting', 'https://www.unrealengine.com/en-US'),
	(10, 'In-House', null, null);
	
-- TABLA Platforms
INSERT INTO "Platforms" (id, name) VALUES 
    (1, 'Microsoft Windows'),
    (2, 'macOS'),
    (3, 'Linux'),
    (4, 'Nintendo Switch'),
    (5, 'Play Station 4'),
    (6, 'Xbox One'),
    (7, 'Stadia'),
    (8, 'Play Station 3'),
    (9, 'Play Station Vita'),
    (10, 'Wii U'),
    (11, 'Xbox 360');


-- TABLA Games 
INSERT INTO "Games" (id, name, publisher, web, developer_id, engine_id) VALUES
	(1, 'Hollow Knight', 'Team Cherry', 'https://www.hollowknight.com', 1, 1),
	(2, 'The Messenger', 'Devolver Digital', 'https://themessengergame.com/', 2, 1),
	(3, 'Cuphead', 'StudioMDHR', 'https://cupheadgame.com/', 3, 1),
	(4, 'Celeste', 'Extremely OK Games', 'https://exok.com/games/celeste/', 4, 2),
	(5, 'A Plague Tale: Innocence', 'Focus Home Interactive', 'https://www.focus-entmt.com/en/games/a-plague-tale-innocence', 5, 10),
	(6, 'Hellblade: Senua''s Sacrifice', 'Ninja Theory', null, 6, 3),
	(7, 'Into The Breach', 'Subset Games', 'https://subsetgames.com/itb.html', 7, 10),
    (8, 'Guacamelee!', 'DrinkBox Studios', 'https://www.drinkboxstudios.com/games/guacamelee-super-turbo-championship-edition/', 8, 10);
	
-- TABLA Soundtracks
INSERT INTO "Soundtracks" (id, name, web, composer, game_id) VALUES
	(1, 'Hollow Knight OST', 'https://open.spotify.com/album/4XgGOMRY7H4hl6OQi5wb2Z', 'Christopher Larkin', 1),
	(2, 'The Messenger OST: Disc I (The Past)', 'https://open.spotify.com/album/10octs1G93CXaQ17ipuGUn', 'Rainbowdragoneyes', 2),
	(3, 'The Messenger OST: Disc II (The Future)', 'https://open.spotify.com/album/4BmqRRYgmHbwoJrqU9QrYk', 'Rainbowdragoneyes', 2),
	(4, 'Cuphead OST', 'https://open.spotify.com/album/3jQ7eqotwovipeZ3j3rMqu', 'Kristofer Maddigan', 3),
	(5, 'Cuphead - The Delicious Last Course (Original Soundtrack)', 'https://open.spotify.com/album/10o5BqeBBtoOIhpddPY76l', 'Kristofer Maddigan', 3),
	(6, 'Celeste OST', 'https://open.spotify.com/album/1ZfETfec0U02KrKNI8w3Gf', 'Lena Raine', 4),
	(7, 'Celeste B-Sides OST', 'https://open.spotify.com/album/3lRqLudF94UtGUmTM2bjfd', 'Lena Raine', 4),
	(8, 'A Plague Tale: Innocence OST', 'https://open.spotify.com/album/2wD6ibumlAybToO5Mpy9pK', 'Olivier Derivi�re', 5),
	(9, 'Hellblade: Senua''s Sacrifice OST', 'https://open.spotify.com/album/1ihHcMdKtZ3qY5eRXYxcl8', 'David Garc�a D�az', 6),
	(10, 'Into The Breach Sountrack', 'https://open.spotify.com/album/5HaoWXvyhc7jFlPb0vCVfM', 'Ben Prunty', 7),
    (11, 'Guacamelee! OST', 'https://drinkbox.bandcamp.com/album/guacamelee-original-soundtrack', 'Rom Di Prisco & Peter Chapman', 8);
	

-- TABLA Realeses
INSERT INTO "Releases" (game_id,platform_id, date) VALUES
	-- Hollow Knight
	(1, 1, '2017-02-24'),
	(1, 2, '2017-04-11'),	
	(1, 3, '2017-04-11'),	
	(1, 4, '2018-06-12'),
	(1, 5, '2018-09-25'),
	(1, 6, '2017-04-11'),
	-- The Messenger
	(2, 1, '2018-08-30'),
	(2, 4, '2018-08-30'),
	(2, 5, '2019-03-19'),
	(2, 6, '2020-06-25'),
	-- Cuphead
	(3, 1, '2017-09-29'),
	(3, 6, '2017-09-29'),
	(3, 2, '2018-10-19'),
	(3, 4, '2019-04-18'),
	(3, 5, '2020-07-28'),
	-- Celeste
	(4, 1, '2018-01-25'),
	(4, 2, '2018-01-25'),
	(4, 3, '2018-01-25'),
	(4, 4, '2018-01-25'),
	(4, 5, '2018-01-25'),
	(4, 6, '2018-01-25'),
	-- A Plague Tale: Innocence
	(5, 1, '2019-05-14'),
	(5, 5, '2019-05-14'),
	(5, 6, '2019-05-14'),
	-- Hellblade Senua's Sacrifice
	(6, 1, '2017-08-08'),
	(6, 4, '2019-04-11'),
	(6, 5, '2017-08-08'),
	(6, 6, '2018-04-11'),
	-- Into The Breach
	(7, 1, '2018-02-27'),
	(7, 2, '2018-08-09'),
	(7, 4, '2018-08-28'),
	(7, 3, '2020-04-20'),
	(7, 7, '2020-12-01'),
    -- Guacamelee!
    (8, 1, '2013-08-08'),
    (8, 2, '2014-02-18'),
    (8, 3, '2014-02-18'),
    (8, 5, '2014-07-02'),
    (8, 6, '2014-07-02'),
    (8, 10, '2014-07-02'),
    (8, 11, '2014-07-02'),
    (8, 8, '2013-04-09'),
    (8, 9, '2013-04-09');
	

-- TABLA ReviewScores 
INSERT INTO "ReviewScores" (reviewer, score, game_id) VALUES
	-- Hollow Knight
	('Destructoid', round(10::decimal/10, 2), 1),
	('IGN', round(9.4::decimal/10.0, 2), 1),
	('Nintendo Life', round(9::decimal/10.0, 2), 1),
	('Nintendo World Report', round(10::decimal/10, 2), 1),
	('IGN', round(9.4::decimal/10.0, 2), 1),
	('PC Gamer (US)', round(92::decimal/100.0, 2), 1),
	('PC PowerPlay', round(8::decimal/10.0, 2), 1),
	('VideoGamer.com', round(8::decimal/10.0, 2), 1),
	-- The Messenger
	('Destructoid', round(10::decimal/10.0, 2), 2),
	('GameSpot', round(8::decimal/10.0, 2), 2),
	('Hardcore Gamer', round(4.5::decimal/5.0, 2), 2),
	('IGN', round(8::decimal/10.0, 2), 2),
	('Jeuxvideo.com', round(18::decimal/20.0, 2), 2),
	('Nintendo Life', round(9::decimal/10.0, 2), 2),
	('Nintendo World Report', round(10::decimal/10.0, 2), 2),
	('USgamer', round(5::decimal/5.0, 2), 2),
	('VentureBeat', round(90::decimal/100.0, 2), 2),
	-- Cuphead
	('3DJuegos', round(9::decimal/10.0, 2), 3),
	('Atomix', round(90::decimal/100.0, 2), 3),
	('Destructoid', round(9.5::decimal/10.0, 2), 3),
	('Electronic Gaming Monthly', round(9.5::decimal/10.0, 2), 3),
	('GameSpot', round(8::decimal/10.0, 2), 3),
	('Hobby Consolas', round(90::decimal/100.0, 2), 3),
	('Level Up', round(9::decimal/10.0, 2), 3),
	('MeriStation', round(9::decimal/10.0, 2), 3),
	('Polygon', round(8.5::decimal/10.0, 2), 3),
	('Vandal', round(9::decimal/10.0, 2), 3),	
	('IGN.es', round(9::decimal/10.0, 2), 3),
	('Zonared', round(9::decimal/10.0, 2), 3),
	-- Celeste
	('Destructoid', round(10::decimal/10.0, 2), 4),
	('Game Informer', round(9::decimal/10.0, 2), 4),
	('GameSpot', round(9::decimal/10.0, 2), 4),
	('IGN', round(10::decimal/10.0, 2), 4),
	('Nintendo World Report', round(10::decimal/10.0, 2), 4),
	('PC Gamer EEUU', round(80::decimal/100.0, 2), 4),
	('Polygon', round(8::decimal/10.0, 2), 4),
	('VideoGamer.com', round(9::decimal/10.0, 2), 4),
	-- A Plague Tale: Innocence
	('Hobby Consolas', round(84::decimal/100.0, 2), 5),
	('IGN', round(7::decimal/10.0, 2), 5),
	('Level Up', round(9::decimal/10.0, 2), 5),
	('Destructoid', round(8::decimal/10.0, 2), 5),
	('Game Spot', round(8::decimal/10.0, 2), 5),
	('Meristation', round(8.5::decimal/10.0, 2), 5),
	-- Hellblade Senua's Sacrifice
	('3DJuegos', round(8.5::decimal/10.0, 2), 6),
	('Atomix', round(90::decimal/100.0, 2), 6),
	('Destructoid', round(7.5::decimal/10.0, 2), 6),
	('Electronic Gaming Monthly', round(8.5::decimal/10.0, 2), 6),
	('GameSpot', round(8::decimal/10.0, 2), 6),
	('Hobby Consolas', round(91::decimal/100.0, 2), 6),
	('IGN', round(9::decimal/10.0, 2), 6),
	('Level Up', round(8.4::decimal/10.0, 2), 6),
	('Meristation', round(9::decimal/10.0, 2), 6),
	('Polygon', round(8.5::decimal/10.0, 2), 6),
	('Vandal', round(7.8::decimal/10.0, 2), 6),
	('Game Informer', round(8::decimal/10.0, 2), 6),
	-- Into The Breach
	('Edge', round(9::decimal/10.0, 2), 7),
	('Game Informer', round(9.25::decimal/10.0, 2), 7),
	('GameSpot', round(10::decimal/10.0, 2), 7),
	('IGN', round(9::decimal/10.0, 2), 7),
    -- Guacamelee!
    ('IGN', round(9::decimal/10.0, 2), 8);


-- TABLA GameGenres
INSERT INTO GameGenres (game_id, genre_id) VALUES
	-- Hollow Knight
	(1, 1),
	-- The Messenger
	(2, 5),
	(2, 2),
	-- Cuphead
	(3, 2),
	(3, 13),
	-- Celeste
	(4, 2),
	-- A Plague Tale: Innocence
	(5, 3),
	(5, 5),
	(5, 6),
	(5, 14),
	-- Hellblade Senua's Sacrifice
	(6, 3),
	(6, 5),
	(6, 6),
	(6, 15),
	-- Into The Breach
	(7, 16),
    -- Guacamelee!
    (8, 1),
    (8, 2),
    (8, 17);

