namespace Util.ApplicationServices.Tests.Samples {
    public static class TreeDtoExtension {
        public static TreeDto ToDto( this TreeEntity entity ) {
            entity.CheckNull( "entity" );
            return new TreeDto() {
                Id = entity.Id.ToString(),
                ParentId = entity.ParentId,
                Level = entity.Level,
                Path = entity.Path,
                SortId = entity.SortId,
                Version = entity.Version
            };
        }

        public static TreeEntity ToEntity(this TreeDto dto ) {
            return new TreeEntity( dto.Id.ToInt(), dto.Path, dto.Level ) {
                ParentId = dto.ParentId,
                SortId = dto.SortId,
                Version = dto.Version
            };
        }
    }
}
